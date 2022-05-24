using MaterialSupport.DB.Models;
using Microsoft.EntityFrameworkCore;

namespace MaterialSupport.DB
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<User> Users { get; set; }

        public DbSet<Student> Students { get; set; }

        public DbSet<Employee> Employees { get; set; }

        public DbSet<StudentContacts> StudentContacts { get; set; }

        public DbSet<Application> Applications { get; set; }

        public DbSet<ApplicationsCategories> ApplicationsCategories { get; set; }

        public DbSet<ApplicationsSupportTypes> ApplicationsSupportTypes { get; set; }

        public DbSet<ApplicationsDocuments> ApplicationsDocuments { get; set; }

        public DbSet<Category> Categories { get; set; }

        public DbSet<SupportType> SupportTypes { get; set; }

        public DbSet<Document> Documents { get; set; }

    }
}
