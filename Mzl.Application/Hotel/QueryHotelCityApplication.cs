using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Mzl.DomainModel.Hotel.Elong.City;
using Mzl.Framework.Base;
using Mzl.IApplication.Hotel;
using Mzl.IBll.Hotel.ElongService;
using Mzl.UIModel.Hotel.Elong.City;

namespace Mzl.Application.Hotel
{
    public class QueryHotelCityApplication : BaseApplicationService, IQueryHotelCityApplication
    {
        private readonly IQueryElongHotelCityServiceBll _queryHotelCityServiceBll;

        public QueryHotelCityApplication(IQueryElongHotelCityServiceBll queryHotelCityServiceBll)
        {
            _queryHotelCityServiceBll = queryHotelCityServiceBll;
        }

        public QueryHotelCityResponseViewModel QueryHotelCity(QueryHotelCityRequestViewModel request)
        {
            List<HotelCountryModel> ciHotelCountryModels =
                _queryHotelCityServiceBll.QueryHotelCity(request.QueryCityType);

            List<HotelCountryViewModel> hotelCountryModels =
                Mapper.Map<List<HotelCountryModel>, List<HotelCountryViewModel>>(ciHotelCountryModels);

            return new QueryHotelCityResponseViewModel()
            {
                CountryList = hotelCountryModels
            };
        }
    }
}
