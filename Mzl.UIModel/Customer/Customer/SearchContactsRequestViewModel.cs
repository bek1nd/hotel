using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mzl.UIModel.Base;

namespace Mzl.UIModel.Customer.Customer
{
    public class SearchContactsRequestViewModel : RequestBaseViewModel
    {
        /// <summary>
        /// 查询条件
        /// </summary>
        [Description("查询条件")]
        public string SearchArgs { get; set; }
    }
}
