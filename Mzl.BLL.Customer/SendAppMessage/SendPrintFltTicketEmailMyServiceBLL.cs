using Mzl.IBLL.Customer.SendAppMessage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mzl.DomainModel.Customer.SendAppMessage;
using Mzl.Framework.Base;
using Mzl.Common.ConfigHelper;
using Mzl.IDAL.Customer.Customer;
using Mzl.Common.EmailHelper;
using Mzl.IDAL.Customer.DAL;
using Mzl.EntityModel.Customer.BaseInfo;
using Mzl.EntityModel.Customer.Corporation.Corp;
using Mzl.EntityModel.Customer.AppClient;

namespace Mzl.BLL.Customer.SendAppMessage
{
    public class SendPrintFltTicketEmailMyServiceBLL : BaseServiceBll, ISendPrintFltTicketEmailMyServiceBLL
    {
        private readonly SendAppMessageFactory _sendAppMessageFactory;
        //private readonly ICustomerInfoDAL _customerInfoDal;
        //private readonly ICorporationDAL _corporationDal;
        private static string _isService = AppSettingsHelper.GetAppSettings(AppSettingsEnum.IsServer);

        public SendPrintFltTicketEmailMyServiceBLL(ISendAppMessageDal sendAppMessageDal,
            ISendAppMessageBll sendAppMessageBll, ICustomerAppClientIdDal customerAppClientIdDal)
        {
            _sendAppMessageFactory = new SendAppMessageFactory(sendAppMessageDal, sendAppMessageBll, customerAppClientIdDal);
            //_customerInfoDal = customerInfoDal;
            //_corporationDal = corporationDal;
        }
        public List<SendAppMessageModel> Get()
        {
            return _sendAppMessageFactory.GetSendAppMessage(Common.EnumHelper.SendAppMessageTypeEnum.SendRunPrintFltTicketEmail);
        }

        public void Send(List<SendAppMessageModel> sendAppMessageModels)
        {
            string isServer = AppSettingsHelper.GetAppSettings(AppSettingsEnum.IsServer);
            foreach (var item in sendAppMessageModels)
            {
                string title = "差旅订单出票提醒";
                //CustomerInfoEntity customerInfoEntity = _customerInfoDal.GetCustomerByExpression(x => x.Cid == item.Cid);
                //CorporationEntity corporationEntity = _corporationDal.GetContactInfoByExpression(x => x.CorpId == customerInfoEntity.CorpID);
                string content = item.SendContent;
                //得到公司名称
                
                string url = string.Format(
                    "http://192.168.1.117/orderprocess/Flt_order.asp?orderid={0}",
                    item.OrderId);
                if (isServer == "T")
                {
                    url = string.Format("http://192.168.1.188/orderprocess/Flt_order.asp?orderid={0}",
                        item.OrderId);
                }
                string aurl = "<a href=\"" + url + "\">" + item.OrderId + "</a>";
                content = content.Replace(item.OrderId.ToString(), aurl);

                bool result = EmailHelper.SendEmail("", title, null, null, content, item.Email);
                item.SendResult = result.ToString();
            }
            _sendAppMessageFactory.SendAppMessageStatuAll(sendAppMessageModels);
            // LogHelper.WriteLog("机票出票邮件推送:result=" + result + "||||||" + html.ToString() + "||||||toEmail=" + toEmail + "|||||orderId=" + orderId, "EmailLog");
        }

    }
}
