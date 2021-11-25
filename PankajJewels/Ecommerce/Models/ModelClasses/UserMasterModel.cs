using Ecommerce.Models.Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Ecommerce.Models.ModelClasses
{
    public class APIContactUs
    {
        public int ContactUsId { get; set; }
        public string Name { get; set; }
        public string MobileNumber { get; set; }
        public string Message { get; set; }
        public string Email { get; set; }
    }
    public class APIAddressEntity
    {
        [Key]
        public int Id { get; set; }
        public int? AddressTypeId { get; set; }
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public string LocationStreet { get; set; }
        public string LandMark { get; set; }
        public int? CityId { get; set; }
        public int? StateId { get; set; }
        public int? CountryId { get; set; }
        public bool? IsDeleted { get; set; }
        public string ZipCode { get; set; }
        public int? UserId { get; set; }
        public string IsDeliverAddress { get; set; }
    }
    public class APIUser {

        [Required(ErrorMessage = "User Name Required")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Email Id required")]
        [EmailAddress(ErrorMessage = "Invalid Email Id")]
        public string EmailId { get; set; }

        [Required(ErrorMessage = "Password Required")]
        public string PWord { get; set; }

        [Required(ErrorMessage = "Confirm password Required")]
        [Compare("PWord", ErrorMessage = "Password mismatch")]
        public string CnfPWord { get; set; }

        [Required(ErrorMessage = "Mobile Number required")]
        public string MobileNumber { get; set; }
        public DateTime? ActivatedOn { get; set; }
        public string CurrentStatus { get; set; }
        public int? UserTypeId { get; set; }
        public bool? IsEmailVerified { get; set; }
        public bool? IsDeleted { get; set; }
        public int Id { get; set; }
        public int? AddressTypeId { get; set; }
        
        public string LocationStreet { get; set; }
        
        public int? CityId { get; set; }
        public string CityName  { get; set; }
        public int? StateId { get; set; }
        public int? CountryId { get; set; }
        public List<CountryMasterEntity> countryList { get; set; }
        public List<StateMasterEntity> stateList { get; set; }
        public List<CityMasterEntity> cityList { get; set; }
        public List<AddressTypesEntity> addtypeList { get; set; }
        public DateTime RegisteredOn { get; set; }
        
        [Required(ErrorMessage = "TermsAndConditions Must be Selected")]
        public string TermsAndConditions { get; set; }
        public string DeviceId { get; set; }
        public string ProfilePicUrl  { get; set; }
        public string  Address { get; set; }
       
        
        public string Address1 { get; set; }
        public string Address2 { get; set; }
       
        public string LandMark { get; set; }
        
        public string ZipCode { get; set; }
        public int? UserId { get; set; }
        public string IsDeliverAddress { get; set; }

    }
    public class APIUserMasterModel
    {
        public int UserId { get; set; }

        [Required(ErrorMessage = "User Name Required")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Email Id required")]
        [EmailAddress(ErrorMessage = "Invalid Email Id")]
        public string EmailId { get; set; }

        [Required(ErrorMessage = "Password Required")]
        public string PWord { get; set; }

        [Required(ErrorMessage = "Confirm password Required")]
        [Compare("PWord", ErrorMessage = "Password mismatch")]
        public string CnfPWord { get; set; }

        [Required(ErrorMessage = "Mobile Number required")]
        public string MobileNumber { get; set; }
        public DateTime? ActivatedOn { get; set; }
        public string CurrentStatus { get; set; }
        public int? UserTypeId { get; set; }
        public bool? IsEmailVerified { get; set; }
        public bool? IsDeleted { get; set; }
        public int Id { get; set; }
        public int? AddressTypeId { get; set; }
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public string LocationStreet { get; set; }
        public string LandMark { get; set; }
        public int? CityId { get; set; }
        public int? StateId { get; set; }
        public int? CountryId { get; set; }
        public string ZipCode { get; set; }
        public List<CountryMasterEntity> countryList { get; set; }
        public List<StateMasterEntity> stateList { get; set; }
        public List<CityMasterEntity> cityList { get; set; }
        public List<AddressTypesEntity> addtypeList { get; set; }
        public DateTime RegisteredOn { get; set; }
        
        [Required(ErrorMessage = "TermsAndConditions Must be Selected")]
        public string TermsAndConditions { get; set; }
        public string DeviceId { get; set; }
        public string ProfilePicUrl  { get; set; }
        public string  Address { get; set; }

        public int Facebook { get; set; }
        public int Gmail { get; set; }

        public string OauthToken { get; set; }

    }
    public class UserMasterModel
    {
        public int UserId { get; set; }

        [Required(ErrorMessage = "User Name Required")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Email Id required")]
        [EmailAddress(ErrorMessage = "Invalid Email Id")]
        public string EmailId { get; set; }

        [Required(ErrorMessage = "Password Required")]
        public string PWord { get; set; }

        [Required(ErrorMessage = "Confirm password Required")]
        [Compare("PWord", ErrorMessage = "Password mismatch")]
        public string CnfPWord { get; set; }

        [Required(ErrorMessage = "Mobile Number required")]
        public string MobileNumber { get; set; }
        public DateTime? ActivatedOn { get; set; }

        public string CurrentStatus { get; set; }

        public int? UserTypeId { get; set; }

        public bool? IsEmailVerified { get; set; }
        public bool? IsDeleted { get; set; }
        public int Id { get; set; }
        public int? AddressTypeId { get; set; }
        [Required(ErrorMessage = "Address required")]
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public string LocationStreet { get; set; }
        [Required(ErrorMessage = "Landmark required")]
        public string LandMark { get; set; }
        public int? CityId { get; set; }
        public int? StateId { get; set; }
        public int? CountryId { get; set; }
       
        [Required(ErrorMessage = "Zip code required")]
        public string ZipCode { get; set; }
        public List<CountryMasterEntity> countryList { get; set; }
        public List<StateMasterEntity> stateList { get; set; }
        public List<CityMasterEntity> cityList { get; set; }
        public List<AddressTypesEntity> addtypeList { get; set; }
        public DateTime RegisteredOn { get;   set; }
        public int TermsAndConditions { get; set; }
    }
    public class UserMasterProfile
    {
        public int UserId { get; set; }

        [Required(ErrorMessage = "User Name Required")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Email Id required")]
        [EmailAddress(ErrorMessage = "Invalid Email Id")]
        public string EmailId { get; set; }

        [Required(ErrorMessage = "Mobile Number required")]
        public string MobileNumber { get; set; }
        public DateTime? ActivatedOn { get; set; }
        public string CurrentStatus { get; set; }
        public int? UserTypeId { get; set; }
        public bool? IsEmailVerified { get; set; }
        public bool? IsDeleted { get; set; }
        public DateTime? RegisteredOn { get; set; }
        public List<AddressProfileModel> addressList { get; set; }

    }
    public class AddressProfileModel
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
        public int UserId { get; set; }
        public string ZipCode { get; set; }
        public string IsDeliverAddress { get;   set; }
    }
    public class AddressModel
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int? AddressTypeId { get; set; }
        [Required(ErrorMessage = "Address required")]
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public string LocationStreet { get; set; }
        [Required(ErrorMessage = "Landmark required")]
        public string LandMark { get; set; }
        public int? CityId { get; set; }
        public string IsDeliverAddress { get; set; }
        public int? StateId { get; set; }
        public int? CountryId { get; set; }

        [Required(ErrorMessage = "Zip code required")]
        public string ZipCode { get; set; }
        public List<CountryMasterEntity> countryList { get; set; }
        public List<StateMasterEntity> stateList { get; set; }
        public List<CityMasterEntity> cityList { get; set; }
        public List<AddressTypesEntity> addtypeList { get; set; }
    }
}
