using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mzl.EntityModel.Proxy.CTripHotel.HotelDetailPrice
{
    public class ShadowRoomInfo
    {
        /// <summary>
        /// 房型促销策略ID(马甲ID)，与RoomID结合起来，判断一个促销价格策略。
        /// </summary>
        public int ShadowID { get; set; }
    }
}
