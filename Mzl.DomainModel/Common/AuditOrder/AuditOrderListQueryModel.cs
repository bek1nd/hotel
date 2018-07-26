using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mzl.DomainModel.Base;

namespace Mzl.DomainModel.Common.AuditOrder
{
    public class AuditOrderListQueryModel : BaseOrderListQueryModel
    {
        /// <summary>
        /// 审批人id
        /// </summary>
        [Description("审批人id")]
        public int AuditCid { get; set; }
    }
}
