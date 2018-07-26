using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mzl.Common.EnumHelper;
using Mzl.UIModel.Base;

namespace Mzl.UIModel.Common.AuditOrder
{
    public class AuditOrderRequestViewModel : RequestBaseViewModel
    {
        public int Id { get; set; }
        public OrderSourceTypeEnum OrderSourceType { get; set; }
        /// <summary>
        /// 是否通过审批
        /// </summary>
        public bool IsAgree { get; set; }
        /// <summary>
        /// 审批阶段
        /// </summary>
        [Required]
        public string AuditStep { get; set; }
    }
}
