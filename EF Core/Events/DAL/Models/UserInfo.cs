﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models
{
    public class UserInfo
    {
        [Key]
        public string Email { get; set; }

        [Required, StringLength(50, MinimumLength = 1)]
        public string Username { get; set; }

        [Required]
        [RegularExpression("Admin|Participant")]
        public string Role { get; set; }

        [Required, StringLength(20, MinimumLength = 6)]
        public string Password { get; set; } 
    }
}
