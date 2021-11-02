using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ecommerce.Models.ModelClasses
{
    public class POFollowUpModel
    {
        public int FollowUpId { get; set; }
        public int? FollowUpBy { get; set; }
        public string FollowUpBy_Name { get; set; }
        public DateTime? FollowUpOn { get; set; }
        public string FollowUpRemarks { get; set; }
        public int? POId { get; set; }
        public int? PODetialId { get; set; }
        public bool? IsDeleted { get; set; }
    }
}
