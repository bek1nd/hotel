using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mzl.UIModel.Base;

namespace Mzl.UIModel.Customer.Customer
{
    public class UpdateCustomerInfoRequestViewModel: RequestBaseViewModel
    {
        /// <summary>
        /// 客户名称
        /// </summary>
        [Description("客户名称")]
        public string RealName { get; set; }
        /// <summary>
        /// 性别
        /// </summary>
        [Description("性别")]
        public string Gender { get; set; }
        /// <summary>
        /// 手机号
        /// </summary>
        [Description("手机号")]
        public string Mobile { get; set; }
        /// <summary>
        /// Email
        /// </summary>
        [Description("Email")]
        public string Email { get; set; }
    }
}
