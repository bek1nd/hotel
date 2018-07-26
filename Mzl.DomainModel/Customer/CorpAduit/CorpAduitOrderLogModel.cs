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
    public class CorpAduitOrderLogModel
    {
        /// <summary>
        /// 日志Id
        /// </summary>
        [Description("日志Id")]
        public int LogId { get; set; }
        /// <summary>
        /// 日志时间
        /// </summary>
        [Description("日志时间")]
        public DateTime LogTime { get; set; }
        /// <summary>
        /// 审批操作来源 app  oa 差旅网站
        /// </summary>
        [Description("审批操作来源 app  oa 差旅网站")]
        public string Source { get; set; }
        /// <summary>
        /// 审批单号
        /// </summary>
        [Description("审批单号")]
        public int AduitOrderId { get; set; }
        /// <summary>
        /// 操作人Id TC
        /// </summary>
        [Description("操作人Id TC")]
        public string DealOid { get; set; }
        /// <summary>
        /// 操作人Id
        /// </summary>
        [Description("操作人Id")]
        public int? DealCid { get; set; }
        /// <summary>
        /// 操作人名称
        /// </summary>
        [Description("操作人名称")]
        public string DealCustomerName { get; set; }
        /// <summary>
        /// 操作类型 0送审 1审批通过 2审批不通过 3提交
        /// </summary>
        [Description("操作类型 0送审 1审批通过 2审批不通过 3提交")]
        public int DealResult { get; set; }
        /// <summary>
        /// 操作类型描述
        /// </summary>
        [Description("操作类型描述")]
        public string DealResultDes => DealResult.ValueToDescription<AduitDealResultEnum>();
        /// <summary>
        /// 审批阶段
        /// </summary>
        [Description("审批阶段")]
        public int AduitFlow { get; set; }
        /// <summary>
        /// 审批结果内容
        /// </summary>
        [Description("审批结果内容")]
        public string AduitReason { get; set; }
        /// <summary>
        /// 0自审批 1代审批 2 tc代审批
        /// </summary>
        [Description("0自审批 1代审批 2 tc代审批")]
        public int? AduitType { get; set; }

        /// <summary>
        /// 操作类型
        /// </summary>
        [Description("操作类型")]
        public string AduitTypeDes
            => !AduitType.HasValue ? string.Empty : AduitType.Value.ValueToDescription<AduitTypeEnum>();
    }
}
