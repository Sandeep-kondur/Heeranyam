using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Ecommerce.Models.Entity
{
    public class GoldMasterEntity
    {
        [Key]
        public int MasterId { get; set; }
        [Required(ErrorMessage = "This field is required")]
        public string GoldColor { get; set; }
        [Required(ErrorMessage = "This field is required")]
        public string GoldKarat { get; set; }
        public bool? IsDeleted { get; set; }

        public decimal? PriceCalPercentage { get; set; }
    }
}
