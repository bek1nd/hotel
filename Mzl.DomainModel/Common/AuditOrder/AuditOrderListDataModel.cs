using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using Mzl.Common.EnumHelper;
using Mzl.Common.EnumHelper.CorpAduit;
using Mzl.DomainModel.Customer.Base;
using Mzl.DomainModel.Flight;

namespace Mzl.DomainModel.Common.AuditOrder
{
    public class AuditOrderListDataModel
    {
        /// <summary>
        /// 审批单Id
        /// </summary>
        [Description("审批单Id")]
        public int Id { get; set; }
        /// <summary>
        /// 审批单附属订单信息
        /// </summary>
        [Description("审批单附属订单信息")]
        public List<AuditOrderDetailModel> DetailList { get; set; }

        public int AuditStatusInt { get; set; }

        /// <summary>
        /// 审核状态
        /// </summary>
        [Description("审核状态")]
        public CorpAduitOrderStatusEnum AuditStatus => AuditStatusInt.ValueToEnum<CorpAduitOrderStatusEnum>();
        /// <summary>
        /// 审核状态描述
        /// </summary>
        [Description("审核状态描述")]
        public string AuditStatusDes => AuditStatus.ToDescription();
        /// <summary>
        /// 当前审批人Id
        /// </summary>
        [Description("当前审批人Id")]
        public int CurrentAuditCid { get; set; }
        /// <summary>
        /// 当期审批环节
        /// </summary>
        [Description("当期审批环节")]
        public int CurrentFlow { get; set; }
        /// <summary>
        /// 部门名称
        /// </summary>
        [Description("部门名称")]
        public string DepartmentName { get; set; }
        /// <summary>
        /// 创建时间
        /// </summary>
        [Description("创建时间")]
        public DateTime CreateTime { get; set; }
    }
}
