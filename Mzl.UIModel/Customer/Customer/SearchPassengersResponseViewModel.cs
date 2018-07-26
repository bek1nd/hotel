using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mzl.UIModel.Passenger;

namespace Mzl.UIModel.Customer.Customer
{
    public class SearchPassengersResponseViewModel
    {
        /// <summary>
        /// 订单待预定乘客信息集合
        /// </summary>
        [Description("订单待预定乘客信息集合")]
        public List<PassengerViewModel> PassengerList { get; set; }
    }
}
