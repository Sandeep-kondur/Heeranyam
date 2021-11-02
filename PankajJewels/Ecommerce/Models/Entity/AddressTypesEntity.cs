using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Ecommerce.Models.Entity
{
    public class AddressTypesEntity
    {
        [Key]
        public int Id { get; set; }
        public string AddressTypeName { get; set; }
        public bool? IsDeleted { get; set; }
    }
}
