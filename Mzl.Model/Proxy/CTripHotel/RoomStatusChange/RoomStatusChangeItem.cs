using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mzl.EntityModel.Proxy.CTripHotel.RoomStatusChange
{
    public class RoomStatusChangeItem
    {
        /// <summary>
        /// 售卖房型ID
        /// </summary>
        public int RoomID { get; set; }
        /// <summary>
        /// 酒店ID
        /// </summary>
        public string HotelID { get; set; }
        /// <summary>
        /// T代表上线，F代表下线
        /// </summary>
        public string Status { get; set; }
        /// <summary>
        /// 房型是否是供应商房型，T代表供应商房型，F代表非供应商房型
        /// </summary>
        public string IsSupplier { get; set; }
        /// <summary>
        /// 发生变化的时间点
        /// </summary>
        public string DateChangeLastTime { get; set; }
    }
}
