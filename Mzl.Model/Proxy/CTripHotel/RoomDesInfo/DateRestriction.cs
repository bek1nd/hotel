using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mzl.EntityModel.Proxy.CTripHotel.RoomDesInfo
{
    public class DateRestriction
    {
        /// <summary>
        /// 日期时间限制的类别：
        /// Booking-预定；
        /// Arrival-到店；
        /// StayIn-入住期间；
        /// Departure-离店；
        /// </summary>
        public string Scope { get; set; }
        /// <summary>
        /// 定义相邻节点Start和End的日期时间格式：
        /// Date表示仅有日期限制；
        /// Time表示仅有时间限制；
        /// DateTime表示日期+时间限制；
        /// </summary>
        public string DateType { get; set; }
        /// <summary>
        /// 开始时间
        /// </summary>
        public string Start { get; set; }
        /// <summary>
        /// 截止时间
        /// </summary>
        public string End { get; set; }
        /// <summary>
        /// 是否当日有效(T表示是)
        /// </summary>
        public string IsIntraday { get; set; }
    }
}
