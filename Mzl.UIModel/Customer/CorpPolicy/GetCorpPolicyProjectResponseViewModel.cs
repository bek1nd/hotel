using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mzl.UIModel.Customer.CorpPolicy
{
    public class GetCorpPolicyProjectResponseViewModel
    {
        /// <summary>
        /// 项目成本中心信息集合
        /// </summary>
        [Description("项目成本中心信息集合")]
        public List<CorpPolicyProjectViewModel> ProjectList { get; set; }
    }
}
