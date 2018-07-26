using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mzl.EntityModel.Proxy.CTripHotel.RoomDesInfo
{
    public class RoomStaticInfo
    {
        public RoomTypeInfo RoomTypeInfo { get; set; }
        public IList<RoomInfo> RoomInfos { get; set; }
    }
}
