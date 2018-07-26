using Mzl.Common.CacheHelper;
using Mzl.DomainModel.Hotel.CTrip.City;
using Mzl.EntityModel.Hotel.CTripHotel;
using Mzl.Framework.Base;
using Mzl.IBll.Hotel.CtripHotel;
using Mzl.IDAL.CTripHotel.StaticData;
using Mzl.DAL.CTripHotel.StaticData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mzl.EntityModel.EFContext;

namespace Mzl.Bll.Hotel.CtripHotel
{
    public class QueryCityInofCNBll : BaseBll, IQueryCityInofCNBll
    {
        private readonly ICTripHotelCityCNDal _cityCN;

        public QueryCityInofCNBll(ICTripHotelCityCNDal cityCN)
        {
            _cityCN = cityCN;
        }

        //public QueryCityInofCNBll()
        //{
        //    _cityCN = new CTripHotelCityCNDal();
        //}

        public Country Query()
        {
            Func<Country> QueryEntity = () =>
            {

                using (BrightourDbContext context = new BrightourDbContext())
                {
                    var cities = from c in context.cTripHotelCityCNs
                                 join e in context.cTripHotelCityENs on c.CityId equals e.CityId
                                 select new
                                 {
                                     CityId = c.CityId,
                                     CityName = c.CityName,
                                     Country = c.Country,
                                     CountryName = c.CountryName,
                                     CurrentFlag = c.CurrentFlag,
                                     PCityId = c.PCityId,
                                     Province = c.Province,
                                     ProvinceName = c.ProvinceName,
                                     EName = e.CityName
                                 };


                    //var cities = _cityCN.Query<CTripHotelCityCNEntity>(a => a.CityId == a.CityId);
                    var country = cities.First();
                    var result = new Country();
                    result.Id = country.Country;
                    result.Name = country.CountryName;
                    result.Provinces = new List<Province>();
                    foreach (var city in cities)
                    {
                        if (!result.Provinces.Where(a => a.Id == city.Province).Any())
                        {
                            result.Provinces.Add(new Province() { Id = city.Province, Name = city.ProvinceName, Cities = new List<City>() });
                        }
                        var province = result.Provinces.Where(a => a.Id == city.Province).First();
                        province.Cities.Add(new City() { Id = city.CityId, Name = city.CityName, EName = city.EName });
                    }
                    return result;
                };
            };
            return CacheManager.Get<Country>(CacheKeyEnum.CTripHotelCityCN.ToString(), QueryEntity);
        }

    }
}
