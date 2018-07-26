using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mzl.EntityModel.Proxy.CTripHotel.SearchHotelLowPrice
{
    public class MinPrice_CashBack
    {
        /// <summary>
        /// 税后且返现后最低价房型的日均最低价，币种为人民币
        /// </summary>
        public double MinPrice { get; set; }
        /// <summary>
        /// 税后且返现后最低价房型的日均最低价，币种为原币种
        /// </summary>
        public double MinPrice_OriginalCurrency { get; set; }
        /// <summary>
        /// 原币种
        /// </summary>
        public string OriginalCurrency { get; set; }
        /// <summary>
        /// 废弃
        /// </summary>
        public int MinPrice_RoomID { get; set; }
    }
}
