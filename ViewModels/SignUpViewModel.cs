using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace eBlog.ViewModels
{
    public class SignUpViewModel
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string UserName { get; set; }

        [Display(Name = "Email Adress")]
        [Required(ErrorMessage = "Email address is required!")]
        public string EmailAddress { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }


        [Display(Name = "Confirm Password")]
        [Required(ErrorMessage ="Confirm Password is required!")]
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage ="Passwords do not match")]
        public string ConfirmPassword { get; set; }
    }
}
