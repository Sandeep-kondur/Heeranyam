using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
namespace Ecommerce.Models.Entity
{
    public class ActivityFeedEntity
    {
        [Key]
        public int Id { get; set; }
        public int? ActivityBy { get; set; }
        public int? TargetUserId { get; set; }
        public string ActivityText { get; set; }
        public DateTime? ActivityOn { get; set; }
        public int? GroupdId { get; set; }
        public bool? IsDeleted { get; set; }
        public int? GroupId { get; set; }
        public string AType { get; set; }
        public bool? IsRead { get; set; }
        public string SourceText { get; set; }
        public string TargetText { get; set; }
    }
}
