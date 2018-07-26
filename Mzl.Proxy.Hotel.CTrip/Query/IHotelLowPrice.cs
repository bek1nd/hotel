using Mzl.EntityModel.Proxy.CTripHotel.SearchHotelLowPrice;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mzl.Proxy.Hotel.CTrip.Query
{
    public interface IHotelLowPrice
    {
        LowPriceResEntity QueryObj(LowPriceReqEntity req);
        string QueryStr(LowPriceReqEntity req);
    }
}
