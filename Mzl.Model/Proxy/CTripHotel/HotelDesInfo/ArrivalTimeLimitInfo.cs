using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mzl.EntityModel.Proxy.CTripHotel.HotelDesInfo
{
    public class ArrivalTimeLimitInfo
    {
        /// <summary>
        /// 最早到店时间
        /// </summary>
        public string EarliestTime { get; set; }
        /// <summary>
        /// 最晚到店时间
        /// </summary>
        public string LatestTime { get; set; }
        /// <summary>
        /// 是否必须
        /// </summary>
        public string IsMustBe { get; set; }
    }
}
