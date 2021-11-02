using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ecommerce.Models.ModelClasses
{
    public class CustomizedOrderModel
    {
        public int OrderId { get; set; }
        public int? UserId { get; set; }
        public string CustomerName { get; set; }
        public string CustomerMobile { get; set; }
        public string CustomerAddress { get; set; }
        public int? ProductId { get; set; }
        public string ProductImage { get; set; }
        public int? ProductDetailId { get; set; }
        public string CustomerRequirements { get; set; }
        public DateTime? RequestedOn { get; set; }
        public bool? IsDeleted { get; set; }
        public string CurrentStatus { get; set; }
    }
}
