using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Mzl.EntityModel.Customer.Corporation.CorpAudit
{
    /// <summary>
    /// 审批阶段表
    /// </summary>
    [Table("P_CorpAduitOrder_Flow")]
    public class CorpAduitOrderFlowEntity
    {
        /// <summary>
        /// 审批阶段Id
        /// </summary>
        [Key]
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
        /// 审批人
        /// </summary>
        [Description("审批人")]
        public int FlowCid { get; set; }
        /// <summary>
        /// 处理结果 1审批通过 2审批不通过 0送审 3提交
        /// </summary>
        [Description("处理结果 1审批通过 2审批不通过 0送审 3提交")]
        public int? DealResult { get; set; }
    }
}
