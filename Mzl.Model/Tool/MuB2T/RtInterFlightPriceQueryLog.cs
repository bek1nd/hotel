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
    /// 国际直达航班价格查询
    /// </summary>
    [Table("RtInterFlightPriceQueryLog")]
    public class RtInterFlightPriceQueryLog
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
        [MaxLength(10)]
        public string ArrivePort { get; set; }

        /// <summary>
        /// 出发机场
        /// </summary>
        [Description("出发机场")]
        [MaxLength(10)]
        public string DepartPort { get; set; }

        /// <summary>
        /// 航班号
        /// </summary>
        [Description("航班号")]
        [MaxLength(10)]
        public string FlightNo { get; set; }

        /// <summary>
        /// 返回航班号
        /// </summary>
        [Description("返回航班号")]
        [MaxLength(10)]
        public string RtFlightNo { get; set; }

        /// <summary>
        /// 出发时间
        /// </summary>
        [Description("出发时间")]
        public DateTime? DepartDate { get; set; }

        /// <summary>
        /// 返回时间
        /// </summary>
        [Description("返回时间")]
        public DateTime? ReturnDate { get; set; }

        /// <summary>
        /// 出发仓位
        /// </summary>
        [Description("出发仓位")]
        [MaxLength(10)]
        public string DepartCabinName { get; set; }

        /// <summary>
        /// 返回仓位
        /// </summary>
        [Description("返回仓位")]
        [MaxLength(10)]
        public string ReturnCabinName { get; set; }

        /// <summary>
        /// 航程类型
        /// 
        /// OW 单程
        /// RT 往返
        /// </summary>
        [Description("航程类型")]
        [MaxLength(10)]
        public string RouteType { get; set; }

        /// <summary>
        /// 返回数据
        /// </summary>
        [Description("返回数据")]
        public string ResponseData { get; set; }

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
