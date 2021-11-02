using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ecommerce.Models.ModelClasses
{
    public class PriceBreakUpModel
    {
        public decimal GoldRate { get; set; }
        public decimal DaimondRate { get; set; }
        public decimal MakingCharges { get; set; }
        public decimal GST { get; set; }
        public decimal discount { get; set; }
        public decimal totalAmount { get; set; }
        public decimal oldAmount { get; set; }
    }
}
