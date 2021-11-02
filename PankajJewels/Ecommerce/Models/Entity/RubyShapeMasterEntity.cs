using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Ecommerce.Models.Entity
{
    public class RubyShapeMasterEntity
    {
        [Key]
        public int MasterId { get; set; }
        [Required(ErrorMessage = "This field is required")]
        public string ShapeName { get; set; }
        public Nullable<bool> IsDeleted { get; set; }
    }
}
