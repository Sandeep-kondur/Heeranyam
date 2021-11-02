using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ecommerce.Models.Utilities
{
    public static class StoredProcedures
    {
        public static string GetUserTypes = "usp_getusertypes";
        public static string GetUserByEmailId = "usp_GetUserByEmailId";
        public static string GEtDaimondDetailsPerProduct = "GEtDaimondDetailsPerProduct";
        public static string GetPerlPerProduct = "GetPerlPerProduct";
        public static string GetSRubyDetailsPerProduct = "GetSRubyDetailsPerProduct";
        public static string GetSolitairePerPrd = "GetSolitairePerPrd";
    }
}
