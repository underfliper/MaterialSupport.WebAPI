using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MaterialSupport.DB.Models
{
    public class Employee
    {
        public int Id { get; set; }

        [MaxLength(255)]
        public string Surname { get; set; }

        [MaxLength(255)]
        public string Name { get; set; }

        [MaxLength(255)]
        public string Lastname { get; set; }

        [ForeignKey("UserId")]
        public User User { get; set; }
    }
}
