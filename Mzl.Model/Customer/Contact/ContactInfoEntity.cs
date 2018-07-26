using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mzl.EntityModel.Customer.Contact
{
    [Table("P_Contact")]
    public class ContactInfoEntity
    {
        /// <summary>
        /// 联系人Id
        /// </summary>
        [Key]
        [Description("联系人Id")]
        public int Contactid { get; set; }
        /// <summary>
        /// 客户Id
        /// </summary>
        [Description("客户Id")]
        public int Cid { get; set; }
        /// <summary>
        /// 联系人姓名
        /// </summary>
        [Description("联系人姓名")]
        public string Cname { get; set; }
        /// <summary>
        /// 联系人英文名称
        /// </summary>
        [Description("联系人英文名称")]
        public string Ename { get; set; }
        /// <summary>
        /// 联系电话
        /// </summary>
        [Description("联系电话")]
        public string Phone { get; set; }
        /// <summary>
        /// 手机号码
        /// </summary>
        [Description("手机号码")]
        public string Mobile { get; set; }
        /// <summary>
        /// 生日
        /// </summary>
        [Description("生日")]
        public DateTime? Birthday { get; set; }
        /// <summary>
        /// 传真
        /// </summary>
        [Description("传真")]
        public string Fax { get; set; }
        /// <summary>
        /// Email
        /// </summary>
        [Description("Email")]
        public string Email { get; set; }
        /// <summary>
        /// 最后更新时间
        /// </summary>
        [Description("最后更新时间")]
        public DateTime LastUpdateTime { get; set; }
        /// <summary>
        /// 性别
        /// </summary>
        [Description("性别")]
        public string Gender { get; set; }
        /// <summary>
        /// 地址
        /// </summary>
        [Description("地址")]
        public string Address { get; set; }
        /// <summary>
        /// 是否是乘机人
        /// </summary>
        [Description("是否是乘机人")]
        public string IsPassenger { get; set; }
        /// <summary>
        /// 乘机人信息更新时间
        /// </summary>
        [Description("乘机人信息更新时间")]
        public DateTime? PassengerlastUpdateTime { get; set; }
        /// <summary>
        /// 国籍
        /// </summary>
        [Description("国籍")]
        public string Nationality { get; set; }
        /// <summary>
        /// 证件有效期
        /// </summary>
        [Description("证件有效期")]
        public DateTime? CardValidity { get; set; }
        /// <summary>
        /// 显示隐藏
        /// </summary>
        [Description("显示隐藏")]
        public string IsDel { get; set; }
        /// <summary>
        /// 删除人
        /// </summary>
        [Description("删除人")]
        public string UpdateOid { get; set; }
        /// <summary>
        /// 删除时间
        /// </summary>
        [Description("删除时间")]
        public DateTime DelTime { get; set; }
        /// <summary>
        /// 备注
        /// </summary>
        [Description("备注")]
        public string Remark { get; set; }
        /// <summary>
        /// 分组编号
        /// </summary>
        [Description("分组编号")]
        public int? GroupId { get; set; }
        /// <summary>
        /// 旅客卡号
        /// </summary>
        [Description("旅客卡号")]
        public string CustomerCardId { get; set; }
        /// <summary>
        /// 座位习惯
        /// </summary>
        [Description("座位习惯")]
        public string SeatHabit { get; set; }
        /// <summary>
        /// 与P_customer的CID一对一
        /// </summary>
        [Description("与P_customer的CID一对一")]
        public int? PCid { get; set; }
        /// <summary>
        /// 成本中心ID
        /// </summary>
        [Description("成本中心Id")]
        public string CostCenter { get; set; }

        /// <summary>
        /// 默认证件ID
        /// </summary>
        [Description("默认证件ID")]
        public int? DefaultIdentificationId { get; set; }
        /// <summary>
        /// 是否线上 0否 1是
        /// </summary>
        public int? IsOnline { get; set; }
    }
}
