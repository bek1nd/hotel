using Mzl.Framework.Base;
using Mzl.UIModel.Base;
using Mzl.UIModel.Hotel.CTripHotel.HotelQuery;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mzl.IApplication.Hotel.CTrip
{
    public interface ICTripHotelInfoApplication : IBaseApplication
    {

        List<CTripHotelSimpleResViewModel> QuerySimpleHotelList(CTripHotelSimpleReqViewModel req);
        
    }
}
