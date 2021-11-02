using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Ecommerce.Models.Entity
{
    public class DaimondClarityMasterEntity
    {
        [Key]
        public int ClarityId { get; set; }
        [Required(ErrorMessage = "This field is required")]
        public string ClarityCode { get; set; }
        [Required(ErrorMessage ="This field is required")]
        public string ClarityName { get; set; }
        public Nullable<bool> IsDeleted { get; set; }
    }
}
