import sys
import pandas as pd
from sqlalchemy.engine import URL
from sqlalchemy import create_engine
from sklearn.metrics.pairwise import cosine_similarity
from sklearn.feature_extraction.text import TfidfVectorizer

# Define a connection string
connection_string = """DRIVER={ODBC Driver 17 for SQL Server};
    Server=(localdb)\\mssqllocaldb;
    Database=MaterialSupportDB;
    Integrated Security=True"""

# Create connection with DB
connection_url = URL.create(
    "mssql+pyodbc", query={"odbc_connect": connection_string})
engine = create_engine(connection_url)

# Putting applications data on 'applications' dataframe
applications = pd.read_sql(
    """SELECT a.Id, a.Date, a.Status, s.Surname, s.Name, s.Lastname, asp.SupportTypeId
    FROM Applications as a
    JOIN Students as s
    ON a.StudentId=s.Id
    JOIN ApplicationsSupportTypes as asp
    ON a.Id=asp.ApplicationId
    WHERE a.Status=2
    """, engine)

# Find an application for which we need to receive the recommended types of material support
application = pd.read_sql(
    f"""SELECT a.Id, a.Date, a.Status, s.Surname, s.Name, s.Lastname
    FROM Applications as a
    JOIN Students as s
    ON a.StudentId=s.Id
    WHERE a.Id={sys.argv[1]}
    """, engine)
application['SupportTypeId'] = 0

# Changing column names
applications.columns = ['ApplicationId', 'Date', 'Status', 'Surname',
                        'Name', 'Lastame', 'SupportType']
application.columns = ['ApplicationId', 'Date', 'Status', 'Surname',
                       'Name', 'Lastame', 'SupportType']

# Finding all categories
categories = pd.read_sql(
    """SELECT ApplicationId, CategoryId, c.Name 
    FROM ApplicationsCategories as ac
    JOIN Categories as c 
    ON c.Id=ac.CategoryId
    """, engine)


# Merge applications and categories
df = applications.merge(categories.groupby('ApplicationId')['Name']. apply(
    lambda x: x.reset_index(drop=True)). unstack(). reset_index())
df1 = application.merge(categories.groupby('ApplicationId')['Name']. apply(
    lambda x: x.reset_index(drop=True)). unstack(). reset_index())


df.columns = ['ApplicationId', 'Date', 'Status', 'Surname',
              'Name', 'Lastame', 'SupportType', 'Category1', 'Category2', 'Category3']
df1.columns = ['ApplicationId', 'Date', 'Status', 'Surname',
               'Name', 'Lastame', 'SupportType', 'Category1', 'Category2', 'Category3']

df = pd.concat([df, df1], ignore_index=True)

# Replace all NaN values with an empty string
df = df.fillna(" ")


def concatenate_features(df_row):
    return df_row['Category1']+';'+df_row['Category2']+';'+df_row['Category3']


df['Features'] = df.apply(concatenate_features, axis=1)

tfidf = TfidfVectorizer()

features_matrix = tfidf.fit_transform(df['Features'])

similarity_matrix = cosine_similarity(
    features_matrix, features_matrix)

mapping = pd.Series(df.index, index=df['ApplicationId'])


def recommend_applications(application_input):
    application_index = mapping[application_input]

    # Get similarity values with other applications
    # similarity_score is the list of index and similarity matrix
    similarity_score = list(enumerate(similarity_matrix[application_index]))

    # Sort in descending order the similarity score of application inputted with all the other applications
    similarity_score = sorted(
        similarity_score, key=lambda x: x[1], reverse=True)

    # Get the scores of the 5 most similar applications. Ignore the first application.
    similarity_score = similarity_score[1:5]

    # Return application Id using the mapping series
    application_indices = [i[0] for i in similarity_score]
    return (df['SupportType'].iloc[application_indices])


print(recommend_applications(int(sys.argv[1])))
