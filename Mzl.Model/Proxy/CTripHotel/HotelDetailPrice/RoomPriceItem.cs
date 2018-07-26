using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mzl.EntityModel.Proxy.CTripHotel.HotelDetailPrice
{
    public class RoomPriceItem
    {
        /// <summary>
        /// RoomPriceInfos
        /// </summary>
        public List<RoomPriceInfo> RoomPriceInfos { get; set; }
        /// <summary>
        /// 物理房型名称
        /// </summary>
        public int RoomTypeID { get; set; }
    }
}
