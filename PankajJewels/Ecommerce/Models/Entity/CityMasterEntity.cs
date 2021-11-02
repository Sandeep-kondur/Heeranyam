using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Ecommerce.Models.Entity
{
    public class CityMasterEntity
    {
        [Key]
        public int Id { get; set; }

        public string CityName { get; set; }

        public string Langitude { get; set; }

        public string Latitude { get; set; }

        public int? StateId { get; set; }

        public string PostalCode { get; set; }

        public bool? IsDeleted { get; set; }
    }
}
