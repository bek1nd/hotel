using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mzl.EntityModel.Proxy.CTripHotel.RoomDesInfo
{
    public class RoomDesInfoResEntity
    {
        public ResponseStatusEntity ResponseStatus { get; set; }
        public IList<RoomStaticInfo> RoomStaticInfos { get; set; }
    }
}
