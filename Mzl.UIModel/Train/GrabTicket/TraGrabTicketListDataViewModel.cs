using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mzl.UIModel.Train.GrabTicket
{
    public class TraGrabTicketListDataViewModel
    {
        public List<TraGrabTicketListDataPassengerViewModel> PassengerList { get; set; }

        public int GrabId { get; set; }
        /// <summary>
        /// 客户Id
        /// </summary>
        public int? Cid { get; set; }
        /// <summary>
        /// 创建人Id
        /// </summary>
        public string CreateOid { get; set; }
        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime CreateTime { get; set; }
        public string CreateTimeDesc => CreateTime.ToString("yyyy-MM-dd HH:mm");
        /// <summary>
        /// 抢票任务开始时间
        /// </summary>
        public DateTime GrabBeginTime { get; set; }
        public string GrabBeginTimeDesc => GrabBeginTime.ToString("yyyy-MM-dd HH:mm");
        /// <summary>
        /// 抢票任务结束时间
        /// </summary>
        public DateTime GrabEndTime { get; set; }
        public string GrabEndTimeDesc => GrabEndTime.ToString("yyyy-MM-dd HH:mm");
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
        public string StartCodeName { get; set; }
        /// <summary>
        /// 到达站
        /// </summary>
        public string EndCodeName { get; set; }
        /// <summary>
        /// 出发日期
        /// </summary>
        public DateTime StartTime { get; set; }

        public string StartTimeDesc => StartTime.ToString("yyyy-MM-dd");
        /// <summary>
        /// 抢票的具体车次，以“,”隔开
        /// </summary>
        public string TrainNo { get; set; }
        /// <summary>
        /// 座位类型
        /// </summary>
        public string SeatType { get; set; }
        public string GrabStatusNow { get; set; }

        public string GrabStatusNowDesc { get; set; }
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
