using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mzl.EntityModel.Train.Order
{
    public class TraModOrderListDataEntity : TraOrderListDataEntity
    {
        /// <summary>
        /// 改签订单Id
        /// </summary>
        public int CorderId { get; set; }
        /// <summary>
        /// 改签订单号
        /// </summary>
        public string Coid { get; set; }
        /// <summary>
        /// 改签差价
        /// </summary>
        public decimal CalcPrice { get; set; }

        public string OrderStatus { get; set; }
    }
}
