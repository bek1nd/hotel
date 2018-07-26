using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mzl.EntityModel.Proxy.CTripHotel.HotelDetailPrice
{
    public class RoomPriceInfo
    {
        /// <summary>
        /// CancelPolicyInfos
        /// </summary>
        public List<CancelPolicyInfo> CancelPolicyInfos { get; set; }
        /// <summary>
        /// ReserveTimeLimitInfo
        /// </summary>
        public ReserveTimeLimitInfo ReserveTimeLimitInfo { get; set; }
        /// <summary>
        /// HoldDeadline
        /// </summary>
        public HoldDeadline HoldDeadline { get; set; }
        /// <summary>
        /// PriceInfos
        /// </summary>
        public List<PriceInfo> PriceInfos { get; set; }
        /// <summary>
        /// ShadowRoomInfo
        /// </summary>
        public ShadowRoomInfo ShadowRoomInfo { get; set; }
        /// <summary>
        /// 售卖房型ID/子房型ID
        /// </summary>
        public int RoomID { get; set; }
        /// <summary>
        /// 售卖房型名称/子房型名称
        /// </summary>
        public string RoomName { get; set; }
    }
}
