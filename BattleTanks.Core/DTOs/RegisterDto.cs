﻿using System.ComponentModel.DataAnnotations;
using BattleTanks.DB.Enums;

namespace BattleTanks.Core.DTOs
{             
    public class RegisterDto
    {
        [Required]
        public string Nickname { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
        [Required]
        public int Age { get; set; }
        [Required]
        public Gender Gender { get; set; } 
    }
}
