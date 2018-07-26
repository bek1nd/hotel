using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mzl.UIModel.Base;

namespace Mzl.UIModel.Customer.CorpAduit
{
    public class GetCorpAduitConfigResponseViewModel
    {
        /// <summary>
        /// 审批规则信息
        /// </summary>
        [Description("审批规则信息")]
        public CorpAduitConfigViewModel AduitConfigRule { get; set; }
        /// <summary>
        /// 审批人信息集合
        /// </summary>
        [Description("审批人信息集合")]
        public List<SortedListViewModel> AduitONameList { get; set; }
    }
}
