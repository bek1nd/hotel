using Mzl.EntityModel.Proxy.CTripHotel.RoomDesInfo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mzl.Proxy.Hotel.CTrip.Query
{
    public interface IRoomDesInfo
    {
        RoomDesInfoResEntity Query(RoomDesInfoReqEntity req);
        string QueryStr(RoomDesInfoReqEntity req);
    }
}
