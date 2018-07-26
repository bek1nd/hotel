using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mzl.EntityModel.Proxy.CTripHotel.RoomDesInfo
{
    public class RoomLimit
    {
        /// <summary>
        /// 适用性限制条件的开始日期
        /// </summary>
        public string Start { get; set; }
        /// <summary>
        /// 适用性限制条件的结束日期
        /// </summary>
        public string End { get; set; }
        /// <summary>
        /// 从周一到周日，该礼盒星期几适用。
        /// 示例：1110110表示周一+周二+周三+周五+周六适用，周四+周日并不适用。
        /// </summary>
        public string WeeklyIndex { get; set; }
    }
}
