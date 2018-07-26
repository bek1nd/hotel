using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Web.Http;
using Mzl.Common.EmailHelper;
using Mzl.IApplication.Common;
using Mzl.IApplication.Customer;

namespace Mzl.Mojory.WebApi.Controllers.Common
{
    /// <summary>
    /// 推送app消息
    /// </summary>
    [AllowAnonymous]
    public class SendAppMessageController : ApiController
    {
        private readonly ISendAppMessageApplication _sendAppMessageApplication;

        public SendAppMessageController(ISendAppMessageApplication sendAppMessageApplication)
        {
            _sendAppMessageApplication = sendAppMessageApplication;
        }
        /// <summary>
        /// 推送app消息
        /// </summary>
        [HttpGet]
        public string SendAppMessage()
        {
            _sendAppMessageApplication.SendMessage();
            return "ok";
        }
        /// <summary>
        /// 发送邮件
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public bool SendEmail()
        {
            StringBuilder html = new StringBuilder();
            html.Append("<!DOCTYPE html>");
            html.Append("<html lang=\"zh\">");
            html.Append("<head>");
            html.Append("<meta charset=\"UTF - 8\" />");
            html.Append("<meta name=\"viewport\" content=\"width = device - width, initial - scale = 1.0\" />");
            html.Append("<meta http-equiv=\"X - UA - Compatible\" content=\"ie = edge\" />");
            html.Append("</head>");
            html.Append("<body>");

            html.Append("<P>徐佳颖：</P>");
            html.Append("<P>您好！</P>");

            html.Append("</body>");
            html.Append("</html>");

            string content = @"徐佳颖：

                                            您好！
                                            徐XX：211022XXXX08095112已成功预订! 
                                            行程：9C8840沈阳桃仙T3-上海浦东T2
                                            出行时间： 5月13日10:10起飞12:50到达
                                            价格：900元
                                            温馨提醒：请提前90分钟到达机场,祝您一路平安,旅途愉快！
                                            ";
            bool flag=EmailHelper.SendEmail("", "机票出票通知", null, null, html.ToString(), "1728739029@qq.com");
            flag = EmailHelper.SendEmail("", "机票出票通知", null, null, html.ToString(), "qyz@mojory.cn");

            return flag;
        }
    }
}
