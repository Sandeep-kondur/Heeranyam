using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Ecommerce.Models.Entity
{
    public class POFollowUpEntity
    {
        [Key]
        public int FollowUpId { get; set; }
        public int? FollowUpBy { get; set; }
        public DateTime? FollowUpOn { get; set; }
        public string FollowUpRemarks { get; set; }
        public int? POId { get; set; }
        public int? PODetialId { get; set; }
        public bool? IsDeleted { get; set; }
    }
}
