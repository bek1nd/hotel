using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mzl.Common.JsonHelper;
using Mzl.Common.PostHelper;
using Mzl.EntityModel.Proxy.CTripHotel;
using Mzl.Proxy.Hotel.CTrip.Configuration;

namespace Mzl.Proxy.Hotel.CTrip
{
    public class Token
    {
        private static string AccessToken { get; set; }
        private static string RefreshToken { get; set; }

        /// <summary>
        /// 上次刷新Access_Token的时间戳
        /// </summary>
        private static int AccesTokenTime { get; set; }

        /// <summary>
        /// 上次刷新Refresh_Token的时间戳
        /// </summary>
        private static int RefreshTokenTime { get; set; }

        public static string GetToken()
        {
            var timeStamp = GetTimeStamp();
            string tokenStr;
            if (AccesTokenTime != 0 && (timeStamp - AccesTokenTime) > 590 && (timeStamp - RefreshTokenTime) < 890)
            {
                tokenStr = GetHelper.GetUrl(ApiGatewayConfig.REFRESH_BASE_URL + "?AID="
                                     + ApiGatewayConfig.AID + "&SID=" + ApiGatewayConfig.SID
                                     + "&refresh_token=" + RefreshToken);
            }
            else
            {
                tokenStr = GetHelper.GetUrl(ApiGatewayConfig.TOKEN_BASE_URL + "?AID="
                                            + ApiGatewayConfig.AID + "&SID=" + ApiGatewayConfig.SID
                                            + "&KEY=" + ApiGatewayConfig.KEY);
            }
            ReturnToken rToken = JsonHelper.DeserializeJsonToObject<ReturnToken>(tokenStr);
            AccessToken = rToken.Access_Token;
            RefreshToken = rToken.Refresh_Token;
            AccesTokenTime = timeStamp;
            RefreshTokenTime = timeStamp;
            return AccessToken;
        }
        private static int GetTimeStamp()
        {
            var ts = DateTime.UtcNow - new DateTime(1970, 1, 1, 0, 0, 0, 0);
            return Convert.ToInt32(ts.TotalSeconds);
        }

    }
}
