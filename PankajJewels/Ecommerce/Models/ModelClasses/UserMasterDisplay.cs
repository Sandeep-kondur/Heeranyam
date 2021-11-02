using Ecommerce.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ecommerce.Models.ModelClasses
{
    public class UserMasterDisplay
    {
        public int UserId { get; set; }

        public string UserName { get; set; }

        public string EmailId { get; set; }

        public string PWord { get; set; }

        public string CnfPWord { get; set; }

        public string MobileNumber { get; set; }

        public string HomeNumber { get; set; }

        public string BusniessNumber { get; set; }
        public string BusinessName { get; set; }
        public string AddressLine1 { get; set; }

        public string AddressLine2 { get; set; }

        public string CityName { get; set; }

        public int? StateId { get; set; }

        public decimal? currentCredits { get; set; }

        public int? CountryId { get; set; }

        public string ZipCode { get; set; }

        public DateTime? RegisteredOn { get; set; }

        public DateTime? ActivatedOn { get; set; }

        public string CurrentStatus { get; set; }

        public int? UserTypeId { get; set; }
        public string UserTypeName { get; set; }
        public bool? IsEmailVerified { get; set; }

        public bool? IsDeleted { get; set; }
        public int? TotalOrders { set; get; }
        public int? CancelledOrders { get; set; }
        public int? TotalCredits { get; set; }
        public string StateName { get; set; }
        public string CountryName { get;  set; }
    }
}
