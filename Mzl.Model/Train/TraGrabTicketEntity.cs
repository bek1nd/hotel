using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mzl.EntityModel.Train
{
    [Table("Tra_GrabTicket")]
    public class TraGrabTicketEntity
    {
        /// <summary>
        /// 抢票Id
        /// </summary>
        [Key]
        [Description("抢票Id")]
        public int GrabId { get; set; }
        /// <summary>
        /// 客户Id
        /// </summary>
        [Description("客户Id")]
        public int? Cid { get; set; }
        /// <summary>
        /// 创建人Id
        /// </summary>
        [Description("创建人Id")]
        [Required]
        public string CreateOid { get; set; }
        /// <summary>
        /// 创建时间
        /// </summary>
        [Description("创建时间")]
        [Required]
        public DateTime CreateTime { get; set; }
        /// <summary>
        /// 抢票任务开始时间
        /// </summary>
        [Description("抢票任务开始时间")]
        [Required]
        public DateTime GrabBeginTime { get; set; }
        /// <summary>
        /// 抢票任务结束时间
        /// </summary>
        [Description("抢票任务结束时间")]
        [Required]
        public DateTime GrabEndTime { get; set; }
        /// <summary>
        /// 出发站三字码
        /// </summary>
        [Description("出发站三字码")]
        public string StartCode { get; set; }
        /// <summary>
        /// 到达站三字码
        /// </summary>
        [Description("到达站三字码")]
        public string EndCode { get; set; }
        /// <summary>
        /// 出发站
        /// </summary>
        [Description("出发站")]
        [Required]
        public string StartCodeName { get; set; }
        /// <summary>
        /// 到达站
        /// </summary>
        [Description("到达站")]
        [Required]
        public string EndCodeName { get; set; }
        /// <summary>
        /// 出发日期
        /// </summary>
        [Description("出发日期")]
        [Required]
        public DateTime StartTime { get; set; }
        /// <summary>
        /// 抢票的具体车次，以“,”隔开
        /// </summary>
        [Description("抢票的具体车次，以“,”隔开")]
        [Required]
        public string TrainNo { get; set; }
        /// <summary>
        /// 车次类型，与具体车次对应；Q表示其他类型，包括临客，数字列车等
        /// </summary>
        [Description("车次类型，与具体车次对应；Q表示其他类型，包括临客，数字列车等")]
        [Required]
        public string TrainType { get; set; }
        /// <summary>
        /// 座位类型
        /// </summary>
        [Description("座位类型")]
        [Required]
        public string SeatType { get; set; }
        /// <summary>
        /// 是否要无座票
        /// </summary>
        [Description("是否要无座票")]
        [Required]
        public bool IsNeedNoSeatTicket { get; set; }
        /// <summary>
        /// 抢票状态 W提交抢票 P抢票中 S抢票成功 F抢票失败 C抢票取消
        /// </summary>
        [Description("抢票状态 W提交抢票 P抢票中 S抢票成功 F抢票失败 C抢票取消")]
        [Required]
        public string GrabStatus { get; set; }
        /// <summary>
        /// 火车订单号
        /// </summary>
        public int OrderId { get; set; }

        /// <summary>
        /// 提交抢票失败原因
        /// </summary>
        public string SubmitFailedReason { get; set; }
        /// <summary>
        /// 抢票失败原因
        /// </summary>
        public string GrabFailedReason { get; set; }
    }
}
