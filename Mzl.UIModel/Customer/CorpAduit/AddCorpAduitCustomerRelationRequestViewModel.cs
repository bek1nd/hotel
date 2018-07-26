using System.Collections.Generic;
using System.ComponentModel;
using Mzl.UIModel.Base;

namespace Mzl.UIModel.Customer.CorpAduit
{
    public class AddCorpAduitCustomerRelationRequestViewModel : RequestBaseViewModel
    {
        /// <summary>
        /// 客户Id集合
        /// </summary>
        [Description("客户Id集合")]
        public List<int> CidList { get; set; }
        /// <summary>
        /// 审批规则Id
        /// </summary>
        [Description("审批规则Id")]
        public int AduitId { get; set; }
    }
}
