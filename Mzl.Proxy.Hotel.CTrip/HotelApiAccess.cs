using Mzl.Common.LogHelper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mzl.Common.JsonHelper;
using Mzl.Common.PostHelper;
using Mzl.Proxy.Hotel.CTrip.Configuration;
using Mzl.EntityModel.Proxy.CTripHotel;
using System.Net;
using System.IO;
using Mzl.EntityModel.Proxy.CTripHotel.RoomStatusChange;

namespace Mzl.Proxy.Hotel.CTrip
{
    public class HotelApiAccess
    {
        public static string Query<T>(T req, string mtd)
        {
            return RequestInterface<T>(req, mtd);
        }
        public static string QueryStr<T>(T req)
        {
            return RequestInterface<T>(req, typeof(T).Name);
        }

        public static TRes QueryObj<TReq, TRes>(TReq req) where TRes : class
        {
            string res = RequestInterface(req, typeof(TReq).Name);
            if(string.IsNullOrEmpty(res))
            {
                return null;
            }
            else
            {
                return JsonHelper.DeserializeJsonToObject<TRes>(res);
            }
        }

        public static string RequestInterface<T>(T req, string mtd)
        {
            var tokenStr = Token.GetToken();
            var url = ApiGatewayConfig.SERVICE_BASE_URL
                      + "?AID=" + ApiGatewayConfig.AID
                      + "&SID=" + ApiGatewayConfig.SID
                      + "&ICODE=" + ApiGatewayConfig.ICODE[mtd]
                      + "&UUID=" + ApiGatewayConfig.UUID
                      + "&Token=" + tokenStr
                      + "&mode=" + ApiGatewayConfig.MODE
                      + "&format=" + ApiGatewayConfig.FORMAT;
           
            return Post(JsonHelper.SerializeObject(req), url);
        }

        public static string Post(string postData, string url)
        {
            string result = "";

            HttpWebRequest req = (HttpWebRequest)WebRequest.Create(url);

            req.Method = "POST";

            req.ContentType = "application/json";

            byte[] data = Encoding.UTF8.GetBytes(postData);

            req.ContentLength = data.Length;

            using (Stream reqStream = req.GetRequestStream())
            {
                reqStream.Write(data, 0, data.Length);

                reqStream.Close();
            }

            HttpWebResponse resp = (HttpWebResponse)req.GetResponse();

            Stream stream = resp.GetResponseStream();
            using (StreamReader reader = new StreamReader(stream, Encoding.UTF8))
            {
                result = reader.ReadToEnd();
            }
            return result;
        }
    }
}
