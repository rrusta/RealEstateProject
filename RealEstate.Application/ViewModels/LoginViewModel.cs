using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
//test

namespace RealEstate.Application.ViewModels
{
    public class LoginViewModel
    {
        [Required]
        public string Username { get; set; }

        [Required]
        [StringLength(16, MinimumLength = 6, ErrorMessage = "You must specify a password between 6 and 16 characters")]
        public string Password { get; set; }
    }
}
