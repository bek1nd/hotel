using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mzl.UIModel.Customer.Customer
{
    public class SearchContactsResponseViewModel
    {
        /// <summary>
        /// 联系人信息集合
        /// </summary>
        [Description("联系人信息集合")]
        public List<ContactViewModel> ContactList { get; set; }
    }
}
