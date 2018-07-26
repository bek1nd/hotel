using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mzl.UIModel.Customer.CorpPolicy
{
    public class CorpPolicyProjectViewModel
    {
        /// <summary>
        /// 部门成本中心Id
        /// </summary>
        [Description("部门成本中心Id")]
        public string ProjectId { get; set; }
        /// <summary>
        /// 部门成本中心名称
        /// </summary>
        [Description("部门成本中心名称")]
        public string ProjectName { get; set; }
        /// <summary>
        /// 是否包含对应的政策
        /// </summary>
        [Description("是否包含对应的政策")]
        public bool IsHasPolicy { get; set; }
        /// <summary>
        /// 是否包含对应的审批规则
        /// </summary>
        [Description("是否包含对应的审批规则")]
        public bool IsHasAduit { get; set; }
    }
}
