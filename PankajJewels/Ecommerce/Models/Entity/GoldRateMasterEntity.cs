using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Ecommerce.Models.Entity
{
    public class GoldRateMasterEntity
    {
        [Key]
        public int MasterId { get; set; }
        public string GoldMasterId { get; set; }
        public decimal? Rate { get; set; }
        public DateTime? DateOfLastUpdate { get; set; }
        public string UnitofMeasure { get; set; }
        public bool? IsDeleted { get; set; }
    }
}
