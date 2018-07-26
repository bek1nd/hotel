using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mzl.DomainModel.Base;

namespace Mzl.DomainModel.Customer.CorpPolicy
{
    public class CorpPolicyConfigProjectModel
    {
        /// <summary>
        /// 项目成本中心Id集合
        /// </summary>
        [Description("项目成本中心Id集合")]
        public List<KeyValueModel<int, bool>> ProjectIdList { get; set; }
        /// <summary>
        /// 政策Id
        /// </summary>
        [Description("政策Id")]
        public int PolicyId { get; set; }
    }
}
