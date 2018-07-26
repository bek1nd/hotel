using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;


namespace Mzl.EntityModel.Customer.Contact
{
    [Table("P_Contact_Identification")]
    public class ContactIdentificationInfoEntity
    {
        /// <summary>
        /// 联系人Id
        /// </summary>
        [Description("联系人Id")]
        [Key, Column(Order=1)]
        public int Contactid { get; set; }
        /// <summary>
        /// 证件类型Id
        /// </summary>
        [Key, Column(Order = 2)]
        [Description("证件类型Id")]
        public int Iid { get; set; }
        /// <summary>
        /// 证件号码
        /// </summary>
        [Description("证件号码")]
        public string CardNo { get; set; }
        /// <summary>
        /// 最后更新日期
        /// </summary>
        [Description("最后更新日期")]
        public DateTime LastUpdateTime { get; set; }
        /// <summary>
        /// 证件有效期
        /// </summary>
        [Description("证件有效期")]
        public DateTime? CardValidity { get; set; }
    }
}
