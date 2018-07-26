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
    /// 航班价格信息
    /// </summary>
    [Table("ETL0_RtFlightPrice")]
    public class ETL0RtFlightPrice
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
        /// 仓位
        /// </summary>
        [Description("仓位")]
        [MaxLength(10)]
        public string CabinName { get; set; }

        /// <summary>
        /// 航班号
        /// </summary>
        [Description("航班号")]
        [MaxLength(10)]
        public string FlightNo { get; set; }



        /// <summary>
        /// 出发时间
        /// </summary>
        [Description("出发时间")]
        public DateTime? DepartDate { get; set; }
        

        /// <summary>
        /// 价格
        /// </summary>
        public Decimal? Price { get; set; }

        /// <summary>
        /// 税费
        /// </summary>
        public Decimal? Tax { get; set; }

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
