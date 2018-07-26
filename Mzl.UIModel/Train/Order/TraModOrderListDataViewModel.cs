using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mzl.UIModel.Train.Order
{
    public class TraModOrderListDataViewModel : TraOrderListDataBaseViewModel
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

        /// <summary>
        /// 改签面价
        /// </summary>
        public decimal ModFacePrice { get; set; }
    }
}
