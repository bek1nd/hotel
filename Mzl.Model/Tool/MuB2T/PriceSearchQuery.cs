using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mzl.EntityModel.Tool.MuB2T
{
    /// <summary>
    /// 价格税费查询条件
    /// </summary>
    [Table("PriceSearchQuery")]
    public class PriceSearchQuery
    {
        /// <summary>
        /// Id
        /// </summary>
        [Key]
        [Description("Id")]
        public long Id { get; set; }

        /// <summary>
        /// 到达机场
        /// </summary>
        [Description("到达机场")]
        [MaxLength(1000)]
        public string ArrivePort { get; set; }

        /// <summary>
        /// 出发机场
        /// </summary>
        [Description("出发机场")]
        [MaxLength(1000)]
        public string DepartPort { get; set; }

        /// <summary>
        /// 航班号,斜杠分割"/"
        /// </summary>
        [Description("航班号")]
        [MaxLength(1000)]
        public string FlightNo { get; set; }

        /// <summary>
        /// 起始日期
        /// </summary>
        [Description("起始日期")]
        public DateTime? BeginDate { get; set; }

        /// <summary>
        /// 截止日期
        /// </summary>
        [Description("截止日期")]
        public DateTime? EndDate { get; set; }

        /// <summary>
        /// 仓位,斜杠分割"/"
        /// </summary>
        [Description("仓位")]
        [MaxLength(1000)]
        public string CabinName { get; set; }

        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime? CreateDate { get; set; }
        /// <summary>
        /// 状态
        /// 
        /// -1 已作废
        /// 0 初始
        /// </summary>
        [Description("状态")]
        public int? Status { get; set; }
    }
}
