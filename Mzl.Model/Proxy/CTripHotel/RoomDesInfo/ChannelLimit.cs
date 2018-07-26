using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mzl.EntityModel.Proxy.CTripHotel.RoomDesInfo
{
    public class ChannelLimit
    {
        /// <summary>
        /// 定义该售卖房型是否能在APP渠道售卖
        /// </summary>
        public bool IsApp { get; set; }
        /// <summary>
        /// 定义该售卖房型是否能在Web渠道售卖
        /// </summary>
        public bool IsWeb { get; set; }
    }
}
