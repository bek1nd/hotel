using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mzl.EntityModel.Proxy.CTripHotel.RoomDesInfo
{
    public class RoomGiftInfo
    {
        /// <summary>
        /// 礼盒ID
        /// </summary>
        public string ID { get; set; }
        /// <summary>
        /// 礼盒名称
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// 礼盒描述
        /// </summary>
        public string Description { get; set; }
        /// <summary>
        /// 礼盒生效日期
        /// </summary>
        public string Start { get; set; }
        /// <summary>
        /// 礼盒截至日期
        /// </summary>
        public string End { get; set; }
        /// <summary>
        /// 礼盒适用性的限制条件。
        /// 备注：礼盒真正的适用日期需要取礼盒生效、失效日期与适用性限制条件中的开始、结束时间取交集。
        /// </summary>
        public RoomLimit RoomLimit { get; set; }
    }
}
