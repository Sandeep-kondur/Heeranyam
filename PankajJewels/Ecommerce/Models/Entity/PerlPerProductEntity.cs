using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
namespace Ecommerce.Models.Entity
{
    public class PerlPerProductEntity
    {
        [Key]
        public int PPPId { get; set; }
        public int? ProductDetailId { get; set; }
        public string PerlType { get; set; }
        public int? TotalStones { get; set; }
        public decimal? TotalWeight { get; set; }
        public bool? IsDeleted { get; set; }
    }
}
