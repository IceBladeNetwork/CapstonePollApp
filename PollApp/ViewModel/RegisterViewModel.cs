using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PollApp.ViewModel
{
    public class RegisterViewModel
    {
        [Required, MaxLength(256)] 
        public string Username { get; set; }

        [Required, EmailAddress, MaxLength(256)]
        public string Email { get; set; }

        [Required, MinLength(5), MaxLength(50), DataType(DataType.Password)]
        public string Password { get; set; }

        [Required, DataType(DataType.Password), Display(Name = "Confirm Password"), Compare("Password", ErrorMessage = "The Passwords don't match")]
        public string ConfirmPassword { get; set; }

        public RegisterViewModel()
        { }
    }
}
