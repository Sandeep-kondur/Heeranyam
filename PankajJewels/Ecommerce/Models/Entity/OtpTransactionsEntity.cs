using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Ecommerce.Models.Entity
{
    public class OtpTransactionsEntity
    {
        [Key]
        public int TRId { get; set; }
        public string EmailOTP { get; set; }
        public string MobileOTP { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime? UsedOn { get; set; }
        public bool IsDeleted { get; set; }
        public int UserId { get; set; }
        public string CurrentStatus { get; set; }
    }
}