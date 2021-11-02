using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
namespace Ecommerce.Models.Entity
{
    public class LoginTrack
    {
        [Key]
        public int TRId { get; set; }
        public int? UserId { get; set; }
        public string UserName { get; set; }
        public DateTime? LoginTime { get; set; }
        public bool? IsDeleted { get; set; }
    }
}
