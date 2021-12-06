using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Ecommerce.Models.ModelClasses
{
    public class LoginRequest
    {
        [Required(ErrorMessage = "Email Id  / Mobile number required")]
        public string emailid { get; set; }

        [Required(ErrorMessage ="Password Required")]
        public string pword { get; set; }
        public string url { get; set; }
        public string mobileNumber { get; set; }
        public string deviceID { get; set; }
    }

    public class UserReviewMaster
    {
        [Key]
        public int ReviewId { get; set; }
        [Required]
        public int UserId { get; set; }
        [Required]
        public int ProductId { get; set; }
        public string FeedbackMessage { get; set; }
        public string FeedbackImageUrl { get; set; }

        public double rating { get; set; }



    }
    public class ContactUs
    {

        [Key] 
        public string Name { get; set; }
        public string MobileNumber { get; set; }

        public string Emailid { get; set; }

        public string Message { get; set; }

    }
    public class LoginRequestReset
    {

        public string emailid { get; set; }
        public string pword { get; set; }
        public string url { get; set; }
        public string mobileNumber { get; set; }
    }

    public class PasswordResetKeys
    {

        public string passkey { get; set; }

        [Required(ErrorMessage = "Password Required")]
        public string pword { get; set; }

        [Required(ErrorMessage = "Conf Password Required")]
        [Compare("pword",ErrorMessage ="Password mismatch")]
        public string confpword { get; set; }
        public string url { get; set; }
        public string mobileOtp { get; set; }
        public string emailOtp { get; set; }

    }
}
