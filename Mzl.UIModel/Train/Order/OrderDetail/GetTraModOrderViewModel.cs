
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mzl.UIModel.Train.Order.OrderDetail
{
    public class GetTraModOrderViewModel
    {
        /// <summary>
        /// 改签订单Id
        /// </summary>
        public int CorderId { get; set; }
        /// <summary>
        /// 行程信息集合
        /// </summary>
        [Description("行程信息集合")]
        public List<GetTraOrderTravelViewModel> TravelList { get; set; }
        /// <summary>
        /// 是否允许退票
        /// </summary>
        [Description("是否允许退票")]
        public bool IsAllowRet { get; set; }
    }
}
