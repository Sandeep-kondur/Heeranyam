using Ecommerce.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ecommerce.Models.ModelClasses
{
    public class ProductDisplayForAdmin
    {
        public POMasterEntity po { get; set; } 
        public PODetailsEntity pd { get; set; }
        public PostProductModel_Web product { get; set; }
        public List<POFollowUpEntity> folloup { get; set; }
    }
}
