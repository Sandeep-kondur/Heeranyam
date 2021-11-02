using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
namespace Ecommerce.Models.Entity
{
    public class SolitairePerProductEntity
    {
        [Key]
        public int SPPId { get; set; }
        public int? ProductDetailId { get; set; }
        public int? TotalSolitaires { get; set; }
        public decimal? TotalWeight { get; set; }
        public bool? IsDeleted { get; set; }
    }
}
