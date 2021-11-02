using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
namespace Ecommerce.Models.Entity
{
    public class MeasurementMasterEntity
    {
        [Key]
        public int MeasurementId { get; set; }
        public string MeasurementName { get; set; }
        public bool? IsDeleted { get; set; }
        public bool? IsEnabled { get; set; }
    }
}
