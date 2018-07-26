using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mzl.UIModel.Base;

namespace Mzl.UIModel.Customer.CorpPolicy
{
    public class AddPolicyCustomerRelationRequestViewModel : RequestBaseViewModel
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
