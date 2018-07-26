using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mzl.EntityModel.Customer.Corporation.CorpAudit
{
    /// <summary>
    /// 审批订单表
    /// </summary>
    [Table("P_CorpAduitOrder")]
    public class CorpAduitOrderEntity
    {
        /// <summary>
        /// 审批订单Id
        /// </summary>
        [Key]
        [Description("审批订单Id")]
        public int AduitOrderId { get; set; }
        /// <summary>
        /// 审批规则Id
        /// </summary>
        [Description("审批规则Id")]
        public int AduitConfigId { get; set; }
        /// <summary>
        /// 审批状态
        /// </summary>
        [Description("审批状态")]
        public int Status { get; set; }
        /// <summary>
        /// 当前环节
        /// </summary>
        [Description("当前环节")]
        public int CurrentFlow { get; set; }
        /// <summary>
        /// 最终环节
        /// </summary>
        [Description("最终环节")]
        public int FinalFlow { get; set; }
        /// <summary>
        /// 创建日期
        /// </summary>
        [Description("创建日期")]
        public DateTime CreateTime { get; set; }
        /// <summary>
        /// 是否删除 0否 1是
        /// </summary>
        [Description("是否删除 0否 1是")]
        public int? IsDel { get; set; }
    }
}
