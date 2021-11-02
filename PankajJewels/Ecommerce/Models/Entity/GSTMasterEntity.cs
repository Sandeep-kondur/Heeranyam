using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Ecommerce.Models.Entity
{
    public class GSTMasterEntity
    {
        [Key]
        public int MasterId { get; set; }
        [Required(ErrorMessage = "This field is required")]
        public string GSTName { get; set; }
        [Required(ErrorMessage = "This field is required")]
        public Nullable<decimal> GSTTaxValue { get; set; }
        public Nullable<bool> IsDeleted { get; set; }

        public string GSTSource { get; set; }
    }
}
