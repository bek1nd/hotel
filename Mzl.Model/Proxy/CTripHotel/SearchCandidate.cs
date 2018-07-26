using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mzl.EntityModel.Proxy.CTripHotel
{
    public class SearchCandidate
    {
        /// <summary>
        /// 酒店代码
        /// </summary>
        public string HotelID { get; set; }
        /// <summary>
        /// 房型ID列表，
        /// </summary>
        public string[] RoomIds { get; set; }
    }
}
