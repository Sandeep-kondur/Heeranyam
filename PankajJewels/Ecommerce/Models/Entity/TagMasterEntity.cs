using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Ecommerce.Models.Entity
{
    public class TagMasterEntity
    {
        [Key]
        public int TagId { get; set; }
        [Required(ErrorMessage = "This field is required")]
        public string TagName { get; set; }
        public Nullable<bool> IsDeleted { get; set; }
    }
}
