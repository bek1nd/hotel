using Mzl.EntityModel.Hotel.Elong;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mzl.Proxy.Hotel.Elong.Query
{
    public class HotelListService : IHotelListService
    {
        public HotelListResponseEntity Query(HotelListRequestEntity request)
        {
            return HotelApiAccess.Query<HotelListRequestEntity, HotelListResponseEntity>(request, "hotel.list").Result;
        }

        public string QueryStr(HotelListRequestEntity request)
        {
            return HotelApiAccess.Query(request, "hotel.list");
        }
    }
}
