using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mzl.UIModel.Customer.CorpPolicy
{
    public class GetCorpPolicyCustomerResponseViewModel
    {
        /// <summary>
        /// 客户信息集合
        /// </summary>
        [Description("客户信息集合")]
        public List<CorpPolicyCustomerViewModel> CustomerList { get; set; }
    }
}
