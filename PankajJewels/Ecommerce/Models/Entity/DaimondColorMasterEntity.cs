using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Ecommerce.Models.Entity
{
    public class DaimondColorMasterEntity
    {
        [Key]
        public int ColorId { get; set; }
        [Required(ErrorMessage = "This field is required")]
        public string ColorCode { get; set; }
        [Required(ErrorMessage = "This field is required")]
        public string ColorName { get; set; }
        public bool? IsDeleted { get; set; }
    }
}
