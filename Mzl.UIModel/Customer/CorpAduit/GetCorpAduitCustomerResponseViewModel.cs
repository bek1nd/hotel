using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mzl.UIModel.Customer.CorpPolicy;

namespace Mzl.UIModel.Customer.CorpAduit
{
    public class GetCorpAduitCustomerResponseViewModel
    {
        /// <summary>
        /// 客户信息集合
        /// </summary>
        [Description("客户信息集合")]
        public List<CorpAduitCustomerViewModel> CustomerList { get; set; }
    }
}
