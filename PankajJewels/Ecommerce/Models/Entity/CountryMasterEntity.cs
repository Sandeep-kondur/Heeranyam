using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Ecommerce.Models.Entity
{
    public class CountryMasterEntity
    {
        [Key]
        public int Id { get; set; }
        public string CountryName { get; set; }
        public string CountryCode { get; set; }
        public string CurrenceString { get; set; }
        public string PhoneCode { get; set; }
        public Nullable<bool> IsDeleted { get; set; }
    }
}
