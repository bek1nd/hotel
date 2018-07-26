using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Mzl.Common.CacheHelper;
using Mzl.DomainModel.Flight;
using Mzl.EntityModel.Common;
using Mzl.Framework.Base;
using Mzl.IBLL.Flight.BaseInfo;
using Mzl.IDAL.Flight;

namespace Mzl.BLL.Flight.BaseInfo
{
    public class GetCityForFlightServiceBll: BaseServiceBll,IGetCityForFlightServiceBll
    {
        private readonly IAirPortDal _airPortDal;
        private readonly ICityDal _cityDal;
        private readonly ICountryDal _countryDal;

        public GetCityForFlightServiceBll(IAirPortDal airPortDal, ICityDal cityDal,
            ICountryDal countryDal) : base()
        {
            this._countryDal = countryDal;
            this._airPortDal = airPortDal;
            this._cityDal = cityDal;
        }


        public SearchCityAportModel SearchAirport(List<string> isInterList)
        {
            return CacheManager.Get(CacheKeyEnum.AirportSearch.ToString(), Get, isInterList,
                60*24);
        }

        private SearchCityAportModel Get(List<string> isInterList)
        {


            List<AirPortEntity> airPortList = _airPortDal.Query<AirPortEntity>(n => isInterList.Any(x=>x==n.IsInter), true).ToList();//机场信息
            //查询对应城市信息
            List<string> cityCodeList = new List<string>();//城市Code
            airPortList.ForEach(n => cityCodeList.Add(n.CityCode));
            List<CityEntity> cityList = _cityDal.Query<CityEntity>(n => cityCodeList.Any(x=>x==n.CityCode), true).ToList();//城市信息
            List<int> pcidList = new List<int>();//国家id
            cityList.ForEach(n => pcidList.Add(n.Pcid ?? 0));
            List<CountryEntity> countryList = _countryDal.Query<CountryEntity>(n => pcidList.Any(x=>x==n.Pcid), true).ToList();//国家信息
            SearchCityAportModel result = new SearchCityAportModel();
            result.CountryList = new List<SearchCountryModel>();

            foreach (var country in countryList)
            {
                SearchCountryModel countryModel = Mapper.Map<CountryEntity, SearchCountryModel>(country);
                countryModel.CityList =
                    Mapper.Map<List<CityEntity>, List<SearchCityModel>>(cityList.FindAll(n => n.Pcid == country.Pcid));
                foreach (var city in countryModel.CityList)
                {
                    city.AirportList =
                        Mapper.Map<List<AirPortEntity>, List<SearchAirportModel>>(
                            airPortList.FindAll(n => n.CityCode == city.CityCode));
                }
                result.CountryList.Add(countryModel);
            }

            return result;
        }
    }
}
