using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Mzl.Framework.Base;
using Mzl.IBLL.Customer.Customer;
using Mzl.IDAL.Customer.Customer;
using Mzl.DomainModel.Customer.SendAppMessage;
using Mzl.EntityModel.Customer.AppClient;
using Mzl.EntityModel.Customer.BaseInfo;
using Mzl.EntityModel.Customer.Corporation.Corp;
using Mzl.IDAL.Customer.Corporation;

namespace Mzl.BLL.Customer.Customer
{
    public class AddSendAppMessageServiceBll : BaseServiceBll, IAddSendAppMessageServiceBll
    {
        private readonly IAddSendAppMessageBll _addSendAppMessageBll;
        public AddSendAppMessageServiceBll(IAddSendAppMessageBll addSendAppMessageBll)
        {
            _addSendAppMessageBll = addSendAppMessageBll;
        }
        /// <summary>
        /// 审批结果通知
        /// </summary>
        /// <param name="sendAppAuditResultMessageModel"></param>
        public void AddAppAuditResultMessage(SendAppAuditResultMessageModel sendAppAuditResultMessageModel)
        {
            SendAppMessageModel sendAppMessageModel = sendAppAuditResultMessageModel;
            _addSendAppMessageBll.AddAppMessage(sendAppMessageModel);
        }
        /// <summary>
        /// 待审批消息通知
        /// </summary>
        /// <param name="sendAppMessageModel"></param>
        public void AddAppWaitAuditMessage(SendAppMessageModel sendAppMessageModel)
        {
            _addSendAppMessageBll.AddAppMessage(sendAppMessageModel);
        }
        /// <summary>
        /// 出票消息通知
        /// </summary>
        /// <param name="sendAppMessageModel"></param>
        public void AddAppPrintTicketMessage(SendAppMessageModel sendAppMessageModel)
        {
            _addSendAppMessageBll.AddAppMessage(sendAppMessageModel);
        }


        
    }
}
