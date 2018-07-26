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
    public class CorpAduitOrderModel
    {
        /// <summary>
        /// 审批单Id
        /// </summary>
        [Description("审批单Id")]
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
        /// 审批状态描述
        /// </summary>
        [Description("审批状态描述")]
        public string StatusDes => Status.ValueToDescription<CorpAduitOrderStatusEnum>();
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
        public int IsDel { get; set; }
    }
}
