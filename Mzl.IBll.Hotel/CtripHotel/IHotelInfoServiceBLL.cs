using Mzl.UIModel.Hotel.CTripHotel.HotelQuery;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mzl.IBll.Hotel.CtripHotel
{
    public interface IHotelInfoServiceBLL
    {
        CTripHotelSimpleResViewModel QuerySimpleHotelList(CTripHotelSimpleReqViewModel req);
    }
}

