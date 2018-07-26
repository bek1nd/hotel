using AutoMapper;
using Mzl.DomainModel.Hotel.CTrip.Hotel;
using Mzl.IBll.Hotel.CtripHotel.SolrService;
using Mzl.IDAL.CTripHotel.SolrDAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mzl.Bll.Hotel.CtripHotel.SolrService
{
    public class HotelInfoService:IHotelInfoService
    {
        private ICTripHotelDesDal _cTripHotelDesDal;
        public HotelInfoService(ICTripHotelDesDal cTripHotelDesDal)
        {
            _cTripHotelDesDal = cTripHotelDesDal;
        }
        public void AddHotel(int hotelId)
        {

        }
        public void AddHotels(int cityId)
        {

        }

        public HotelStaticInfoDomainModel QueryById(int id,string coreName)
        {
            var hotelStaticInfoEntityModel=_cTripHotelDesDal.QueryById(id,coreName);
            HotelStaticInfoDomainModel hotelDomainModel =
              Mapper.Map<Mzl.EntityModel.Proxy.CTripHotel.HotelDesInfo.HotelStaticInfo, HotelStaticInfoDomainModel>(hotelStaticInfoEntityModel);
            return hotelDomainModel;
        }
    }
}
