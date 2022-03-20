using MaterialSupport.DB.Models;
using System.ComponentModel.DataAnnotations;

namespace MaterialSupport.Core.Dto
{
    public class UserDto
    {
        [Required]
        public string Username { get; set; }

        [Required]
        public string Password { get; set; }

        [Required]
        public Roles Role { get; set; }

        public StudentDto Student { get; set; }

        public EmployeeDto Employee { get; set; }
    }
}
