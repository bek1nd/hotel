using System.Collections.Generic;
using System.ComponentModel;

namespace Mzl.DomainModel.Train.Order.OrderDetail
{
    public class GetTraModOrderModel
    {
        /// <summary>
        /// 改签订单Id
        /// </summary>
        public int CorderId { get; set; }

        /// <summary>
        /// 行程信息集合
        /// </summary>
        [Description("行程信息集合")]
        public List<GetTraOrderTravelModel> TravelList { get; set; }
        /// <summary>
        /// 是否允许退票
        /// </summary>
        [Description("是否允许退票")]
        public bool IsAllowRet { get; set; }
    }
}
