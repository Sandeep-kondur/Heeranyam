using Ecommerce.Models.Entity;
using Ecommerce.Models.ModelClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ecommerce.Models.InterfacesBAL
{
    public interface INotificationService
    {
        ProcessResponse SendOrderUpdateEmail(int userId, int poid, string updatestatus);
        bool PushEmail(string emailtext, string to, string subject, string cc = "");

        bool SentTextSms(string phoneNumber, string message, string countrycode);

        EmailTemplateEntity GetEmailTemplateByModule(string modulename);
        ProcessResponse SendResetPasswordEmail(string moduleName, string key, string toEamil, string userName,
           int userId);

        ProcessResponse SendRegistrationEmail(string moduleName, string toEamil, string userName,
            int userId);
        ProcessResponse SendOrderCreatedEmail(POMasterEntity po);
    }
}
