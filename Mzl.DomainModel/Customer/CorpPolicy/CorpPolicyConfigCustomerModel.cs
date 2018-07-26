using System.Collections.Generic;
using System.ComponentModel;

namespace Mzl.DomainModel.Customer.CorpPolicy
{
    public class CorpPolicyConfigCustomerModel
    {
        /// <summary>
        /// 客户Id集合
        /// </summary>
        [Description("客户Id集合")]
        public List<int> CidList { get; set; }
        /// <summary>
        /// 政策Id
        /// </summary>
        [Description("政策Id")]
        public int PolicyId { get; set; }
    }
}
