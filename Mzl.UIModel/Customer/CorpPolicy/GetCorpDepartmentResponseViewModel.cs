using System.Collections.Generic;
using System.ComponentModel;

namespace Mzl.UIModel.Customer.CorpPolicy
{
    public class GetCorpDepartmentResponseViewModel
    {
        /// <summary>
        /// 部门信息集合
        /// </summary>
        [Description("部门信息集合")]
        public List<CorpPolicyDepartmentViewModel> DepartmentList { get; set; }
    }
}
