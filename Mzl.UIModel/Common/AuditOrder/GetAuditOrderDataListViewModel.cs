using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mzl.Common.EnumHelper;
using Mzl.Common.EnumHelper.CorpAduit;

namespace Mzl.UIModel.Common.AuditOrder
{
    public class GetAuditOrderDataListViewModel
    {
        /// <summary>
        /// 审批单Id
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// 审批单附属订单信息
        /// </summary>
        public List<AuditOrderDetailViewModel> DetailList { get; set; }
        /// <summary>
        /// 审核状态
        /// </summary>
        public CorpAduitOrderStatusEnum AuditStatus { get; set; }
        /// <summary>
        /// 审核状态描述
        /// </summary>
        public string AuditStatusDes => AuditStatus.ToDescription();
        /// <summary>
        /// 当前审批人Id
        /// </summary>
        public int CurrentAuditCid { get; set; }
        /// <summary>
        /// 当期审批环节
        /// </summary>
        public int CurrentFlow { get; set; }
        /// <summary>
        /// 部门名称
        /// </summary>
        public string DepartmentName { get; set; }
        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime CreateTime { get; set; }
    }
}
