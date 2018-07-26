using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Mzl.EntityModel.Customer.TravelReport
{
    [Table("TravelReport_ConsumeCount")]
    public class TravelReportConsumeCountEntity
    {
        /// <summary>
        /// 主键
        /// </summary>
        [Key]
        [Description("主键")]
        public int id { get; set; }
        /// <summary>
        /// 销售价格
        /// </summary>销售价格")]
        public decimal SalePriceSum { get; set; }

        /// <summary>
        /// 节省价格
        /// </summary>节省价格")]
        public decimal SavePrice { get; set; }
        /// <summary>
        /// 消费类型
        /// </summary>
        [Description("消费类型")]
        public string SaleType { get; set; }
        /// <summary>
        /// 查询年份
        /// </summary>
        [Description("查询年份")]
        public int TheYear { get; set; }
        /// <summary>
        /// 数据类型 1代表订单2代表账单
        /// </summary>数据类型")]
        public int SourceType { get; set; }
        /// <summary>
        /// 公司编号
        /// </summary>
        [Description("公司编号")]
        public string corpid { get; set; }
        /// <summary>
        /// 创建时间
        /// </summary>
        [Description("创建时间")]
        public DateTime? Createdate { get; set; }
    }
}
