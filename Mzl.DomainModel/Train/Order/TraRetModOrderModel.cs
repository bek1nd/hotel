using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mzl.DomainModel.Train.Order
{
    /// <summary>
    /// 火车退票/改签信息
    /// </summary>
    public class TraRetModOrderModel
    {
        /// <summary>
        /// 订单来源
        /// </summary>
        public string OrderFrom { get; set; }
        /// <summary>
        /// 行程信息（包含了乘车人信息）
        /// </summary>
        public List<TraOrderDetailModel> TravelInfoList { get; set; }

    }
}
