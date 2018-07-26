using System.Collections.Generic;
using System.ComponentModel;
using Mzl.DomainModel.Base;

namespace Mzl.DomainModel.Customer.CorpPolicy
{
    public class CorpPolicyConfigDepartmentModel
    {
        /// <summary>
        /// 部门Id集合
        /// </summary>
        [Description("部门Id集合")]
        public List<KeyValueModel<int,bool>> DepartmentIdList { get; set; }
        /// <summary>
        /// 政策Id
        /// </summary>
        [Description("政策Id")]
        public int PolicyId { get; set; }
    }
}
