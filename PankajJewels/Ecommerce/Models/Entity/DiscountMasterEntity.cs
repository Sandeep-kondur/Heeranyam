using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
namespace Ecommerce.Models.Entity
{
    public class DiscountMasterEntity
    {
        [Key]
        public int DMasterId { get; set; }
        public string DicountTitile { get; set; }
        public string DiscountType { get; set; }
        public decimal? DiscountAmount { get; set; }
        public bool IsApplicable { get; set; }
        public bool? IsDeleted { get; set; }
    }
}
