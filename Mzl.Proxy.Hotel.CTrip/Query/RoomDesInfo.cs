using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mzl.Common.JsonHelper;
using Mzl.EntityModel.Proxy.CTripHotel.RoomDesInfo;

namespace Mzl.Proxy.Hotel.CTrip.Query
{
    public class RoomDesInfo : IRoomDesInfo
    {
        public RoomDesInfoResEntity Query(RoomDesInfoReqEntity req)
        {
            return JsonHelper.DeserializeJsonToObject<RoomDesInfoResEntity>(HotelApiAccess.Query(req, "RoomDesInfo"));
        }

        public string QueryStr(RoomDesInfoReqEntity req)
        {
            return HotelApiAccess.Query(req, "RoomDesInfo");
        }
    }
}
