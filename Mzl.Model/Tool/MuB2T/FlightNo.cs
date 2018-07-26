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
    /// 航班信息
    /// </summary>
    [Table("FlightNo")]
    public class FlightNo
    {

        /// <summary>
        /// Id
        /// </summary>
        [Key]
        [Description("Id")]

        public int Id { get; set; }

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
        /// 航班号，以半角逗号分隔
        /// </summary>
        [Description("航班号")]
        public string FlightNos { get; set; }

        /// <summary>
        /// 创建时间
        /// </summary>
        [Description("创建时间")]
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
