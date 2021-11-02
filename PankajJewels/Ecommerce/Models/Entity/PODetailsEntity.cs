using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Ecommerce.Models.Entity
{
    public class PODetailsEntity
    {
        [Key]
        public int PODetailId { get; set; }
        public int? POMasterId { get; set; }
        public int? ProductId { get; set; }
        public int? ProductDetailId { get; set; }
        public int? NumberOfItems { get; set; }
        public decimal? TotalPrice { get; set; }
        public decimal? OldPrice { get; set; }
        public decimal? GST { get; set; }
        public decimal? DaimondPrice { get; set; }
        public decimal? Discount { get; set; }
        public decimal? MakingCharges { get; set; }
        public string CurrentStatus { get; set; }
        public bool? IsDeleted { get; set; }
        public decimal? GoldPrice { get; set; }
        public decimal? GoldWeight { get; set; }
        public int? SizeId { get; set; }
        public string SizeName { get; set; }
        public decimal? GoldRate { get; set; }
        public DateTime? AddedOn { get; set; }
        public int? MetalMasterId { get; set; }
        public string MetalMasterId_Name { get; set; }
    }

}
