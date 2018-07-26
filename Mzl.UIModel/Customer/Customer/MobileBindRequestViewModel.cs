using Mzl.UIModel.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mzl.UIModel.Customer.Customer
{
    public class MobileBindRequestViewModel: RequestBaseViewModel
    {
        /// <summary>
        /// 新手机号码
        /// </summary>
        [Description("新手机号码")]
        public string NewMobile { get; set; }

        /// <summary>
        /// 验证码
        /// </summary>
        [Description("验证码")]
        public string VerifyCode { get; set; }
    }
}
