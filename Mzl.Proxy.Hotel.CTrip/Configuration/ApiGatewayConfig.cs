using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mzl.Proxy.Hotel.CTrip.Configuration
{
    public class ApiGatewayConfig
    {
        public static string TOKEN_BASE_URL = "http://openservice.open.uat.ctripqa.com/openserviceauth/authorize.ashx";
        public static string REFRESH_BASE_URL = "http://openservice.open.uat.ctripqa.com/openserviceauth/refresh.ashx";
        public static string SERVICE_BASE_URL = "http://openservice.open.uat.ctripqa.com/openservice/serviceproxy.ashx";

        public static string AID = "1";
        public static string SID = "50";
        public static string KEY = "123456789";
        public static string UUID = "f71dee19-9e09-42d9-a39c-40757d9d76e4";
        public static string MODE = "1";
        public static string FORMAT = "JSON";


        //public static string TOKEN_BASE_URL = System.Configuration.ConfigurationManager.AppSettings["TOKEN_BASE_URL"];
        //public static string REFRESH_BASE_URL = System.Configuration.ConfigurationManager.AppSettings["Refresh_BASE_URL"];
        //public static string SERVICE_BASE_URL = System.Configuration.ConfigurationManager.AppSettings["SERVICE_BASE_URL"];

        //public static string AID = System.Configuration.ConfigurationManager.AppSettings["AID"];
        //public static string SID = System.Configuration.ConfigurationManager.AppSettings["SID"];
        //public static string KEY = System.Configuration.ConfigurationManager.AppSettings["KEY"];
        //public static string UUID = System.Configuration.ConfigurationManager.AppSettings["UUID"];
        //public static string MODE = System.Configuration.ConfigurationManager.AppSettings["MODE"];
        //public static string FORMAT = System.Configuration.ConfigurationManager.AppSettings["FORMAT"];


        public static IDictionary<string, string> ICODE =

        new Dictionary<string, string>
        {
            {"HotelIdListReqEntity",System.Configuration.ConfigurationManager.AppSettings["HotelIdList"]},
            {"HotelDesInfoReqEntity","62a8bb573582435bbe8b361334efe36f"},
            {"RoomDesInfo" ,System.Configuration.ConfigurationManager.AppSettings["RoomDesInfo"]},
            {"ChangeInfo",System.Configuration.ConfigurationManager.AppSettings["ChangeInfo"] },
            {"RoomStatusChange",System.Configuration.ConfigurationManager.AppSettings["RoomStatusChange"] },
            {"LowPriceReqEntity","c659a717bf23422b907ff7f9c75022ed" }

        };

    }
}
