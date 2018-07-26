using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mzl.UIModel.Base;

namespace Mzl.UIModel.Train.Order.OrderDetail
{
    public class GetTraOrderDetailRequestViewModel : RequestBaseViewModel
    {
        /// <summary>
        /// 火车订单号
        /// </summary>
        [Description("火车订单号")]
        public int OrderId { get; set; }
    }
}
