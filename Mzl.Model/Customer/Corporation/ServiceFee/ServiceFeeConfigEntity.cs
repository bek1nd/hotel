using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Mzl.EntityModel.Customer.Corporation.ServiceFee
{
    [Table("P_ServiceFeeConfig")]
    public class ServiceFeeConfigEntity
    {
        /// <summary>
        /// 主键
        /// </summary>
        [Key]
        [Description("主键")]
        public int SfcId { get; set; }
        /// <summary>
        /// 廉价航空公司
        /// </summary>
        [Description("廉价航空公司")]
        public string AirlineName { get; set; }
        /// <summary>
        /// 创建时间
        /// </summary>
        [Description("创建时间")]
        public DateTime? CreateTime { get; set; }
        /// <summary>
        /// 创建人
        /// </summary>
        [Description("创建人")]
        public string Oid { get; set; }
        /// <summary>
        /// 服务费政策名称
        /// </summary>
        [Description("服务费政策名称")]
        public string ServiceFeeName { get; set; }
        /// <summary>
        /// 航司代码
        /// </summary>
        [Description("航司代码")]
        public string AirlineCode { get; set; }
    }
}
