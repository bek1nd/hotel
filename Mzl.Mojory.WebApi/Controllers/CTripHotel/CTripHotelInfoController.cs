using Mzl.Common.JsonHelper;
using Mzl.IBll.Hotel.CtripHotel;
using Mzl.IDAL.CTripHotel.SolrDAL;
using Mzl.Mojory.WebApi.Config;
using Mzl.UIModel.Base;
using Mzl.UIModel.Hotel.CTripHotel.HotelQuery;
using SolrNet.Commands.Parameters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Mzl.Mojory.WebApi.Controllers.CTripHotel
{
    public class CTripHotelInfoController : ApiController
    {
        private readonly ICTripHotelDesDal _cTripHotelDesDal;
        private readonly IHotelInfoServiceBLL _hotelInfoServiceBLL;

        public CTripHotelInfoController(ICTripHotelDesDal cTripHotelDesDal,
                                        IHotelInfoServiceBLL hotelInfoServiceBLL)

        {
            _cTripHotelDesDal = cTripHotelDesDal;
            _hotelInfoServiceBLL = hotelInfoServiceBLL;
        }
        [HttpPost]
        public ResponseBaseViewModel<CTripHotelSimpleResViewModel> QueryHotelList([FromBody]CTripHotelSimpleReqViewModel req)
        {
            return new ResponseBaseViewModel<CTripHotelSimpleResViewModel>
            {
                Flag = new ResponseCodeViewModel { Code = 0, Message = "success", MojoryToken = this.GetToken() },
                Data = _hotelInfoServiceBLL.QuerySimpleHotelList(req)
            };
            //var result = _cTripHotelDesDal.GetHotelOriginal(req.CityCode, new QueryOptions
            //{
            //    Rows = int.Parse(req.PageSize),
            //    Start = int.Parse(req.PageIndex) - 1
            //});
            //return new ResponseBaseViewModel<CTripHotelSimpleResViewModel>
            //{
            //    Flag = new ResponseCodeViewModel { Code = 0, Message = "success", MojoryToken = this.GetToken() },
            //    Data = new CTripHotelSimpleResViewModel
            //    {
            //        Count = result.Count,
            //        Hotels = result.Select(c => new HotelSimpleViewModel
            //        {
            //            HotelId = c.HotelId,
            //            HotelName = c.HotelName,
            //            HotelNameEN = c.HotelNameEN,
            //            StarRating = c.StarRating,
            //            Price = c.Price,
            //            GetInfo = JsonHelper.DeserializeJsonToObject<EntityModel.Proxy.CTripHotel.HotelDesInfo.HotelStaticInfo>(c.OriginalValue).GeoInfo,
            //            Facilities = JsonHelper.DeserializeJsonToObject<EntityModel.Proxy.CTripHotel.HotelDesInfo.HotelStaticInfo>(c.OriginalValue).Facilities.Where(x => (x.FacilityItem.Where(v => v.Name.Contains("wifi") || v.Name.Contains("机场接送") || v.Name.Contains("停车场") || v.Name.Contains("WIFI") || v.Name.Contains("健身房") || v.Name.Contains("健身") || v.Name.Contains("餐食") || v.Name.Contains("接送")).ToList()).Count > 0).ToList(),
            //            Ratings = JsonHelper.DeserializeJsonToObject<EntityModel.Proxy.CTripHotel.HotelDesInfo.HotelStaticInfo>(c.OriginalValue).Ratings,
            //            Pictures = JsonHelper.DeserializeJsonToObject<EntityModel.Proxy.CTripHotel.HotelDesInfo.HotelStaticInfo>(c.OriginalValue).Pictures,
            //            ImportantNotices = JsonHelper.DeserializeJsonToObject<EntityModel.Proxy.CTripHotel.HotelDesInfo.HotelStaticInfo>(c.OriginalValue).ImportantNotices,
            //            TransportationInfos = JsonHelper.DeserializeJsonToObject<EntityModel.Proxy.CTripHotel.HotelDesInfo.HotelStaticInfo>(c.OriginalValue).TransportationInfos
            //        }).ToList()
            //    }
            //};
        }

        [HttpPost]
        public ResponseBaseViewModel<CTripHotelSimpleResViewModel> QuerySimpleHotelList([FromBody]CTripHotelSimpleReqViewModel req)
        {
            var result = _cTripHotelDesDal.GetHotelOriginal(req.CityCode, new QueryOptions
            {
                Rows = int.Parse(req.PageSize),
                Start = int.Parse(req.PageIndex) - 1
            });
            return new ResponseBaseViewModel<CTripHotelSimpleResViewModel>
            {
                Flag = new ResponseCodeViewModel { Code = 0, Message = "success", MojoryToken = this.GetToken() },
                Data = new CTripHotelSimpleResViewModel
                {
                    Count = result.Count,
                    Hotels = result.Select(c => new HotelSimpleViewModel
                    {
                        HotelId = c.HotelId,
                        HotelName = c.HotelName,
                        HotelNameEN = c.HotelNameEN,
                        StarRating = c.StarRating,
                        Price = c.Price,
                        GetInfo = JsonHelper.DeserializeJsonToObject<EntityModel.Proxy.CTripHotel.HotelDesInfo.HotelStaticInfo>(c.OriginalValue).GeoInfo,
                        Facilities = JsonHelper.DeserializeJsonToObject<EntityModel.Proxy.CTripHotel.HotelDesInfo.HotelStaticInfo>(c.OriginalValue).Facilities.Where(x => (x.FacilityItem.Where(v => v.Name.Contains("wifi") || v.Name.Contains("机场接送") || v.Name.Contains("停车场") || v.Name.Contains("WIFI") || v.Name.Contains("健身房") || v.Name.Contains("健身") || v.Name.Contains("餐食") || v.Name.Contains("接送")).ToList()).Count > 0).ToList(),
                        Ratings = JsonHelper.DeserializeJsonToObject<EntityModel.Proxy.CTripHotel.HotelDesInfo.HotelStaticInfo>(c.OriginalValue).Ratings,
                        Pictures = JsonHelper.DeserializeJsonToObject<EntityModel.Proxy.CTripHotel.HotelDesInfo.HotelStaticInfo>(c.OriginalValue).Pictures,
                        ImportantNotices = JsonHelper.DeserializeJsonToObject<EntityModel.Proxy.CTripHotel.HotelDesInfo.HotelStaticInfo>(c.OriginalValue).ImportantNotices,
                        TransportationInfos = JsonHelper.DeserializeJsonToObject<EntityModel.Proxy.CTripHotel.HotelDesInfo.HotelStaticInfo>(c.OriginalValue).TransportationInfos
                    }).ToList()
                }
            };
        }

        [HttpPost]
        public ResponseBaseViewModel<CTripHotelInfoResViewModel> QueryHotelById([FromBody]CTripHotelInfoReqViewModel req)
        {
            var result = _cTripHotelDesDal.GetHotelById(Id,null);
            return new ResponseBaseViewModel<CTripHotelSimpleResViewModel>
            {
                Flag = new ResponseCodeViewModel { Code = 0, Message = "success", MojoryToken = this.GetToken() },
                Data = new CTripHotelSimpleResViewModel
                {
                    Count = result.Count,
                    Hotels = result.Select(c => new HotelSimpleViewModel
                    {
                        HotelId = c.HotelId,
                        HotelName = c.HotelName,
                        HotelNameEN = c.HotelNameEN,
                        StarRating = c.StarRating,
                        Price = c.Price,
                        GetInfo = JsonHelper.DeserializeJsonToObject<EntityModel.Proxy.CTripHotel.HotelDesInfo.HotelStaticInfo>(c.OriginalValue).GeoInfo,
                        Facilities = JsonHelper.DeserializeJsonToObject<EntityModel.Proxy.CTripHotel.HotelDesInfo.HotelStaticInfo>(c.OriginalValue).Facilities.Where(x => (x.FacilityItem.Where(v => v.Name.Contains("wifi") || v.Name.Contains("机场接送") || v.Name.Contains("停车场") || v.Name.Contains("WIFI") || v.Name.Contains("健身房")).ToList()).Count > 0).ToList(),
                        Ratings = JsonHelper.DeserializeJsonToObject<EntityModel.Proxy.CTripHotel.HotelDesInfo.HotelStaticInfo>(c.OriginalValue).Ratings,
                        Pictures = JsonHelper.DeserializeJsonToObject<EntityModel.Proxy.CTripHotel.HotelDesInfo.HotelStaticInfo>(c.OriginalValue).Pictures,
                        ImportantNotices = JsonHelper.DeserializeJsonToObject<EntityModel.Proxy.CTripHotel.HotelDesInfo.HotelStaticInfo>(c.OriginalValue).ImportantNotices,
                        TransportationInfos = JsonHelper.DeserializeJsonToObject<EntityModel.Proxy.CTripHotel.HotelDesInfo.HotelStaticInfo>(c.OriginalValue).TransportationInfos
                    }).ToList()
                }
            };
        }
    }
}
