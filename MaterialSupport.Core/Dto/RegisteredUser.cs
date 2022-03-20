using MaterialSupport.DB.Models;

namespace MaterialSupport.Core.Dto
{
    public class RegisteredUser
    {
        public string Username { get; set; }

        public Roles Role { get; set; }

        public StudentDto Student { get; set; }

        public EmployeeDto Employee { get; set; }
    }
}
