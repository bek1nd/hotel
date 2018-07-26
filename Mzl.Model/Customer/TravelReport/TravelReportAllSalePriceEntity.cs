using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Mzl.EntityModel.Customer.TravelReport
{
    [Table("TravelReport_AllSalePrice")]
    public class TravelReportAllSalePriceEntity
    {
        /// <summary>
        /// 主键
        /// </summary>
        [Key]
        [Description("主键")]
        public int id { get; set; }
        /// <summary>
        /// 参与人数
        /// </summary>
        [Description("参与人数")]
        public int manNum { get; set; }
        /// <summary>
        /// 销售价格
        /// </summary>销售价格")]
        public decimal SalePriceSum { get; set; }
        /// <summary>
        /// 打折比率
        /// </summary>
        [Description("打折比率")]
        public string SaleRate { get; set; }
        /// <summary>
        /// 数据类型 1代表订单2代表账单
        /// </summary>数据类型")]
        public int SourceType { get; set; }
        /// <summary>
        /// 查询月份
        /// </summary>
        [Description("查询月份")]
        public DateTime? TheMonth { get; set; }
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
