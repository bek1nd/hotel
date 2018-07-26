using Mzl.EntityModel.Proxy.CTripHotel.SearchHotelLowPrice;
using Mzl.IBll.Hotel.CtripHotel;
using Mzl.Proxy.Hotel.CTrip.Query;
using Mzl.UIModel.Hotel.CTripHotel.HotelQuery;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mzl.Bll.Hotel.CtripHotel
{
    public class HotelInfoServiceBLL : IHotelInfoServiceBLL
    {
        private IHotelLowPrice _hotelLowPrice { get; set; }
        private IHotelDesInfo _hotelDesInfo { get; set; }
        public HotelInfoServiceBLL(IHotelLowPrice hotelLowPrice,
                                    IHotelDesInfo hotelDesInfo)
        {
            _hotelLowPrice = hotelLowPrice;
            _hotelDesInfo = hotelDesInfo;
        }
        public CTripHotelSimpleResViewModel QuerySimpleHotelList(CTripHotelSimpleReqViewModel req)
        {
            var lowPriceReq = new LowPriceReqEntity
            {
                SearchTypeEntity = new SearchTypeEntity
                {
                    SearchType = "WirelessSearch",
                    HotelCount = 100,
                },
                PublicSearchParameter = new PublicSearchParameter
                {
                    City = int.Parse(req.CityCode),
                    CheckInDate = req.StartTime,
                    CheckOutDate = req.EndTime,
                    //OnlyPPPrice = req.OnlyPPPrice ? req.OnlyPPPrice : false,
                    //OnlyFGPrice = req.OnlyFGPrice ? req.OnlyFGPrice : false,
                    //IsJustifyConfirm = req.IsJustifyConfirm.Equals("T") ? "T" : null,
                }
            };
            var lowPriceRes = _hotelLowPrice.QueryObj(lowPriceReq);
            var hotelDataList = lowPriceRes.HotelDataLists.ToList();
            var hotelIds = lowPriceRes.AllHotelID.Split(',');
            if(hotelIds.Length > 100)
            {
                var x = hotelIds.Length / 100;
                for(int i = 1; i <= x; i++)
                {
                    if (hotelIds.Length % 100 == 0)
                    {
                        if (i == hotelIds.Length / 100)
                            continue;
                        
                    }
                    string hotelIdsReqTemp = "";
                    for(int k = i * 100 ; k < (i + 1) * 100 && k<hotelIds.Length ; k++)
                    {
                        hotelIdsReqTemp += hotelIds[k] + ',';
                    }
                    var lowPriceResTemp = _hotelLowPrice.QueryObj(new LowPriceReqEntity
                    {
                        SearchTypeEntity = new SearchTypeEntity
                        {
                            SearchType = "WirelessSearch",
                            HotelCount = 100,
                        },
                        PublicSearchParameter = new PublicSearchParameter
                        {
                            City = int.Parse(req.CityCode),
                            HotelList=hotelIdsReqTemp,
                            CheckInDate = req.StartTime,
                            CheckOutDate = req.EndTime,
                            //OnlyPPPrice = req.OnlyPPPrice ? req.OnlyPPPrice : false,
                            //OnlyFGPrice = req.OnlyFGPrice ? req.OnlyFGPrice : false,
                            //IsJustifyConfirm = req.IsJustifyConfirm.Equals("T") ? "T" : null,
                        }
                    });
                    hotelDataList.AddRange(lowPriceResTemp.HotelDataLists.ToList());
                }
            }
            for(int i = 0; i < hotelDataList.Count; i++)
            {
                hotelDataList[i].HotelStaticInfo = _hotelDesInfo.QueryHotelStaticInfo(hotelDataList[i].HotelStatusEntity.Hotel.ToString());
            }

            //筛选星级
            if (req.Star!=null && !req.Star.Equals("default"))
            {
                hotelDataList = hotelDataList.Where(x =>
                {
                    foreach (var s in req.Star.Split(','))
                    {
                        if ((int)x.HotelStaticInfo.StarRating == int.Parse(s))
                        {
                            return true;
                        }
                    }
                    return false;
                }).ToList();
            }

            //筛选品牌
            if (req.Brand!=null && !req.Brand.Equals("default"))
            {
                hotelDataList = hotelDataList.Where(x =>
                {
                    foreach (var b in req.Brand.Split(','))
                    {
                        if (int.Parse(x.HotelStaticInfo.Brand.Code) == int.Parse(b))
                        {
                            return true;
                        }
                    }
                    return false;
                }).ToList();
            }

            //筛选县区
            if (req.Area!=null && !req.Area.Equals("default"))
            {
                hotelDataList = hotelDataList.Where(x =>
                {
                    if (int.Parse(x.HotelStaticInfo.GeoInfo.Area.Code) == int.Parse(req.Area))
                    {
                        return true;
                    }
                    return false;
                }).ToList();
            }

            //筛选商圈
            if (req.BD!=null && !req.BD.Equals("default"))
            {
                hotelDataList = hotelDataList.Where(x =>
                {
                    foreach(var bd in x.HotelStaticInfo.GeoInfo.BusinessDistrict)
                    {
                        if (int.Parse(bd.Code) == int.Parse(req.BD))
                            return true;
                    }
                    return false;
                }).ToList();
            }

            //筛选价格
            if (req.Price!=null && !req.Price.Equals("default"))
            {
                hotelDataList = hotelDataList.Where(x =>
                {
                    if (req.Price.Split(',').Length == 1)
                    {
                        if (int.Parse(req.Price) == 200)
                        {
                            if ((int)x.HotelStatusEntity.MinPrice <= 200)
                            {
                                return true;
                            }
                        }
                        else
                        {
                            if ((int)x.HotelStatusEntity.MinPrice > 800)
                            {
                                return true;
                            }
                        }
                    }
                    else
                    {
                        var minP = int.Parse(req.Price.Split(',')[0]);
                        var maxP = int.Parse(req.Price.Split(',')[1]);
                        if ((int)x.HotelStatusEntity.MinPrice >= minP && (int)x.HotelStatusEntity.MinPrice <= maxP)
                            return true;
                    }
                    return false;
                }).ToList();
            }
            return new CTripHotelSimpleResViewModel
            {
                Count = hotelDataList.Count,
                Hotels = hotelDataList.OrderBy(x => x.HotelStaticInfo.HotelId)
                .Skip((int.Parse(req.PageIndex) - 1) * int.Parse(req.PageSize))
                .Take(int.Parse(req.PageSize))
                .Select(c => new HotelSimpleViewModel
                {
                    HotelId = c.HotelStaticInfo.HotelId,
                    HotelName = c.HotelStaticInfo.HotelName,
                    HotelNameEN = c.HotelStaticInfo.HotelNameEN,
                    StarRating = c.HotelStaticInfo.StarRating,
                    Price = (int)c.HotelStatusEntity.MinPrice,
                    GetInfo = c.HotelStaticInfo.GeoInfo,
                    Facilities = c.HotelStaticInfo.Facilities.Where(x => (x.FacilityItem.Where(v => v.Name.Contains("wifi") || v.Name.Contains("机场接送") || v.Name.Contains("停车场") || v.Name.Contains("WIFI") || v.Name.Contains("健身房") || v.Name.Contains("健身") || v.Name.Contains("餐食") || v.Name.Contains("接送")).ToList()).Count > 0).ToList(),
                    Ratings = c.HotelStaticInfo.Ratings,
                    Pictures = c.HotelStaticInfo.Pictures,
                    ImportantNotices = c.HotelStaticInfo.ImportantNotices,
                    TransportationInfos = c.HotelStaticInfo.TransportationInfos
                }).ToList()
            };
        }
    }
}
