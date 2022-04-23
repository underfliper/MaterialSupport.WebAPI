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
    }
}
