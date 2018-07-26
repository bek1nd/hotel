using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mzl.UIModel.Train.Order
{
    /// <summary>
    /// 乘车人退改签行程信息
    /// </summary>
    public class TrainPassengerModRetTravelViewModel
    {
        /// <summary>
        /// 出发站
        /// </summary>
        public string StartName { get; set; }
        /// <summary>
        /// 到达站
        /// </summary>
        public string EndName { get; set; }
        /// <summary>
        /// 出发时间
        /// </summary>
        public DateTime StartTime { get; set; }

        /// <summary>
        /// 到达时间
        /// </summary>
        public DateTime EndTime { get; set; }
        /// <summary>
        /// 车次
        /// </summary>
        public string TrainNo { get; set; }
        /// <summary>
        /// 席位
        /// </summary>
        public string PlaceType { get; set; }
        /// <summary>
        /// 等级
        /// </summary>
        public string PlaceGrade { get; set; }
        /// <summary>
        /// 车厢号
        /// </summary>
        public string PlaceCar { get; set; }
        /// <summary>
        /// 座位号
        /// </summary>
        public string PlaceSeatNo { get; set; }
        /// <summary>
        /// 改签差价
        /// </summary>
        public decimal? ModFacePrice { get; set; }

        public DateTime? ModOrderTime { get; set; }
        /// <summary>
        /// 退票费用
        /// </summary>
        public decimal? RefundPrice { get; set; }
        public DateTime? RefundOrderTime { get; set; }
        /// <summary>
        /// 改签订单号
        /// </summary>
        public int? CorderId { get; set; }
        /// <summary>
        /// 退票单号
        /// </summary>
        public int? RefundOrderId { get; set; }
        /// <summary>
        /// 票号
        /// </summary>
        public string TicketNo { get; set; }
    }
}
