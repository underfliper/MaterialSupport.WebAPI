﻿using System.ComponentModel.DataAnnotations;

namespace MaterialSupport.DB.Models
{
    public class User
    {
        public int Id { get; set; }

        [MaxLength(20)]
        public string Username { get; set; }

        public string Password { get; set; }

        public Roles Role { get; set; }

        public Student Student { get; set; }

        public Employee Employee { get; set; }
    }

    public enum Roles
    {
        Admin,
        Moderator,
        Student
    }
}
