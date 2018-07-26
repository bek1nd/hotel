using Mzl.UIModel.Customer.Identification;
using System.Collections.Generic;
using System.ComponentModel;

namespace Mzl.UIModel.Passenger
{
    public class PassengerViewModel
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
        /// 乘机人信息
        /// </summary>
        [Description("乘机人信息")]
        public string PassengerName { get; set; }
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
        /// <summary>
        /// 所属部门
        /// </summary>
        [Description("所属部门")]
        public string DepartmentName { get; set; }
        /// <summary>
        /// 证件号集合
        /// </summary>
        [Description("证件号集合")]
        public List<IdentificationViewModel> IdentificationList { get; set; }
    }
}
