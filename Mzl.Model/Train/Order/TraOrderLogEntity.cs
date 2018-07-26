using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Mzl.EntityModel.Train.Order
{
    [Table("Tra_OrderLog")]
    public class TraOrderLogEntity
    {
        /// <summary>
        /// 主键
        /// </summary>
        [Key]
        [Column("Log_ID")]
        public int LogId { get; set; }
        /// <summary>
        /// 订单号
        /// </summary>
        [Column("O_ID")]
        public int OrderId { get; set; }
        /// <summary>
        /// 操作人
        /// </summary>
        [Column("Operator_ID")]
        public string CreateOid { get; set; }
        /// <summary>
        /// 日志时间
        /// </summary>
        [Column("Log_Time")]
        public DateTime CreateTime { get; set; }
        /// <summary>
        /// 日志类型
        /// </summary>
        [Column("Log_type")]
        public string LogType { get; set; }
        /// <summary>
        /// 日志内容
        /// </summary>
        [Column("Log_context")]
        public string LogContent { get; set; }
        
    }
}
