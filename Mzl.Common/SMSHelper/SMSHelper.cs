using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mzl.Common
{
    /// <summary>
    /// 发送短信
    /// </summary>
    public class SMSHelper
    {
        /// <summary>
        /// 发送短信
        /// 
        /// 发送类型，填发送验证码等
        /// </summary>
        /// <param name="mobile">手机号</param>
        /// <param name="message">信息</param>
        /// <param name="sendType">发送类型</param>
        public static void SMSSendMessage(string mobile, string message, string sendType) {
            SMSWebService.SMSSendSoapClient client = new SMSWebService.SMSSendSoapClient();
            client.SMSSendMessage(new SMSWebService.P_SendMessageEntity() { IsMass = false, Mobile = mobile,  MessageBody = message, SendOid = "SYS", OrderID = 0, SendDevice = "CYD", SendTime = DateTime.Now, orderType = "SIG", Port = 0, SendType = sendType });
        }
    }
}
