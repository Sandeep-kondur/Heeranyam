using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Ecommerce.Models.Entity
{
    public class StateMasterEntity
    {
        [Key]
        public int Id { get; set; }
        public string StateName { get; set; }
        public string StateCode { get; set; }
        public Nullable<int> CountryId { get; set; }
        public Nullable<bool> IsDeleted { get; set; }
    }
}
