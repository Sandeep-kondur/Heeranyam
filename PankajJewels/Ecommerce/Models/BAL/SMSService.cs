using Ecommerce.Models.InterfacesBAL;
using Ecommerce.Models.ModelClasses;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ecommerce.Models.BAL
{
    public class SMSService : ISMSService
    {

        public ProcessResponse SentTextSms(string phoneNumber, string message, string countrycode)
        {
            ProcessResponse response = new ProcessResponse();
            try
            {
                string baseurl = "https://api.datagenit.com/sms?";
                string authkey = "D!~6923uVFvmv3JIa";
                string senderId = "BOAFLT";

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
                IRestResponse restResponse = client.Execute(request);

                response.statusCode = 1;
                response.statusMessage = "Success";
            }
            catch (Exception ex)
            {

                response.statusCode = 0;
                response.statusMessage = "Failed";
            }
            return response;
        }
    }
}
