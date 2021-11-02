using Ecommerce.Models.Entity;
using Ecommerce.Models.InterfacesBAL;
using Ecommerce.Models.ModelClasses;
using Microsoft.Extensions.Configuration;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using static Ecommerce.Models.Utilities.AppSettings;

namespace Ecommerce.Models.BAL
{
    public class NotificationService : INotificationService
    {
        private readonly MyDbContext context;
        private readonly IConfiguration _config;
      
        public NotificationService(IConfiguration config, MyDbContext context)
        {
            _config = config;
            this.context = context;
        }

        public bool PushEmail(string emailtext, string to, string subject, string cc = "")
        {
            bool res = false;
            try
            {

                string emailUrl = _config.GetValue<string>("EmailConfig:EMAILIMAGEURL");
                string address1 = _config.GetValue<string>("EmailConfig:emailAddress1");
                string address2 = _config.GetValue<string>("EmailConfig:emailAddress2");
                string mobile = _config.GetValue<string>("EmailConfig:emailPhone");
                emailtext = emailtext.Replace("##EMAILIMAGEURL##", mobile);
                emailtext = emailtext.Replace("##ADDRESS1##", address1);
                emailtext = emailtext.Replace("##ADDRESS2##", address2);
                emailtext = emailtext.Replace("##MOBILE##", mobile);

                string smtpserver = _config.GetValue<string>("EmailConfig:smtpServer");
                string smtpUsername = _config.GetValue<string>("EmailConfig:smtpEmail");
                string smtpPassword = _config.GetValue<string>("EmailConfig:smtppassword");
                int smtpPort = _config.GetValue<int>("EmailConfig:portNumber");
                MailMessage msg = new MailMessage(smtpUsername, to, subject, emailtext);

                MailMessage mail = new MailMessage();
                mail.To.Add(to);
                mail.From = new MailAddress(smtpUsername);
                mail.Subject = subject;
                mail.Body = emailtext;
                mail.IsBodyHtml = true;
                SmtpClient smtp = new SmtpClient();
                smtp.Host = smtpserver;
                smtp.Port = smtpPort;
                smtp.UseDefaultCredentials = false;
                smtp.Credentials = new System.Net.NetworkCredential(smtpUsername, smtpPassword);
                smtp.EnableSsl = true;
              
                try
                {
                    smtp.Send(mail);
                    res = true;
                }
                catch (Exception ex)
                {
                    res = false;
                }



            }
            catch (Exception ex)
            {
                // LogException.Record(ex);
                res = false;

            }
            return res;
        }

        public bool SentTextSms(string phoneNumber, string message, string countrycode)
        {
            bool res = false;
            try
            {
                string baseurl = _config.GetValue<string>("SMSConfig:smsBaseUrl");
                string authkey = _config.GetValue<string>("SMSConfig:smsAuthKey");
                string senderId = _config.GetValue<string>("SMSConfig:smsSenderId");

                string url = string.Empty;
                if (countrycode != "91")
                {
                    url = baseurl + "auth=" + authkey + "&msisdn=" + phoneNumber + "&countrycode=" + countrycode + "&senderid=" + senderId + "&message=" + message;
                }
                else
                {
                    url = baseurl + "auth=" + authkey + "&msisdn=" + phoneNumber + "&senderid=" + senderId + "&message=" + message;
                }

                //WebClient client = new WebClient();
                //Stream data = client.OpenRead(baseurl);
                //StreamReader reader = new StreamReader(data);
                //string s = reader.ReadToEnd();
                //data.Close();
                //reader.Close();

                var client = new RestClient(url);
                var request = new RestRequest(Method.POST);
                request.AddHeader("cache-control", "no-cache");
                IRestResponse response = client.Execute(request);
                res = true;
            }
            catch (Exception ex)
            {
                // LogException.Record(ex);
                res = false;
            }

            return res;
        }

        public EmailTemplateEntity GetEmailTemplateByModule(string modulename)
        {
            EmailTemplateEntity response = new EmailTemplateEntity();
            response = context.emailTemplateEntities.Where(a => a.ModuleName == modulename).FirstOrDefault();
            return response;
        }


        public ProcessResponse SendResetPasswordEmail(string moduleName, string key, string toEamil, string userName,
           int userId)
        {
            ProcessResponse ps = new ProcessResponse();
            EmailTemplateEntity template = new EmailTemplateEntity();
            template = GetEmailTemplateByModule(moduleName);
            if (template != null)
            {
                string HostURL = _config.GetValue<string>("OtherConfig:WebHostURL");
                string emailCC = _config.GetValue<string>("OtherConfig:EmailCC");

                string emailText = template.EmailTemplate;
                emailText = emailText.Replace("##USERNAME##", userName);
                emailText = emailText.Replace("##KEY##", " :  " + key);
                bool res = PushEmail(emailText, toEamil, template.Subject, emailCC);
                if (res == false)
                {
                    ps.statusMessage = "failed to send email";
                    ps.statusCode = 0;
                }
                else
                {
                    ps.statusMessage = "email sent";
                    ps.statusCode = 1;
                }

            }
            return ps;

        }

        public ProcessResponse SendRegistrationEmail(string moduleName, string toEamil, string userName,
            int userId)
        {
            ProcessResponse ps = new ProcessResponse();
            try
            {
                EmailTemplateEntity emailTemplate = new EmailTemplateEntity();
                emailTemplate = GetEmailTemplateByModule(moduleName);
                if (emailTemplate != null)
                {

                    string HostURL = _config.GetValue<string>("OtherConfig:WebHostURL");
                    UserVerificationEntity userVerification = new UserVerificationEntity();
                    string keyRegistration = string.Empty;
                    keyRegistration = DateTime.UtcNow.ToString();
                    keyRegistration = Regex.Replace(keyRegistration, @"[\[\]\\\^\$\.\|\?\*\+\(\)\{\}%,;: ><!@#&\-\+\/]", "");
                    keyRegistration += userId.ToString();

                    userVerification.ActivationKey = keyRegistration;
                    userVerification.ActivationURL = HostURL + "/Authenticate/Activate?key=" + keyRegistration;
                    userVerification.DOR = DateTime.UtcNow;
                    userVerification.Status = "Draft";
                    userVerification.UserID = userId;
                    context.userVerificationEntities.Add(userVerification);
                    context.SaveChanges();
                    string emailCC = _config.GetValue<string>("OtherConfig:EmailCC");
                    string emailText = emailTemplate.EmailTemplate;
                    emailText = emailText.Replace("##USERNAME##", userName);
                   // emailText = emailText.Replace("##URL##", userVerification.ActivationURL);
                    bool res = PushEmail(emailText, toEamil, emailTemplate.Subject, emailCC);
                    ps.statusMessage = "email sent";
                    ps.statusCode = 1;


                }
            }
            catch (Exception ex)
            {

                ps.statusMessage = ex.Message;
                ps.statusCode = 0;
            }

            return ps;

        }

        public ProcessResponse SendOrderCreatedEmail(POMasterEntity po)
        {
            ProcessResponse ps = new ProcessResponse();
            try
            {
                EmailTemplateEntity emailTemplate = new EmailTemplateEntity();
                emailTemplate = GetEmailTemplateByModule(EmailTemplateModules.OrderCreated);
                if (emailTemplate != null)
                {


                    var customerData = context.userMasters.Where(a => a.UserId == po.UserId).FirstOrDefault();
                    
                    string adminemail = _config.GetValue<string>("EmailConfig:adminemail");
                    string emailCC = _config.GetValue<string>("OtherConfig:EmailCC");
                    string emailText = emailTemplate.EmailTemplate;
                    string emailTemplatecustomer = emailTemplate.EmailTemplate;
                    string emailTextCustomer = "Hi " + customerData.UserName + ", <br><strong>Thank you for placing order with Heeranyam. <br/> Our team will contact you soon!";
                    emailTextCustomer += "<br/><br/>PO Number : <strong>" + po.PONumber + "</strong>";
                    emailTextCustomer += "<br/><br/>Order Value : <strong>" + po.PaidAmount + "</strong>";
                    emailTextCustomer += "<br/> <strong>Team Heeranyam </strong";
                    emailTemplatecustomer  = emailTemplatecustomer.Replace("##MAINTAGLINE##", emailTextCustomer);
                    // email to customer
                    bool res = PushEmail(emailTemplatecustomer, customerData.EmailId, emailTemplate.Subject, emailCC);
                    // email to admin 
                    string emailTemplateAdmin = emailTemplate.EmailTemplate;
                    string emailTextAdmin = "Hi, An order placed by " + customerData.UserName + ", <br> Check in the admin panel and acknowledge the the customer";
                    emailTemplateAdmin = emailTextAdmin.Replace("##MAINTAGLINE##", emailTextAdmin);
                    bool res1 = PushEmail(emailTemplateAdmin, adminemail, emailTemplate.Subject, emailCC);

                    ps.statusMessage = "email sent";
                    ps.statusCode = 1;


                }
            }
            catch (Exception ex)
            {

                ps.statusMessage = ex.Message;
                ps.statusCode = 0;
            }

            return ps;

        }

        public ProcessResponse SendOrderUpdateEmail(int userId, int poid, string updatestatus)
        {
            ProcessResponse ps = new ProcessResponse();
            try
            {
                EmailTemplateEntity emailTemplate = new EmailTemplateEntity();
                emailTemplate = GetEmailTemplateByModule(EmailTemplateModules.OrderUpdate);
                if (emailTemplate != null)
                {


                    var customerData = context.userMasters.Where(a => a.UserId == userId).FirstOrDefault();

                    string adminemail = _config.GetValue<string>("EmailConfig:adminemail");
                    string emailCC = _config.GetValue<string>("OtherConfig:EmailCC");

                    string emailText = emailTemplate.EmailTemplate;
                    string emailTemplatecustomer = emailTemplate.EmailTemplate;
                    string emailTextCustomer = "Hi " + customerData.UserName + ", <br><strong>Your order status updated to <strong>" + updatestatus + "!</strong>";
                    emailTextCustomer += "<br/> <strong>Team Heeranyam </strong";
                    emailTemplatecustomer = emailTemplatecustomer.Replace("##MAINTAGLINE##", emailTextCustomer);
                    // email to customer
                    bool res = PushEmail(emailTemplatecustomer, customerData.EmailId, emailTemplate.Subject, emailCC);
                    // email to admin 
                    //string emailTemplateAdmin = emailTemplate.EmailTemplate;
                    //string emailTextAdmin = "Hi, An order placed by " + customerData.UserName + ", <br> Check in the admin panel and acknowledge the the customer";
                    //emailTextAdmin = emailTextAdmin.Replace("##MAINTAGLINE##", emailTextCustomer);
                    //bool res1 = PushEmail(emailTemplateAdmin, adminemail, emailTemplate.Subject, emailCC);

                    ps.statusMessage = "email sent";
                    ps.statusCode = 1;


                }
            }
            catch (Exception ex)
            {

                ps.statusMessage = ex.Message;
                ps.statusCode = 0;
            }

            return ps;

        }
        public POMasterEntity GetPoMasterById(int id)
        {
            return context.pOMasterEntities.Where(a => a.POId == id).FirstOrDefault();
        } 
        public PODetailsEntity GetPoDetailById(int id)
        {
            return context.pODetails.Where(a => a.PODetailId == id).FirstOrDefault();
        }
        public PODetailsEntity GetPoDetailByMasterIdId(int id)
        {
            return context.pODetails.Where(a => a.POMasterId == id).FirstOrDefault();
        }

    }
}
