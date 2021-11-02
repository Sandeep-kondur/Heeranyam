using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Ecommerce.Models.Entity
{
    public class DaimondTypeMasterEntity
    {
        [Key]
        public int MasterId { get; set; }
        [Required(ErrorMessage ="This is required")]
        public string TypeName { get; set; }
        [Required(ErrorMessage = "This is required")]
        public decimal? PriceTag { get; set; }
        public bool? IsDeleted { get; set; }
        public string TypeDescription { get; set; }
    }
}
