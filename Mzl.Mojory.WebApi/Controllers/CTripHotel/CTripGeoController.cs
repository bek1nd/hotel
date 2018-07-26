using Mzl.IApplication.CTripHotel;
using Mzl.UIModel.Base;
using Mzl.UIModel.Hotel.CTrip.City;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using Mzl.Mojory.WebApi.Config;
using Mzl.IDAL.CTripHotel.SolrDAL;
using Mzl.UIModel.Hotel.CTripHotel.City;
using Mzl.UIModel.Hotel.CTripHotel.HotelQuery;
using Mzl.Common.JsonHelper;

namespace Mzl.Mojory.WebApi.Controllers.CTripHotel
{
    public class CTripGeoController : ApiController
    {
        private readonly IQueryCityCNApplication _queryCityCNApplication;
        private readonly ICTripHotelDesDal _cTripHotelDesDal;

        public CTripGeoController(IQueryCityCNApplication queryCityCNApplication,
                                  ICTripHotelDesDal cTripHotelDesDal) {
            _queryCityCNApplication = queryCityCNApplication;
            _cTripHotelDesDal = cTripHotelDesDal;
        }

        [HttpPost]
        public ResponseBaseViewModel<CountryViewModel> GetCityInfo() {
            
            var v = new ResponseBaseViewModel<CountryViewModel>();
            v.Data = _queryCityCNApplication.Query();
            v.Flag = new ResponseCodeViewModel() { Code = 0, Message = "success", MojoryToken = this.GetToken() };
            return v;
        }
        [HttpPost]
        public ResponseBaseViewModel<KeyWordViewModel> GetKeyWord([FromBody]CTripCityInfoRequestViewModel cityReq)
        {
            var kwEntityList = _cTripHotelDesDal.GetKeyWordHotel(cityReq.CityCode);
            var businessDistricts = kwEntityList.Where(x=>!string.IsNullOrWhiteSpace(x.BusinessDistrict) && x.BusinessDistrict.Trim() != ",").Select(a => a.BusinessDistrict.Split(new char[] { ';'}));
            var businessDistrict = new List<string>();
            foreach (var item in businessDistricts) {
               businessDistrict.AddRange(item);
            }
            businessDistrict = businessDistrict.Distinct().ToList();
            var area = kwEntityList.Where(x=>!string.IsNullOrWhiteSpace(x.AreaCode) && !string.IsNullOrWhiteSpace(x.AreaName)).Select(a => a.AreaCode + "," + a.AreaName).Distinct().ToList();
            var brand = kwEntityList.Where(x=>!string.IsNullOrWhiteSpace(x.HotelBrandCode) && !string.IsNullOrWhiteSpace(x.HotelBrandName)).Select(a => a.HotelBrandCode + "," + a.HotelBrandName).Distinct().ToList();
            return new ResponseBaseViewModel<KeyWordViewModel>
            {
                Flag = new ResponseCodeViewModel { Code = 0, Message = "success", MojoryToken = this.GetToken() },
                Data = new KeyWordViewModel
                {
                    BusinessDistricts = businessDistrict.Select(a => new KeyValuePair<string, string>(a.Split(',')[0], a.Split(',')[1])).Where(x => !string.IsNullOrWhiteSpace(x.Key) && !string.IsNullOrWhiteSpace(x.Value)).OrderBy(b => b.Key).Take(10).ToList(),
                    Areas = area.Select(a => new KeyValuePair<string, string>(a.Split(',')[0], a.Split(',')[1])).Where(x => !string.IsNullOrWhiteSpace(x.Key) && !string.IsNullOrWhiteSpace(x.Value)).OrderBy(b => b.Key).Take(10).ToList(),
                    Brands = brand.Select(a => new KeyValuePair<string, string>(a.Split(',')[0], a.Split(',')[1])).Where(x => !string.IsNullOrWhiteSpace(x.Key) && !string.IsNullOrWhiteSpace(x.Value)).OrderBy(b => b.Key).Take(10).ToList()
                }
            };
        }

        [HttpPost]
        public ResponseBaseViewModel<CTripHotelSimpleResViewModel> QueryHotels([FromBody]CTripHotelSimpleReqViewModel req)
        {
            var result = _cTripHotelDesDal.GetHotelSimple(req.CityCode,null);
            return new ResponseBaseViewModel<CTripHotelSimpleResViewModel>
            {
                Flag = new ResponseCodeViewModel { Code = 0, Message = "success", MojoryToken = this.GetToken() },
                Data=new CTripHotelSimpleResViewModel
                {
                    Count=result.Count,
                    Hotels=result.Select(c => new HotelSimpleViewModel
                    {
                        HotelId = c.HotelId,
                        HotelName = c.HotelName,
                        HotelNameEN = c.HotelNameEN,
                        StarRating = c.StarRating,
                        Price = c.Price,
                        GetInfo = JsonHelper.DeserializeJsonToObject<Mzl.EntityModel.Proxy.CTripHotel.HotelDesInfo.GeoInfo>(c.GetInfo),
                        Ratings = JsonHelper.DeserializeJsonToList<Mzl.EntityModel.Proxy.CTripHotel.HotelDesInfo.Rating>(c.Ratings),
                        Pictures = JsonHelper.DeserializeJsonToList<Mzl.EntityModel.Proxy.CTripHotel.HotelDesInfo.Picture>(c.Pictures),
                        ImportantNotices = JsonHelper.DeserializeJsonToList<Mzl.EntityModel.Proxy.CTripHotel.HotelDesInfo.ImportantNotice>(c.ImportantNotices),
                        TransportationInfos = JsonHelper.DeserializeJsonToList<Mzl.EntityModel.Proxy.CTripHotel.HotelDesInfo.TransportationInfo>(c.TransportationInfos)
                    }).OrderBy(x=>x.HotelId).Skip((int.Parse(req.PageIndex)-1)*int.Parse(req.PageSize)).Take(int.Parse(req.PageSize)).ToList()
                }
            };
        }
    }  
}
