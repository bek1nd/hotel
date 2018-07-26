using Mzl.DomainModel.Hotel.CTrip.Hotel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mzl.IBll.Hotel.CtripHotel
{
    public interface IQueryHotelInfoService
    {
        CTripHotelInfoResponseModel QueryList(CTripHotelInfoRequestModel request);
    }
}
