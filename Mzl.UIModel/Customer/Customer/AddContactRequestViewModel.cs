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
    public class AddContactRequestViewModel : RequestBaseViewModel
    {
        /// <summary>
        /// 名称
        /// </summary>
        [Description("名称")]
        [Required]
        public string Cname { get; set; }
        /// <summary>
        /// 手机号码
        /// </summary>
        [Description("手机号码")]
        public string Mobile { get; set; }
        /// <summary>
        /// 证件类型Id
        /// </summary>
        [Description("证件类型Id")]
        public int Iid { get; set; }
        /// <summary>
        /// 证件号码
        /// </summary>
        [Description("证件号码")]
        [Required]
        public string CardNo { get; set; }
         /// <summary>
        /// 邮箱
        /// </summary>
        [Description("邮箱")]
        public string Email { get; set; }
        /// <summary>
        /// 是否乘机人
        /// </summary>
        [Description("是否乘机人 T是，F否")]
        public string IsPassenger { get; set; } = "T";
    }
}
