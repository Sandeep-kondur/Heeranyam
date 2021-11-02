using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Ecommerce.Models.Entity
{
    public class UserTypeMasterEnity
    {
        [Key]
        public int TypeId { get; set; }

        [Required(ErrorMessage ="Type name required")]
        public string TypeName { get; set; }
        public bool IsDeleted { get; set; }
    }
}
