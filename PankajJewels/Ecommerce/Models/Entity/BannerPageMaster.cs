using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
namespace Ecommerce.Models.Entity
{
    public class BannerPageMaster
    {
        [Key]
        public int TRID { get; set; }
        public string PageName { get; set; }
        public bool? IsDeleted { get; set; }
    }
}
