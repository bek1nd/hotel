using Mzl.EntityModel.Hotel.Elong;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mzl.Proxy.Hotel.Elong.Query
{
    public interface IHotelListService
    {
        HotelListResponseEntity Query(HotelListRequestEntity request);
        string QueryStr(HotelListRequestEntity request);
    }
}
