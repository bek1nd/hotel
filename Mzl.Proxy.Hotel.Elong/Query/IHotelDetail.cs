using Mzl.EntityModel.Hotel.Elong;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mzl.Proxy.Hotel.Elong.Query
{
    public interface IHotelDetail
    {
        HotelListResponseEntity Query(HotelDetailRequestEntity request);
        string QueryStr(HotelDetailRequestEntity request);
    }
}
