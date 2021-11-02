using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ecommerce.Models.Utilities
{
    public static class AppSettings
    {
        public const string AppName = "OTS";
        public const string UserToken = "UserToken";

       

        public static class FlightApis
        {
            public static string GetAgencyBalance = "http://api.tektravels.com/SharedServices/SharedData.svc/rest/GetAgencyBalance";
            public static string SearchFlights = "http://api.tektravels.com/BookingEngineService_Air/AirService.svc/rest/Search";
            public static string PricePBDSearch = "http://api.tektravels.com/BookingEngineService_Air/AirService.svc/rest/PriceRBD";
            public static string GetCalenderFare = "http://api.tektravels.com/BookingEngineService_Air/AirService.svc/rest/GetCalendarFare";
            public static string UpdateCalenderFare = "http://api.tektravels.com/BookingEngineService_Air/AirService.svc/rest/UpdateCalendarFareOfDay";
            public static string GetFareRule = "http://api.tektravels.com/BookingEngineService_Air/AirService.svc/rest/FareRule";
            public static string GetFareQuote = "http://api.tektravels.com/BookingEngineService_Air/AirService.svc/rest/FareQuote";
            public static string GetSSR = "http://api.tektravels.com/BookingEngineService_Air/AirService.svc/rest/SSR";
            public static string TicketReIssue = "http://api.tektravels.com/BookingEngineService_Air/AirService.svc/rest/TicketReIssue";
            public static string Book = "http://api.tektravels.com/BookingEngineService_Air/AirService.svc/rest/Book";
            public static string Ticket = "http://api.tektravels.com/BookingEngineService_Air/AirService.svc/rest/Ticket";
            public static string GetBookingDetails = "http://api.tektravels.com/BookingEngineService_Air/AirService.svc/rest/GetBookingDetails";
            //for cancellation 
            public static string ReleasePNRRequest = "http://api.tektravels.com/BookingEngineService_Air/AirService.svc/rest/ReleasePNRRequest";
            public static string CancelTicketBooking = "http://api.tektravels.com/BookingEngineService_Air/AirService.svc/rest/SendChangeRequest";
            public static string CancelStatus = "http://api.tektravels.com/BookingEngineService_Air/AirService.svc/rest/GetChangeRequestStatus";
            public static string GetCancelCharges = "http://api.tektravels.com/BookingEngineService_Air/AirService.svc/rest/GetCancellationCharges";





        }

        public static class FJourneyTipes
        {
            public static string OneWay = "1";
            public static string Return = "2";
            public static string MultiStop = "3";
            public static string AdvanceSearch = "4";
            public static string SpecialReturn = "5";
        }
        public static class FlightCabinClass
        {
            public static string All = "1";
            public static string Economy = "2";
            public static string PremiumEconomy = "3";
            public static string Business = "4";
            public static string PremiumBusiness = "5";
            public static string First = "6";
        }
        public static class Ids
        {
            public const string PricingStrategieId = "PricingStrategieId";
            public const string UserDetailsId = "PricingStrategieId";
            public const string CouponCodeId = "CouponCodeId";
            public const string CandidateProfileDetailId = "CandidateProfileDetailId";
            public const string CandidateProfileMasterId = "CandidateProfileMasterId";
            public const string CompanyDetailsId = "CompanyDetailsId";
            public const string Name = "Name";
        }

        public static class RolesId
        {
            public const string UserRoleId = "ff53758e-270e-4c78-bc59-780d63eb3169";
        }

        public static class Roles
        {
            public const string Admin = "admin";
            public const string User = "user";
        }

        
        public static class TimeZones
        {
            public const string EST = "EST";
            public const string CST = "CST";
            public const string MST = "MST";
            public const string PST = "PST";
        }

       

        public static class Functions
        {
            public const string CheckCompanyExists = "dbo.checkcompanyexists";
            public const string GetUserTypeById = " usp_getusertypebyid(@id)";
            public const string GetAllUserTypes = " usp_getusertypes";
            public const string GetIATACodesSearch = " usp_GetIATACodesBySearch(@city,@country)";



        }

        public static class EmailTemplateModules
        {
            public static string RegistrationEmail = "Registration";
            public static string InviteFriends = "InviteFriends";
            public static string InviteToGroup = "InviteToGroup";
            public static string ResetPassword = "ResetPassword";
            public static string InviteToEvent = "InviteToEvent";
            public static string OrderCreated = "OrderCreated";
            public static string OrderUpdate = "OrderUpdate";
        }

        public static string[] OpenOrderStatus = new string[] {
            "Open",
            "Making in Progress",
            "Packing in Progress",
            "Dispatched"
        };


    }
}