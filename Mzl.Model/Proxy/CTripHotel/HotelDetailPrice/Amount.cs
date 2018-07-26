using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mzl.EntityModel.Proxy.CTripHotel.HotelDetailPrice
{
    public class Amount
    {
        /// <summary>
        /// 定义相邻节点的金额为原币种还是自定义币种。目前仅两种取值：DisplayCurrency; OriginalCurrency;
        /// </summary>
        public string Type { get; set; }
        /// <summary>
        /// 单间房在入离时间内，某一税项的总金额
        /// </summary>
        public double amount { get; set; }
        /// <summary>
        /// 币种
        /// </summary>
        public string Currency { get; set; }
    }
}
