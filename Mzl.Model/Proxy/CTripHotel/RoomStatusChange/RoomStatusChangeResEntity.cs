using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mzl.EntityModel.Proxy.CTripHotel.RoomStatusChange
{
    public class RoomStatusChangeResEntity
    {
        public ResponseStatusEntity ResponseStatus { get; set; }
        public IList<RoomStatusChangeItem> RoomStatusChangeItems { get; set; }
    }
}
