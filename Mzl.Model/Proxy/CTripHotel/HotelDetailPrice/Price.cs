using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mzl.EntityModel.Proxy.CTripHotel.HotelDetailPrice
{
    public class Price
    {
        /// <summary>
        /// 定义相邻节点的金额为原币种还是自定义币种。目前仅两种取值：DisplayCurrency; OriginalCurrency;
        /// </summary>
        public string Type { get; set; }
        /// <summary>
        /// 单间房入离时间的税前总价
        /// </summary>
        public double ExclusiveAmount { get; set; }
        /// <summary>
        /// 单间房入离时间的税后总价
        /// </summary>
        public double InclusiveAmount { get; set; }
        /// <summary>
        /// 币种
        /// </summary>
        public string Currency { get; set; }
    }
}
