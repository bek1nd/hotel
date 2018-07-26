using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mzl.EntityModel.Proxy.CTripHotel.RoomDesInfo
{
    public class BookingOffset
    {
        /// <summary>
        /// 提前预订促销：
        /// Max-最大提前预定限制；
        /// Min-最小提前预定限制；
        /// </summary>
        public string MinMaxType { get; set; }
        /// <summary>
        /// 提前的时间数值
        /// </summary>
        public int Time { get; set; }
        /// <summary>
        /// 时间数值的单位，详情如下：
        /// Year-年；
        /// Month-月；
        /// Week-周；
        /// Day-天(默认)；
        /// Hour-小时；
        /// Minute-分钟；
        /// Second-秒数；
        /// </summary>
        public string TimeUnit { get; set; }
    }
}
