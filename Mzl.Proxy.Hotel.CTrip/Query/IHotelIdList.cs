using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mzl.EntityModel.Proxy.CTripHotel;

namespace Mzl.Proxy.Hotel.CTrip.Query
{
    public interface IHotelIdList
    {
        HotelIdListResponseEntity Query(HotelIdListRequestEntity req);
        string QueryStr(HotelIdListRequestEntity req);
    }
}
