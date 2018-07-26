using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mzl.EntityModel.Proxy.CTripHotel.HotelDesInfo
{
    public class DepartureTimeLimitInfo
    {
        /// <summary>
        /// 最早离店时间
        /// </summary>
        public string EarliestTime { get; set; }
        /// <summary>
        /// 最晚离店时间
        /// </summary>
        public string LatestTime { get; set; }
    }
}
