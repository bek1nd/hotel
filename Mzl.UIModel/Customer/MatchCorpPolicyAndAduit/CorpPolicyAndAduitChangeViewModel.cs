using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mzl.UIModel.Customer.MatchCorpPolicyAndAduit
{
    public class CorpPolicyAndAduitChangeViewModel
    {
        /// <summary>
        /// 部门Id
        /// </summary>
        [Description("部门Id")]
        public int? DepartmentId { get; set; }
        /// <summary>
        /// 部门名称
        /// </summary>
        [Description("部门名称")]
        public string DepartmentName { get; set; }
        /// <summary>
        /// 差旅政策信息
        /// </summary>
        [Description("差旅政策信息")]
        public List<CorpPolicyChangeViewModel> CorpPolicyChangeList { get; set; }

        /// <summary>
        /// 审批规则信息
        /// </summary>
        [Description("审批规则信息")]
        public List<CorpAduitChangeViewModel> CorpAduitChangeList { get; set; }
    }
}
