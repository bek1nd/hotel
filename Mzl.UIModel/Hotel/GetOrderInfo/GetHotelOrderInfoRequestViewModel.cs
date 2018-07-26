using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mzl.UIModel.Base;

namespace Mzl.UIModel.Hotel.GetOrderInfo
{
    public class GetHotelOrderInfoRequestViewModel : RequestBaseViewModel
    {
        /// <summary>
        /// 酒店订单号
        /// </summary>
        [Description("酒店订单号")]
        public int OrderId { get; set; }
    }
}
