using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mzl.Common.JsonHelper;
using Mzl.EntityModel.Proxy.CTripHotel;

namespace Mzl.Proxy.Hotel.CTrip.Query
{
    public class HotelIdList : IHotelIdList
    {
        public HotelIdListResponseEntity Query(HotelIdListRequestEntity req)
        {
            return JsonHelper.DeserializeJsonToObject<HotelIdListResponseEntity>(HotelApiAccess.Query<HotelIdListRequestEntity>(req, "HotelIdList"));
        }

        public string QueryStr(HotelIdListRequestEntity req)
        {
            return HotelApiAccess.Query(req, "HotelIdList");
        }
    }
}
