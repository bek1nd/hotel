using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mzl.Common.EnumHelper
{
    public enum SendAppMessageTypeEnum
    {
        /// <summary>
        /// 出票通知
        /// </summary>
        [Description("出票通知")]
        PrintTicketNotice = 0,
        /// <summary>
        /// 核价待确认通知
        /// </summary>
        [Description("核价待确认通知")]
        ConfireAuditPriceNotice = 1,
        /// <summary>
        /// 待审核通知
        /// </summary>
        [Description("待审核通知")]
        WaitAuditNotice =2,
        /// <summary>
        /// 退客户通知
        /// </summary>
        [Description("退客户通知")]
        RefundedCustomerNotice = 3,
        /// <summary>
        /// 审核结果通知
        /// </summary>
        [Description("审核结果通知")]
        AuditResultNotice = 4,
        /// <summary>
        /// 审核单过期
        /// </summary>
        [Description("审核单过期")]
        AuditOrderDeleteNotice = 5,
        /// <summary>
        /// 待审核催促通知
        /// </summary>
        [Description("待审核催促通知")]
        AuditUrgeNotice =6,
        /// <summary>
        /// 机票出票通知邮件
        /// </summary>
        [Description("机票出票通知邮件")]
        SendPrintFltTicketEmail = 7,
        /// <summary>
        /// 准备机票出票通知邮件
        /// </summary>
        [Description("准备机票出票通知邮件")]
        SendRunPrintFltTicketEmail =8
    }
}
