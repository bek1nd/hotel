using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mzl.DomainModel.Customer.SendAppMessage;

namespace Mzl.IBLL.Customer.Customer
{
    public interface IAddSendAppMessageServiceBll
    {
        /// <summary>
        /// 审批结果通知
        /// </summary>
        /// <param name="sendAppAuditResultMessageModel"></param>
        void AddAppAuditResultMessage(SendAppAuditResultMessageModel sendAppAuditResultMessageModel);
        /// <summary>
        /// 待审批消息通知
        /// </summary>
        /// <param name="sendAppMessageModel"></param>
        void AddAppWaitAuditMessage(SendAppMessageModel sendAppMessageModel);
        /// <summary>
        /// 出票消息通知
        /// </summary>
        /// <param name="sendAppMessageModel"></param>
        void AddAppPrintTicketMessage(SendAppMessageModel sendAppMessageModel);
    }
}
