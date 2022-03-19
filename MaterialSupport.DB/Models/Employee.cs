using System.ComponentModel.DataAnnotations.Schema;

namespace MaterialSupport.DB.Models
{
    public class Employee
    {
        public int Id { get; set; }
        public string Surname { get; set; }
        public string Name { get; set; }
        public string Lastname { get; set; }

        [ForeignKey("UserId")]
        public User User { get; set; }
    }
}
