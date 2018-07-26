using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Mzl.EntityModel.Customer.Corporation.ServiceFee
{
    [Table("P_ServiceFeeConfigDetails")]
    public class ServiceFeeConfigDetailsEntity
    {
        /// <summary>
        /// 主键
        /// </summary>
        [Key]
        [Description("主键")]
        public int Id { get; set; }
        /// <summary>
        /// 设置开始时间
        /// </summary>
        [Description("设置开始时间")]
        public string BeginTime { get; set; }
        /// <summary>
        /// 设置结束时间
        /// </summary>
        [Description("设置结束时间")]
        public string EndTime { get; set; }
        /// <summary>
        /// 面价反扣
        /// </summary>
        [Description("面价反扣")]
        public string Point { get; set; }
        /// <summary>
        /// 服务费
        /// </summary>
        [Description("明加服务费")]
        public decimal? ServiceFee { get; set; }
        /// <summary>
        /// 夜间服务费
        /// </summary>
        [Description("暗加服务费")]
        public decimal? NightServicefee { get; set; }
        /// <summary>
        /// 外键（P_ServiceFeeConfig）
        /// </summary>
        [Description("外键（P_ServiceFeeConfig）")]
        public int? SfcId { get; set; }
        /// <summary>
        /// 火车服务费
        /// </summary>
        [Description("火车服务费")]
        public decimal? TrainServiceFee { get; set; }
        /// <summary>
        /// 火车抢票服务费
        /// </summary>
        public decimal? TrainGrabTicketServiceFee { get; set; }
        /// <summary>
        /// 酒店服务费
        /// </summary>
        public decimal? HotelServiceFee { get; set; }
        /// <summary>
        /// 暗加服务费比值
        /// </summary>
        public decimal? NightServicefeeRate { get; set; }
    }
}
