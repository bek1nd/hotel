using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mzl.Framework.Base;
using Mzl.UIModel.Hotel.Elong.HotelInfo;

namespace Mzl.IApplication.Hotel
{
    public interface IQueryHotelListApplication : IBaseApplication
    {
        QueryHotelInfoResponseViewModel QueryHotelList(QueryHotelInfoRequestViewModel query);
    }
}
