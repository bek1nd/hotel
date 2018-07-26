using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mzl.Proxy.Hotel.Elong.Configuraton
{
    public class ApiGatewayConfig
    {

        public static string URL = System.Configuration.ConfigurationManager.AppSettings["ELONG_BASE_URL"];
        public static string URL_HTTPS = System.Configuration.ConfigurationManager.AppSettings["ELONG_BASE_URL_HTTPS"];
        public static string URL_STATIC = System.Configuration.ConfigurationManager.AppSettings["ELONG_BASE_URL_STATIC"];

        public static string APIUSER = System.Configuration.ConfigurationManager.AppSettings["ELONG_APIUSER"];
        public static string APPKEY = System.Configuration.ConfigurationManager.AppSettings["ELONG_APPKEY"];
        public static string SECRETKEY = System.Configuration.ConfigurationManager.AppSettings["ELONG_SECRETKEY"];
    }
}
