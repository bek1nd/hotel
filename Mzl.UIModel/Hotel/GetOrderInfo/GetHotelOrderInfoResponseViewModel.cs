using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mzl.UIModel.Hotel.GetOrderInfo
{
    public class GetHotelOrderInfoResponseViewModel
    {
        /// <summary>
        /// 酒店订单号
        /// </summary>
        [Description("酒店订单号")]
        public int OrderId { get; set; }
        /// <summary>
        /// 订单金额
        /// </summary>
        [Description("订单金额")]
        public decimal PayAmount { get; set; }
        /// <summary>
        /// 订单底价
        /// </summary>
        [Description("订单底价")]
        public decimal LowAmount { get; set; }
        /// <summary>
        /// 间数
        /// </summary>
        [Description("间数")]
        public int RoomNum { get; set; }
        /// <summary>
        /// 间夜信息
        /// </summary>
        [Description("间夜信息")]
        public List<HotelOrderDetailViewModel> HotelOrderDetailList { get; set; }
    }
}
