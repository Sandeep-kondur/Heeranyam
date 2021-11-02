using Ecommerce.Models.ModelClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ecommerce.Models.InterfacesBAL
{
    public interface ISMSService
    {
        ProcessResponse SentTextSms(string phoneNumber, string message, string countrycode);
    }
}
