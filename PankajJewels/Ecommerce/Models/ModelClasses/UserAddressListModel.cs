using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ecommerce.Models.ModelClasses
{
    public class UserAddressListModel
    {
        public int Id { get; set; }
        public int? AddressTypeId { get; set; }
        public string AddressTypeId_Name { get; set; }
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public string LocationStreet { get; set; }
        public string LandMark { get; set; }
        public int? CityId { get; set; }
        public string CityId_Name { get; set; }
        public int? StateId { get; set; }
        public string StateId_Name { get; set; }
        public int? CountryId { get; set; }
        public string CountryId_Name { get; set; }
        public bool? IsDeleted { get; set; }
    }
}
