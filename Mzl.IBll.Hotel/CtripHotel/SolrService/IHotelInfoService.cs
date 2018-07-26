using Mzl.DomainModel.Hotel.CTrip.Hotel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mzl.IBll.Hotel.CtripHotel.SolrService
{
    public interface IHotelInfoService
    {
        void AddHotels(int cityId);
        void AddHotel(int hotelId);
        HotelStaticInfoDomainModel QueryById(int id,string coreName);
    }
}
