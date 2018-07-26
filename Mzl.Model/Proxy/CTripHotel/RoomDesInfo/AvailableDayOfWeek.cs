using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mzl.EntityModel.Proxy.CTripHotel.RoomDesInfo
{
    public class AvailableDayOfWeek
    {
        /// <summary>
        /// 星期几限制的类别：
        /// Booking-预定；
        /// Arrival-到店；
        /// StayIn-入住期间；
        /// Departure-离店；
        /// </summary>
        public string Scope { get; set; }
        /// <summary>
        /// 从周一到周日，该促销适用于星期几。示例：1110110表示周一、周二、周三、周五、周六适用，周四和周日不适用）
        /// 备注：存在日期范围和星期几限制的情况下，房型促销的适用日期必须同时满足上述两类条件。
        /// </summary>
        public string WeeklyIndex { get; set; }
    }
}
