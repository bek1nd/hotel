using System;
using System.Collections.Generic;
using System.Linq;
using Mzl.Framework.Base;
using Mzl.IBLL.Customer.SendAppMessage;
using Mzl.IDAL.Customer.Customer;
using Mzl.EntityModel.Customer.AppClient;
using Mzl.Common.EnumHelper;
using Mzl.DomainModel.Customer.SendAppMessage;
using AutoMapper;

namespace Mzl.BLL.Customer.SendAppMessage
{
    /// <summary>
    /// 出票通知(机票，机票改签，火车，火车改签)推送App
    /// </summary>
    public class SendPrintTicketMessageServiceBll : BaseServiceBll, ISendPrintTicketMessageServiceBll
    {
        private readonly SendAppMessageFactory _sendAppMessageFactory;
        public SendPrintTicketMessageServiceBll(ISendAppMessageDal sendAppMessageDal,
            ISendAppMessageBll sendAppMessageBll, ICustomerAppClientIdDal customerAppClientIdDal)
        {
            _sendAppMessageFactory = new SendAppMessageFactory(sendAppMessageDal, sendAppMessageBll, customerAppClientIdDal);
        }

        /// <summary>
        /// 获取所有待推送机票出票通知的信息
        /// </summary>
        public List<SendAppMessageModel> Get()
        {
            return _sendAppMessageFactory.GetSendAppMessage(SendAppMessageTypeEnum.PrintTicketNotice);
        }

        public void Send(List<SendAppMessageModel> sendAppMessageModels)
        {
            _sendAppMessageFactory.SendAppMessage(sendAppMessageModels, SendAppMessageTypeEnum.PrintTicketNotice);
        }
    }
}
