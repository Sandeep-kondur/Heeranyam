using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Ecommerce.Models.ModelClasses
{
    public class ForgotPasswordReset
    {
        [Required(ErrorMessage = "Password is required")]
        public string pword { get; set; }

        [Required(ErrorMessage = "Confirm Password is required")]
        [Compare("pword", ErrorMessage = "Passwords are not identical")]
        public string confpword { get; set; }

        [Required(ErrorMessage = "Key is required is required")]
        public string key { get; set; }
    }
}
