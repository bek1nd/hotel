using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mzl.DomainModel.Customer.SendAppMessage
{
    /// <summary>
    /// 审批结果通知
    /// </summary>
    public class SendAppAuditResultMessageModel : SendAppMessageModel
    {
        /// <summary>
        /// 是否同意
        /// </summary>
        public bool IsAgree { get; set; }
        /// <summary>
        /// 审核结果信息
        /// </summary>
        public string AuditResult { get; set; }
    }
}
