using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
namespace Ecommerce.Models.Entity
{
    public class BannerType
    {
        [Key]
        public int TRID { get; set; }
        public string TypeName { get; set; }
        public bool? IsDeleted { get; set; }
    }
}
