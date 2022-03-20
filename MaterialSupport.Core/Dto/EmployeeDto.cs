using System.ComponentModel.DataAnnotations;

namespace MaterialSupport.Core.Dto
{
    public class EmployeeDto
    {
        [Required]
        public string Surname { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Lastname { get; set; }
    }
}
