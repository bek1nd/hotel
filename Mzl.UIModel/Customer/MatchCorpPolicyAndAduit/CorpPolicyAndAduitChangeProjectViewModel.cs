using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mzl.UIModel.Customer.MatchCorpPolicyAndAduit
{
    public class CorpPolicyAndAduitChangeProjectViewModel
    {
        /// <summary>
        /// 项目成本中心Id
        /// </summary>
        [Description("项目成本中心Id")]
        public int? ProjectId { get; set; }
        /// <summary>
        /// 项目成本中心
        /// </summary>
        [Description("项目成本中心")]
        public string ProjectName { get; set; }
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
