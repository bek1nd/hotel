using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mzl.Common.ConfigHelper;
using Mzl.Common.EmailHelper;
using Mzl.Common.EnumHelper;
using Mzl.Common.LogHelper;
using Mzl.DomainModel.Customer.SendAppMessage;
using Mzl.EntityModel.Customer.BaseInfo;
using Mzl.Framework.Base;
using Mzl.IBLL.Customer.SendAppMessage;
using Mzl.IDAL.Customer.Customer;

namespace Mzl.BLL.Customer.SendAppMessage
{
    internal class SendPrintFltTicketEmailServiceBll: BaseServiceBll,ISendPrintFltTicketEmailServiceBll
    {
        private readonly SendAppMessageFactory _sendAppMessageFactory;
        private static string _isService= AppSettingsHelper.GetAppSettings(AppSettingsEnum.IsServer);

        public SendPrintFltTicketEmailServiceBll(ISendAppMessageDal sendAppMessageDal,
            ISendAppMessageBll sendAppMessageBll, ICustomerAppClientIdDal customerAppClientIdDal)
        {
            _sendAppMessageFactory = new SendAppMessageFactory(sendAppMessageDal, sendAppMessageBll,
                customerAppClientIdDal);
        }

        public List<SendAppMessageModel> Get()
        {
            return _sendAppMessageFactory.GetSendAppMessage(SendAppMessageTypeEnum.SendPrintFltTicketEmail);
        }

        public void Send(List<SendAppMessageModel> sendAppMessageModels)
        {
            if (sendAppMessageModels == null || sendAppMessageModels.Count == 0)
            {
                return;
            }

            foreach (var sendAppMessageModel in sendAppMessageModels)
            {
                if (!string.IsNullOrEmpty(sendAppMessageModel.Email) &&
                    !string.IsNullOrEmpty(sendAppMessageModel.SendContent))
                {
                    string title = "机票出票通知";
                    if (sendAppMessageModel.SendAppMessageType == SendAppMessageTypeEnum.SendRunPrintFltTicketEmail)
                    {
                        title = sendAppMessageModel.EmailTitle;
                    }
                    SendEmail(sendAppMessageModel.SendContent, sendAppMessageModel.Email, sendAppMessageModel.OrderId, title);
                }
            }
        }

        private void SendEmail(string content,string toEmail,int orderId,string title= "机票出票通知")
        {
            if (_isService == "F")
                toEmail = "zengc@mojory.cn";

            StringBuilder html = new StringBuilder();
            html.Append("<!DOCTYPE html>");
            html.Append("<html lang=\"zh\">");
            html.Append("<head>");
            html.Append("<meta charset=\"UTF - 8\" />");
            html.Append("<meta name=\"viewport\" content=\"width = device - width, initial - scale = 1.0\" />");
            html.Append("<meta http-equiv=\"X - UA - Compatible\" content=\"ie = edge\" />");
            html.Append("</head>");
            html.Append("<body>");

            html.Append(content);

            html.Append("</body>");
            html.Append("</html>");

            bool result = EmailHelper.SendEmail("", title, null, null, html.ToString(), toEmail);

            LogHelper.WriteLog("机票出票邮件推送:result=" + result + "||||||" + html.ToString()+ "||||||toEmail=" + toEmail+ "|||||orderId="+ orderId, "EmailLog");

        }
    }
}
