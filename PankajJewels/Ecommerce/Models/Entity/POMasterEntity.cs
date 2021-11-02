using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Ecommerce.Models.Entity
{
    public class POMasterEntity
    {
        [Key]
        public int POId { get; set; }
        public int? CartId { get; set; }
        public string TransactionId { get; set; }
        public int? UserId { get; set; }
        public string PONumber { get; set; }
        public DateTime? PaidDate { get; set; }
        public decimal? PaidAmount { get; set; }
        public string InstrumentDetails { get; set; }
        public string PaymentMethod { get; set; }
        public DateTime? RefundedOn { get; set; }
        public decimal? RefundedAmount { get; set; }
        public string OrderStatus { get; set; }
        public DateTime? CreatedOn { get; set; }
        public string CurrentStatus { get; set; }
        public bool? IsDeleted { get; set; }

        public decimal BankCharges { get; set; }
        public decimal BankTaxes { get; set; }
        public decimal Taxes { get; set; }

        public decimal OrderAmount { get; set; }
        public string Remarks { get; set; }
    }
}
