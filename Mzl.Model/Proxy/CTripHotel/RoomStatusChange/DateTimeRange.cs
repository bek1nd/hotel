using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mzl.EntityModel.Proxy.CTripHotel.RoomStatusChange
{
    public class DateTimeRange
    {
        /// <summary>
        /// 指定时段（时段小于等于1小时）的开始时间
        /// </summary>
        public string Start { get; set; }
        /// <summary>
        /// 指定时段（时段小于等于1小时）的结束时间
        /// </summary>
        public string End { get; set; }
    }
}
