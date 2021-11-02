using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Ecommerce.Models.Entity
{
    public class MetalMasterEntity
    {

        [Key]
        public int MasterId { get; set; }
        [Required(ErrorMessage = "This field is required")]
        public string MetalCode { get; set; }
        public Nullable<bool> IsDeleted { get; set; }

        public string GoldKarat { get; set; }
        public decimal? PriceCalPercentage { get; set; }
    }
}
