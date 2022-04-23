using MaterialSupport.DB.Models;
using System;
using System.ComponentModel.DataAnnotations;

namespace MaterialSupport.Core.Dto
{
    public class StudentDto
    {
        public string Surname { get; set; }

        public string Name { get; set; }

        public string Lastname { get; set; }

        public string Group { get; set; }

        public string Gender { get; set; }

        [DataType(DataType.Date)]
        public DateTime Birthday { get; set; }

        public string Birthplace { get; set; }

        public string Citizenship { get; set; }

        public ContactsDto Contacts { get; set; }
    }
}
