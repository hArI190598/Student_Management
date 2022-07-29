﻿using System.ComponentModel.DataAnnotations;
namespace StudentManagement.Models
{
    public class User
    {
        public string? UserName { get; set; }

        [Required]
        [MinLength(8)]
        [RegularExpression("^(?=.*_[A-Za-z])(?=.*_)[A-Za-z]{8,15}$")]
        public string? Password { get; set; }
    }
}
