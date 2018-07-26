using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mzl.UIModel.Base;

namespace Mzl.UIModel.Customer.Customer
{
    public class AddContactAddressRequestViewModel : RequestBaseViewModel
    {
        /// <summary>
        /// 送票地址
        /// </summary>
        [Required]
        [Description("送票地址")]
        public string Address { get; set; }
    }
}
