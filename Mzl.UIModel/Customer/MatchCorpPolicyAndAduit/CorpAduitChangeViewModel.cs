using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mzl.UIModel.Customer.MatchCorpPolicyAndAduit
{
    public class CorpAduitChangeViewModel
    {
        /// <summary>
        /// 审批规则Id
        /// </summary>
        [Description("审批规则Id")]
        public int AduitId { get; set; }
        /// <summary>
        /// 审批规则名称
        /// </summary>
        [Description("审批规则名称")]
        public string AduitName { get; set; }
    }
}
