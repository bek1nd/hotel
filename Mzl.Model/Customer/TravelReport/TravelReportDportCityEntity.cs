using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Mzl.EntityModel.Customer.TravelReport
{
    [Table("TravelReport_DportCity")]
    public class TravelReportDportCityEntity
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
        /// 出差城市
        /// </summary>
        [Description("出差城市")]
        public string DportCity { get; set; }
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
