using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mzl.Common.EnumHelper;
using Mzl.Common.EnumHelper.CorpAduit;

namespace Mzl.DomainModel.Customer.CorpAduit
{
    public class CorpAduitOrderFlowModel
    {
        /// <summary>
        /// 审批阶段Id
        /// </summary>
        [Description("审批阶段Id")]
        public int FlowId { get; set; }
        /// <summary>
        /// 审批单号
        /// </summary>
        [Description("审批单号")]
        public int AduitOrderId { get; set; }
        /// <summary>
        /// 审批阶段
        /// </summary>
        [Description("审批阶段")]
        public int Flow { get; set; }
        /// <summary>
        /// 审批人Id
        /// </summary>
        [Description("审批人Id")]
        public int FlowCid { get; set; }
        /// <summary>
        /// 审批人名称
        /// </summary>
        [Description("审批人名称")]
        public string FlowCustomerName { get; set; }
        /// <summary>
        /// 处理结果 1审批通过 2审批不通过 0送审 3提交
        /// </summary>
        [Description("处理结果 1审批通过 2审批不通过 0送审 3提交")]
        public int? DealResult { get; set; }
        /// <summary>
        /// 处理结果描述
        /// </summary>
        [Description("处理结果描述")]
        public string DealResultDes => !DealResult.HasValue ? string.Empty : DealResult.Value.ValueToDescription<AduitDealResultEnum>();
    }
}
