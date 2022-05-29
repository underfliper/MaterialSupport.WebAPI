using System.ComponentModel.DataAnnotations.Schema;

namespace MaterialSupport.DB.Models
{
    public class ApplicationsDocuments
    {
        public int Id { get; set; }

        [ForeignKey("ApplicationId")]
        public Application Application { get; set; }

        [ForeignKey("DocumentId")]
        public Document Document { get; set; }
    }
}
