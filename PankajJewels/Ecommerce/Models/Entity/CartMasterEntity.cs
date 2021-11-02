using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Ecommerce.Models.Entity
{
    public class CartMasterEntity
    {
        [Key]
        public int CartId { get; set; }
        public int? CartUserId { get; set; }
        public DateTime? CreatedOn { get; set; }
        public string CurrentStatus { get; set; }
        public bool? IsDeleted { get; set; }
    }
}
