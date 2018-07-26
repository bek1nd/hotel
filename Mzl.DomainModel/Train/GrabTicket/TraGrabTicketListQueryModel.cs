using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mzl.Common.EnumHelper.Train;
using Mzl.DomainModel.Base;

namespace Mzl.DomainModel.Train.GrabTicket
{
    public class TraGrabTicketListQueryModel : BaseOrderListQueryModel
    {
        /// <summary>
        /// 订单号
        /// </summary>
        public int? OrderId { get; set; }
        /// <summary>
        /// 抢票开始时间
        /// </summary>
        public DateTime? GrabBeginTime { get; set; }
        /// <summary>
        /// 抢票结束时间
        /// </summary>
        public DateTime? GrabEndTime { get; set; }
        /// <summary>
        /// 出发站
        /// </summary>
        public string StartCodeName { get; set; }
        /// <summary>
        /// 到达站
        /// </summary>
        public string EndCodeName { get; set; }
        /// <summary>
        /// 车次
        /// </summary>
        public string TrainNo { get; set; }
        /// <summary>
        /// 坐席
        /// </summary>
        public string SeatType { get; set; }
        /// <summary>
        /// 抢票状态
        /// </summary>
        public TrainGrabStatusEnum? GrabStatus { get; set; }
        /// <summary>
        /// 发车日期
        /// </summary>
        public DateTime? StartBeginTime { get; set; }
        public DateTime? StartEndTime { get; set; }
        /// <summary>
        /// 创建人Id
        /// </summary>
        public string CreateOid { get; set; }
        /// <summary>
        /// 乘车人
        /// </summary>
        public string PassengerName { get; set; }
    }
}
