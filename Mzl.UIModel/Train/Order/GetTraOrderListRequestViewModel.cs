using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mzl.UIModel.Base;

namespace Mzl.UIModel.Train.Order
{
    public class GetTraOrderListRequestViewModel : RequestBaseViewModel
    {
        public DateTime? OrderBeginTime { get; set; }
        public DateTime? OrderEndTime { get; set; }
        public DateTime? TravelBeginTime { get; set; }
        public DateTime? TravelEndTime { get; set; }
        public int? OrderId { get; set; }
        /// <summary>
        /// 退票订单号
        /// </summary>
        public string RefundOrderId { get; set; }
        public string PassengerName { get; set; }
        public string CostCenter { get; set; }
        public int? ProjectId { get; set; }
        /// <summary>
        /// 订单状态
        /// </summary>
        public int? OrderStatus { get; set; }
        /// <summary>
        /// 当前显示多少条
        /// </summary>
        public int PageSize { get; set; }
        /// <summary>
        /// 第几页
        /// </summary>
        public int PageIndex { get; set; }
        public string UserId { get; set; }
        public string CorpId { get; set; }
    }
}
