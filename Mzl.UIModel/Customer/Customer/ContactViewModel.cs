using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mzl.UIModel.Customer.Customer
{
    public class ContactViewModel
    {
        /// <summary>
        /// 联系人Id
        /// </summary>
        [Description("联系人Id")]
        public int ContactId { get; set; }
        /// <summary>
        /// 客户Id
        /// </summary>
        [Description("客户Id")]
        public int? Cid { get; set; }
        /// <summary>
        /// 联系人名称
        /// </summary>
        [Description("联系人名称")]
        public string Name { get; set; }
        /// <summary>
        /// 手机号
        /// </summary>
        [Description("乘机人信息")]
        public string Mobile { get; set; }
        /// <summary>
        /// 电话号码
        /// </summary>
        [Description("电话号码")]
        public string Phone { get; set; }
        /// <summary>
        /// Email
        /// </summary>
        [Description("Email")]
        public string Email { get; set; }
        /// <summary>
        /// 传真
        /// </summary>
        [Description("传真")]
        public string Fax { get; set; }
    }
}
