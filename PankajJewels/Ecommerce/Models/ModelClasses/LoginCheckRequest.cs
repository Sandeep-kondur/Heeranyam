using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Ecommerce.Models.ModelClasses
{
    public class LoginCheckRequest
    {
        [Required(ErrorMessage = "Email Id required")]
        [EmailAddress(ErrorMessage = "Invalid Email Id")]
        public string emaild { get; set; }

        [Required(ErrorMessage = "Password required")]
        public string password { get; set; }

        public int UserId { get; set; }
    }
}
