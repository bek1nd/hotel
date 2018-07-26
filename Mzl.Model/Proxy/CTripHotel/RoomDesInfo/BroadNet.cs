using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mzl.EntityModel.Proxy.CTripHotel.RoomDesInfo
{
    public class BroadNet
    {
        /// <summary>
        /// 宽带资费说明
        /// </summary>
        public string BroadnetFeeDatail { get; set; }
        /// <summary>
        /// 该售卖房型是否有无线宽带：0-无；1-全部房间有，且收费；2-全部房间有，且免费；3-部分房间有，且收费；4-部分房间有，且免费；
        /// </summary>
        public int WirelessBroadnet { get; set; }
        /// <summary>
        /// 该售卖房型是否有有线宽带：0-无；1-全部房间有，且收费；2-全部房间有，且免费；3-部分房间有，且收费；4-部分房间有，且免费；
        /// </summary>
        public int WiredBroadnet { get; set; }
    }
}
