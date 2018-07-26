using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mzl.UIModel.Base;

namespace Mzl.UIModel.Common.AuditOrder
{
    public class GetAuditOrderListRequestViewModel : RequestBaseViewModel
    {
        /// <summary>
        ///审批单类型 1待审批 2已审批通过 3已拒绝
        /// </summary>
        [Description("审批单类型 1待审批 2已审批通过 3已拒绝")]
        [Required]
        public int? AuditType { get; set; }
        /// <summary>
        /// 当前显示多少条
        /// </summary>
        public int PageSize { get; set; }
        /// <summary>
        /// 第几页
        /// </summary>
        public int PageIndex { get; set; }
    }
}
