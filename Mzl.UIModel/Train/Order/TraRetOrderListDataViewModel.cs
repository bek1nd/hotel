using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mzl.UIModel.Train.Order
{
    public class TraRetOrderListDataViewModel : TraOrderListDataBaseViewModel
    {
        /// <summary>
        /// 退票订单号
        /// </summary>
        public string RefundOrderId { get; set; }
        /// <summary>
        /// 退票Id
        /// </summary>
        public int OrderId { get; set; }
    }
}
