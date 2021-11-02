using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Ecommerce.Models.Entity
{
    public class ResetPasswordEntity
    {
        [Key]
        public int Id { get; set; }
        public Nullable<int> UserId { get; set; }
        public Nullable<System.DateTime> RaisedOn { get; set; }
        public Nullable<System.DateTime> ResetOn { get; set; }
        public string CurrentStatus { get; set; }
        public string ResetKey { get; set; }
        public Nullable<bool> IsDeleted { get; set; }
    }
}
