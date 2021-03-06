﻿using System.ComponentModel.DataAnnotations;

namespace Labor.Models
{
    public class UserDetails
    {
        [StringLength(7, MinimumLength = 2, ErrorMessage = "UserName length should be between 2 and 7")]
        public string UserName { get; set; }

        public string Password { get; set; }
    }
}