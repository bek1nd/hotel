using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Mzl.EntityModel.Customer.Contact
{
    [Table("P_Contact_Address")]
    public class ContactAddressEntity
    {
        [Key]
        public int Aid { get; set; }
        /// <summary>
        /// 更新人
        /// </summary>
        [Description("更新人")]
        public string Oid { get; set; }
        /// <summary>
        /// 联系人ID
        /// </summary>
        [Description("联系人ID")]
        public int Cid { get; set; }
        /// <summary>
        /// 联系人常用地址
        /// </summary>
        [Description("联系人常用地址")]
        public string Address { get; set; }
        /// <summary>
        /// 最后更新时间
        /// </summary>
        [Description("最后更新时间")]
        public DateTime LastUpdateTime { get; set; }
        /// <summary>
        /// 状态
        /// </summary>
        [Description("状态")]
        public string Status { get; set; }
        /// <summary>
        /// 公司ID
        /// </summary>
        [Description("公司ID")]
        public string CorpId { get; set; }
        /// <summary>
        /// 省份ID
        /// </summary>
        [Description("省份ID")]
        public int? ProvinceId { get; set; }
        /// <summary>
        /// 城市ID
        /// </summary>
        [Description("城市ID")]
        public int? CityId { get; set; }
        /// <summary>
        /// 区域ID
        /// </summary>
        [Description("区域ID")]
        public int? DistrictId { get; set; }
        /// <summary>
        /// 收件人
        /// </summary>
        [Description("收件人")]
        public string RealName { get; set; }
        /// <summary>
        /// 联系电话
        /// </summary>
        [Description("联系电话")]
        public string Tel { get; set; }
        /// <summary>
        /// 邮编
        /// </summary>
        [Description("邮编")]
        public string PostCode { get; set; }
        /// <summary>
        /// 公司部门ID
        /// </summary>
        [Description("公司部门ID")]
        public int? CorpDepartId { get; set; }
        /// <summary>
        /// 配送方式,N无需送票,O一单一送,S定期配送
        /// </summary>
        [Description("配送方式,N无需送票,O一单一送,S定期配送")]
        public string SendType { get; set; }
        /// <summary>
        /// 定期配送日期
        /// </summary>
        [Description("定期配送日期")]
        public int? SendVal { get; set; }
        /// <summary>
        /// 配送时间开始
        /// </summary>
        [Description("配送时间开始")]
        public string SendStartTime { get; set; }
        /// <summary>
        /// 配送时间结束
        /// </summary>
        [Description("配送时间结束")]
        public string SendEndTime { get; set; }
        /// <summary>
        /// 已使用次数
        /// </summary>
        [Description("已使用次数")]
        public int UserdCount { get; set; }
    }
}
