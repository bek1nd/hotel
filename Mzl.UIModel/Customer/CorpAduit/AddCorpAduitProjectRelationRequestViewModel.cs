using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mzl.UIModel.Base;

namespace Mzl.UIModel.Customer.CorpAduit
{
    public class AddCorpAduitProjectRelationRequestViewModel: RequestBaseViewModel
    {
        /// <summary>
        /// 项目成本中心Id集合
        /// </summary>
        [Description("项目成本中心Id集合")]
        public List<KeyValueViewModel<int, bool>> ProjectIdList { get; set; }
        /// <summary>
        /// 审批规则Id
        /// </summary>
        [Description("审批规则Id")]
        public int AduitId { get; set; }
    }
}
