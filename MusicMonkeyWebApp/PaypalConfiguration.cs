using PayPal.Api;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MusicMonkeyWebApp
{
    public class PaypalConfiguration
    {
        public readonly static string clientId;
        public readonly static string clientSecret;
        

        static PaypalConfiguration()
        {
            var config = getconfig();
            clientId = "AdoqnTlAcwKRD3ALvDg7v81fDpZA6ohA36ShWeKak6tc8axH72BytC4yjRiaYtFpaVftKiftyvMESgTC";
            clientSecret = "ECghiIp9-anN-ltXC5gs3JuqCRG3urIU3faz4HIQzDJ1_GdEwdCW5RYx6VCYNlq3d-AAByoQKsPccf6l";
        }

        private static Dictionary<string,string> getconfig()
        {
            return PayPal.Api.ConfigManager.Instance.GetProperties();
        }

        private static string GetAccessToken()
        {
            string accessToken = new OAuthTokenCredential(clientId, clientSecret, getconfig()).GetAccessToken();
            return accessToken;
        }

        public static APIContext GetAPIContext()
        {
            APIContext apicontext = new APIContext(GetAccessToken());
            apicontext.Config = getconfig();
            return apicontext;
        }
    }
}