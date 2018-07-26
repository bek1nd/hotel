using Mzl.DomainModel.Customer.Identification;
using System.Collections.Generic;

namespace Mzl.DomainModel.Customer.Passenger
{
    public class PassengerInfoModel
    {
        /// <summary>
        /// 联系人Id
        /// </summary>
        public int ContactId { get; set; }
        /// <summary>
        /// 客户Id
        /// </summary>
        public int? Cid { get; set; }
        /// <summary>
        /// 乘机人信息
        /// </summary>
        public string PassengerName { get; set; }
        /// <summary>
        /// 手机号码
        /// </summary>
        public string Mobile { get; set; }
        /// <summary>
        /// 电话号码
        /// </summary>
        public string Phone { get; set; }
        /// <summary>
        /// Email
        /// </summary>
        public string Email { get; set; }
        /// <summary>
        /// 传真
        /// </summary>
        public string Fax { get; set; }
        /// <summary>
        /// 所属部门
        /// </summary>
        public string DepartmentName { get; set; }

        public int? DefaultIdentificationId { get; set; }
        /// <summary>
        /// 证件信息集合
        /// </summary>
        public List<IdentificationModel> IdentificationList { get; set; }
        /// <summary>
        /// 公司部门Id
        /// </summary>
        public int? CorpDepartId { get; set; }
    }
}
