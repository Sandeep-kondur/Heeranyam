using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Ecommerce.Models.Entity
{
    public class UserMasterEntity
    {
        [Key]
        public int UserId { get; set; }

        [Required(ErrorMessage = "User Name Required")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Email Id required")]
        [EmailAddress(ErrorMessage = "Invalid Email Id")]
        public string EmailId { get; set; }

        [Required(ErrorMessage = "Password Required")]

        public string PWord { get; set; }

        [Required(ErrorMessage = "Mobile Number required")]
        public string MobileNumber { get; set; }
        public DateTime? RegisteredOn { get; set; }

        public DateTime? ActivatedOn { get; set; }

        public string CurrentStatus { get; set; }

        public int? UserTypeId { get; set; }

        public bool? IsEmailVerified { get; set; }

        public bool? IsDeleted { get; set; }

        [Required(ErrorMessage = "TermsAndConditions Must be Selected")]
        public string TermsAndConditions { get; set; }
        public string DeviceId { get; set; }

        public string? ProfileImage { get; set; }

        public string Address { get; set; }
        public int isSocialLogin { get; set; }

        public int loginType { get; set; }

        public string authID { get; set; }


    }
}
