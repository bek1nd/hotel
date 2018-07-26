using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mzl.UIModel.Base;

namespace Mzl.UIModel.Train.GrabTicket
{
    public class AddGrabTicketRequestViewModel : RequestBaseViewModel
    {
        public string Depart { get; set; }
        public int? ProjectId { get; set; }
        /// <summary>
        /// 抢票任务开始时间
        /// </summary>
        public DateTime GrabBeginTime { get; set; }
        /// <summary>
        /// 抢票任务结束时间
        /// </summary>
        public DateTime GrabEndTime { get; set; }
        /// <summary>
        /// 出发站三字码
        /// </summary>
        public string StartCode { get; set; }
        /// <summary>
        /// 到达站三字码
        /// </summary>
        public string EndCode { get; set; }
        /// <summary>
        /// 出发站
        /// </summary>
        [Required]
        public string StartCodeName { get; set; }
        /// <summary>
        /// 到达站
        /// </summary>
        [Required]
        public string EndCodeName { get; set; }
        /// <summary>
        /// 出发日期
        /// </summary>
        public DateTime StartTime { get; set; }
        /// <summary>
        /// 抢票的具体车次，以“,”隔开
        /// </summary>
        [Required]
        public string TrainNo { get; set; }
        /// <summary>
        /// 座位类型
        /// </summary>
        [Required]
        public string SeatType { get; set; }
        /// <summary>
        /// 是否要无座票
        /// </summary>
        [Required]
        public bool IsNeedNoSeatTicket { get; set; }

        public int? SendType { get; set; }
        public string CName { get; set; }
        public string CMobile { get; set; }
        public string CEmail { get; set; }
        public string CPhone { get; set; }
        public string CFax { get; set; }
        public string SendAddress { get; set; }
        public decimal ServiceFee { get; set; }
        public DateTime? SendTime { get; set; }
        public DateTime? LastSendTime { get; set; }

        public List<AddGrabTicketPassengerViewModel> PassengerList { get; set; }
    }
}
