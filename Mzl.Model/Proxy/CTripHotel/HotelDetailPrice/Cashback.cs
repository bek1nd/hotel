using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mzl.EntityModel.Proxy.CTripHotel.HotelDetailPrice
{
    public class Cashback
    {
        /// <summary>
        /// 定义相邻节点的金额为原币种还是自定义币种。目前仅两种取值：DisplayCurrency; OriginalCurrency;
        /// </summary>
        public string Type { get; set; }
        /// <summary>
        /// 起限制作用，分销商促销活动允许的最大反现金额
        /// </summary>
        public double Amount { get; set; }
        /// <summary>
        /// 币种
        /// </summary>
        public string Currency { get; set; }
    }
}
