using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace PollApp.ViewModel
{
    public class AddUserViewModel
    {
        [Required(ErrorMessage = "Username is in valid!")]
        public string UserName { get; set; }
        [EmailAddress]
        public string Email { get; set; }
        [Required(ErrorMessage = "Password is invalid!")]
        [StringLength(6)]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [Required]
        [Display(Name = "Verify Password")]
        [Compare("Password", ErrorMessage = "Passwords don't match!")]
        [DataType(DataType.Password)]
        public string VerifyPassword { get; set; }

        public AddUserViewModel()
        {}
    }
}
