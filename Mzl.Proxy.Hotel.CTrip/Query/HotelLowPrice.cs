using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mzl.Common.JsonHelper;
using Mzl.EntityModel.Proxy.CTripHotel.SearchHotelLowPrice;

namespace Mzl.Proxy.Hotel.CTrip.Query
{
    public class HotelLowPrice : IHotelLowPrice
    {
        public LowPriceResEntity QueryObj(LowPriceReqEntity req)
        {
            return HotelApiAccess.QueryObj<LowPriceReqEntity, LowPriceResEntity>(req);
        }

        public string QueryStr(LowPriceReqEntity req)
        {
            return HotelApiAccess.QueryStr<LowPriceReqEntity>(req);
        }
    }
}
