using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mzl.UIModel.Customer.CorpAduit
{
    public class GetCorpAduitConfigListResponseViewModel
    {
        /// <summary>
        /// 审批规则集合
        /// </summary>
        [Description("审批规则集合")]
        public List<CorpAduitConfigListViewModel> AduitConfigList { get; set; }
    }
}
