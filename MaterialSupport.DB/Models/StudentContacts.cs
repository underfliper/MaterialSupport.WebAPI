using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MaterialSupport.DB.Models
{
    public class StudentContacts
    {
        public int Id { get; set; }

        [MaxLength(12)]
        public string Phone { get; set; }

        public string Email { get; set; }

        [ForeignKey("StudentId")]
        public Student Student { get; set; }
    }
}
