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
    /// 审批日志表
    /// </summary>
    [Table("P_CorpAduitOrder_Log")]
    public class CorpAduitOrderLogEntity
    {
        /// <summary>
        /// 日志Id
        /// </summary>
        [Key]
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
        /// 操作客户Id 非Tc端
        /// </summary>
        [Description("操作客户Id 非Tc端")]
        public int? DealCid { get; set; }
        /// <summary>
        /// 操作人 TC端
        /// </summary>
        [Description("操作人 TC端")]
        public string DealOid { get; set; }
        /// <summary>
        /// 操作类型 0送审 1审批通过 2审批不通过 3提交
        /// </summary>
        [Description("操作类型 0送审 1审批通过 2审批不通过 3提交")]
        public int DealResult { get; set; }
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
    }
}
