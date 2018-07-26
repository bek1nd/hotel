using System;
using System.Collections.Generic;
using Mzl.Common.CacheHelper;
using Mzl.DomainModel.Hotel.Elong.City;
using Mzl.EntityModel.Hotel.Elong;
using Mzl.Framework.Base;
using Mzl.IBll.Hotel.ElongService;
using Mzl.Proxy.Hotel.Elong.StaticData;

namespace Mzl.Bll.Hotel.ElongService
{
    public class QueryElongHotelCityServiceBll : BaseServiceBll, IQueryElongHotelCityServiceBll
    {
        private readonly IHotelGeoService _hotelGeoService;

        public QueryElongHotelCityServiceBll(IHotelGeoService hotelGeoService)
        {
            _hotelGeoService = hotelGeoService;
        }

        public List<HotelCountryModel> QueryHotelCity(int queryCityType)
        {
            if (queryCityType != 0)//除开艺龙国内城市类型之外，暂时没有
                return null;

            return RedisManager.Get(CacheKeyEnum.ElongHotelDomesticCity.ToString(), RequestElongInterface, TimeSpan.FromDays(7));
        }
        /// <summary>
        /// 访问艺龙国内酒店数据
        /// </summary>
        /// <returns></returns>
        private List<HotelCountryModel> RequestElongInterface()
        {
            List<HotelCountryModel> hotelCountryModels = new List<HotelCountryModel>();
            HotelGeosResponseEntity geosResponseEntity = _hotelGeoService.GetAll();

            HotelCountryModel hotelCountry = new HotelCountryModel();
            hotelCountry.Country = "中国";
            hotelCountry.CityList = new List<HotelCityModel>();

            if (geosResponseEntity != null)
            {
                foreach (HotelGeo hotelGeo in geosResponseEntity.HotelGeoList)
                {
                    #region 城市
                    HotelCityModel cityModel = new HotelCityModel()
                    {
                        ProvinceId = hotelGeo.ProvinceId,
                        ProvinceName = hotelGeo.ProvinceName,
                        CityCode = hotelGeo.CityCode,
                        CityName = hotelGeo.CityName,
                        CommericalLocationList = new List<HolelCommericalLocationModel>(),
                        DistrictList = new List<HotelDistrictModel>(),
                        LandmarkLocationList = new List<HotelLandmarkLocationModel>()
                    };

                    #endregion
                    #region 商业区
                    if (hotelGeo.CommericalLocations != null && hotelGeo.CommericalLocations.Length > 0)
                    {
                        foreach (var commericalLocation in hotelGeo.CommericalLocations)
                        {
                            cityModel.CommericalLocationList.Add(new HolelCommericalLocationModel()
                            {
                                Id = commericalLocation.Id,
                                Name = commericalLocation.Name
                            });
                        }
                    }
                    #endregion
                    #region 行政区
                    if (hotelGeo.Districts != null && hotelGeo.Districts.Length > 0)
                    {
                        foreach (var pubObj in hotelGeo.Districts)
                        {
                            cityModel.DistrictList.Add(new HotelDistrictModel()
                            {
                                Id = pubObj.Id,
                                Name = pubObj.Name
                            });
                        }
                    }
                    #endregion
                    #region 标志物
                    if (hotelGeo.LandmarkLocations != null && hotelGeo.LandmarkLocations.Length > 0)
                    {
                        foreach (var landmarkLocation in hotelGeo.LandmarkLocations)
                        {
                            cityModel.LandmarkLocationList.Add(new HotelLandmarkLocationModel()
                            {
                                Id = landmarkLocation.Id,
                                Name = landmarkLocation.Name
                            });
                        }
                    } 
                    #endregion
                    hotelCountry.CityList.Add(cityModel);
                }
            }

            hotelCountryModels.Add(hotelCountry);

            return hotelCountryModels;
        }
    }
}
