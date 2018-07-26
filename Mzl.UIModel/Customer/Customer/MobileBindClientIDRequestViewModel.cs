using Mzl.UIModel.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mzl.UIModel.Customer.Customer
{
    public class MobileBindClientIDRequestViewModel : RequestBaseViewModel
    {
        /// <summary>
        /// 验证码
        /// </summary>
        [Description("验证码")]
        public string VerifyCode { get; set; }

        /// <summary>
        /// 客户端设别ID
        /// </summary>
        [Description("客户端设别ID")]
        public string ClientID { get; set; }

        /// <summary>
        /// 客户端设别类型
        /// </summary>
        [Description("客户端设别类型")]
        public string ClientType { get; set; }
    }
}
