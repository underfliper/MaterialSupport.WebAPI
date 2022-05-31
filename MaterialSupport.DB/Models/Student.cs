using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MaterialSupport.DB.Models
{
    public class Student
    {
        public int Id { get; set; }

        [MaxLength(255)]
        public string Surname { get; set; }

        [MaxLength(255)]
        public string Name { get; set; }

        [MaxLength(255)]
        public string Lastname { get; set; }

        public string Group { get; set; }

        public string Gender { get; set; }

        [DataType(DataType.Date)]
        public DateTime Birthday { get; set; }

        public string Birthplace { get; set; }

        public string Citizenship { get; set; }

        [ForeignKey("UserId")]
        public User User { get; set; }

        public StudentContacts Contacts { get; set; }

        public List<Application> Applications { get; set; }
    }
}
