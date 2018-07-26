using Mzl.EntityModel.Proxy.CTripHotel;
using Mzl.EntityModel.Proxy.CTripHotel.HotelDesInfo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mzl.Proxy.Hotel.CTrip.Query
{
    public interface IHotelDesInfo
    {
        HotelStaticInfo QueryHotelStaticInfo(string hotelId);
        string QueryStr(HotelDesInfoReqEntity req);
    }
}
