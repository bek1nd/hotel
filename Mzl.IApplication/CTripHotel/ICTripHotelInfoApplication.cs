using Mzl.DomainModel.Hotel.CTrip.Hotel;
using Mzl.UIModel.Hotel.CTripHotel.HotelQuery;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mzl.IApplication.CTripHotel
{
    public interface ICTripHotelInfoApplication
    {
        HotelStaticInfoDomainModel Query(CTripHotelInfoReqViewModel req);
        List<CTripHotelSimpleResViewModel> QuerySimpleHotelList(CTripHotelSimpleReqViewModel req);
    }
}
