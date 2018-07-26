using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mzl.EntityModel.Proxy.CTripHotel.RoomDesInfo
{
    public class ExpressCheckout
    {
        /// <summary>
        /// 标明酒店是否支持闪住：True-支持；False-不支持；
        /// </summary>
        public bool IsSupported { get; set; }
        /// <summary>
        /// 闪付押金系数
        /// </summary>
        public string DepositRatio { get; set; }
    }
}
