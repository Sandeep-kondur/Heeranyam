using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Ecommerce.Models.Entity
{
    public class UserVerificationEntity
    {
        [Key]
        public int VerificationID { get; set; }
        public Nullable<int> UserID { get; set; }
        public string ActivationKey { get; set; }
        public string ActivationURL { get; set; }
        public string Status { get; set; }
        public Nullable<System.DateTime> DOR { get; set; }
        public Nullable<System.DateTime> DOA { get; set; }
    }
}
