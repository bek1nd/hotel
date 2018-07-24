using Mzl.Common.JsonHelper;
using Mzl.DAL.CTripHotel.SolrDAL;
using Mzl.EntityModel.Hotel.CTripHotel.SolrModel;
using Mzl.EntityModel.Proxy.CTripHotel;
using Mzl.EntityModel.Proxy.CTripHotel.HotelDesInfo;
using Mzl.EntityModel.Proxy.CTripHotel.HotelList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mzl.Proxy.Hotel.CTrip.UpdateSolr
{
    public class HotelUpdate
    {
        public void GetHotelsByCityCode(int cityCode)
        {
            StringBuilder hotelIdList = new StringBuilder();
            var hotelIdlistRes=HotelApiAccess.QueryObj<HotelIdListReqEntity, HotelIdListResEntity>(new HotelIdListReqEntity
            {
                City = cityCode,
                PageIndex = 1,
                PageSize = 4000

            });
            if (hotelIdlistRes.Total != 0)
            {
                hotelIdList = hotelIdList.Append(hotelIdlistRes.HotelIDs);
                var temp = hotelIdlistRes.Total / 4000;
                for(int i = 1; i <= temp; i++)
                {
                    hotelIdList = hotelIdList.Append(HotelApiAccess.QueryObj<HotelIdListReqEntity, HotelIdListResEntity>(new HotelIdListReqEntity
                    {
                        City = 2,
                        PageIndex = (i + 1),
                        PageSize = 4000

                    }).HotelIDs);
                }
            }
            var hotelIdArr = hotelIdList.ToString().Split(',');
            var hotels = new List<KeyWordHotel>();
            for(int i = 0; i < 1000; i++)
            {
                var hotelDesInfoResEntity = HotelApiAccess.QueryObj<HotelDesInfoReqEntity, HotelDesInfoResEntity>(new HotelDesInfoReqEntity
                {
                    SearchCandidate = new SearchCandidate { HotelID = hotelIdArr[i] },
                    Settings = new Settings
                    {
                        PrimaryLangID = "zh-cn",
                        ExtendedNodes = new string[]{"HotelStaticInfo.GeoInfo",
                                                    "HotelStaticInfo.NearbyPOIs",
                                                    "HotelStaticInfo.TransportationInfos",
                                                    "HotelStaticInfo.Brand",
                                                    "HotelStaticInfo.Group",
                                                    "HotelStaticInfo.Ratings",
                                                    "HotelStaticInfo.Policies",
                                        "HotelStaticInfo.NormalizedPolicies.ChildAndExtraBedPolicy",
                                                    "HotelStaticInfo.AcceptedCreditCards",
                                                    "HotelStaticInfo.ImportantNotices",
                                                    "HotelStaticInfo.Facilities",
                                                    "HotelStaticInfo.Pictures",
                                                    "HotelStaticInfo.Descriptions",
                                                    "HotelStaticInfo.Themes",
                                                    "HotelStaticInfo.ContactInfo",
                                                    "HotelStaticInfo.ArrivalTimeLimitInfo",
                                        "HotelStaticInfo.DepartureTimeLimitInfo",
                                                    "HotelStaticInfo.HotelTags.IsBookable"
                                                    }

                    }
                });
                var hotelStaticInfo = hotelDesInfoResEntity.HotelStaticInfo;
                if (hotelStaticInfo != null)
                {
                    hotels.Add(new KeyWordHotel
                    {
                        HotelId = hotelStaticInfo.HotelId, 
                        HotelName = hotelStaticInfo.HotelName,
                        CityName = hotelStaticInfo.GeoInfo.City?.Name,
                        CityCode = hotelStaticInfo.GeoInfo.City?.Code,
                        AreaName = hotelStaticInfo.GeoInfo.Area?.Name,
                        AreaCode = hotelStaticInfo.GeoInfo.Area?.Code,
                        BusinessDistrict = string.Join(";", hotelStaticInfo.GeoInfo.BusinessDistrict.Select(a => a.Code +"," + a.Name).ToArray()),//!string.IsNullOrEmpty(businessDistrictNames) ? businessDistrictNames : null,
                        HotelBrandName = hotelStaticInfo.Brand?.Name,
                        HotelBrandCode = hotelStaticInfo.Brand?.Code
                    });
                }
            }
            SolrApi.Adds<KeyWordHotel>(hotels,"testsolr2");

        }
        public void UpLoadHotelListToSolr(int cityCode)
        {
            StringBuilder hotelIdList = new StringBuilder();
            var hotelIdlistRes = HotelApiAccess.QueryObj<HotelIdListReqEntity, HotelIdListResEntity>(new HotelIdListReqEntity
            {
                City = cityCode,
                PageIndex = 1,
                PageSize = 4000

            });
            if (hotelIdlistRes.Total != 0)
            {
                hotelIdList = hotelIdList.Append(hotelIdlistRes.HotelIDs);
                var temp = hotelIdlistRes.Total / 4000;
                for (int i = 1; i <= temp; i++)
                {
                    hotelIdList = hotelIdList.Append(HotelApiAccess.QueryObj<HotelIdListReqEntity, HotelIdListResEntity>(new HotelIdListReqEntity
                    {
                        City = 2,
                        PageIndex = (i + 1),
                        PageSize = 4000

                    }).HotelIDs);
                }
            }
            var hotelIdArr = hotelIdList.ToString().Split(',');
            var hotels = new List<HotelSimpleInfoSolrModel>();
            Random rd = new Random();
            for (int i = 0; i < hotelIdArr.Length; i++)
            {
                var hotelDesInfoResEntity = HotelApiAccess.QueryObj<HotelDesInfoReqEntity, HotelDesInfoResEntity>(new HotelDesInfoReqEntity
                {
                    SearchCandidate = new SearchCandidate { HotelID = hotelIdArr[i] },
                    Settings = new Settings
                    {
                        PrimaryLangID = "zh-cn",
                        ExtendedNodes = new string[]{"HotelStaticInfo.GeoInfo",
                                                    "HotelStaticInfo.NearbyPOIs",
                                                    "HotelStaticInfo.TransportationInfos",
                                                    "HotelStaticInfo.Brand",
                                                    "HotelStaticInfo.Group",
                                                    "HotelStaticInfo.Ratings",
                                                    "HotelStaticInfo.Policies",
                                        "HotelStaticInfo.NormalizedPolicies.ChildAndExtraBedPolicy",
                                                    "HotelStaticInfo.AcceptedCreditCards",
                                                    "HotelStaticInfo.ImportantNotices",
                                                    "HotelStaticInfo.Facilities",
                                                    "HotelStaticInfo.Pictures",
                                                    "HotelStaticInfo.Descriptions",
                                                    "HotelStaticInfo.Themes",
                                                    "HotelStaticInfo.ContactInfo",
                                                    "HotelStaticInfo.ArrivalTimeLimitInfo",
                                        "HotelStaticInfo.DepartureTimeLimitInfo",
                                                    "HotelStaticInfo.HotelTags.IsBookable"
                                                    }

                    }
                });
                var hotelStaticInfo = hotelDesInfoResEntity.HotelStaticInfo;
                if (hotelStaticInfo != null)
                {
                    hotels.Add(new HotelSimpleInfoSolrModel
                    {
                        HotelId = hotelStaticInfo.HotelId,
                        HotelName = hotelStaticInfo.HotelName,
                        HotelNameEN = hotelStaticInfo.HotelNameEN,
                        StarRating=hotelStaticInfo.StarRating,
                        Price= rd.Next(100, 1000),
                        CityCode=hotelStaticInfo.GeoInfo.City?.Code,
                        CityName= hotelStaticInfo.GeoInfo.City?.Name,
                        AreaCode=hotelStaticInfo.GeoInfo.Area?.Code,
                        AreaName=hotelStaticInfo.GeoInfo.Area?.Name,
                        PostalCode=string.IsNullOrWhiteSpace(hotelStaticInfo.GeoInfo.PostalCode)?null:hotelStaticInfo.GeoInfo.PostalCode,
                        Address=hotelStaticInfo.GeoInfo?.Address,
                        AdjacentIntersection=hotelStaticInfo.GeoInfo?.AdjacentIntersection,
                        GetInfo =JsonHelper.SerializeObject(hotelStaticInfo.GeoInfo),
                        Ratings=JsonHelper.SerializeObject(hotelStaticInfo.Ratings),
                        Pictures=JsonHelper.SerializeObject(hotelStaticInfo.Pictures),
                        ImportantNotices=JsonHelper.SerializeObject(hotelStaticInfo.ImportantNotices),
                        TransportationInfos=JsonHelper.SerializeObject(hotelStaticInfo.TransportationInfos)
                    });
                }
            }
            SolrApi.Adds<HotelSimpleInfoSolrModel>(hotels,"simplehotel");
        }
        public void UpLoadHotelSimpleInfoToSolr(int[] cityCodes)
        {
            foreach (var i in cityCodes)
            {
                Random rd = new Random();
                var hotelIdList = GetHotelIdList(i);
                var hotels = new List<HotelSimpleInfoSolrModel>();
                for (int k = 0; k < hotelIdList.Length; k++)
                {

                    try
                    {
                        var hotelStaticInfo = GetHotelInfo(hotelIdList[k]);
                        hotels.Add(new HotelSimpleInfoSolrModel
                        {
                            HotelId = hotelStaticInfo.HotelId,
                            HotelName = hotelStaticInfo.HotelName,
                            HotelNameEN = hotelStaticInfo.HotelNameEN,
                            StarRating = hotelStaticInfo.StarRating,
                            Price = rd.Next(100, 1000),
                            CityCode = hotelStaticInfo.GeoInfo.City?.Code,
                            CityName = hotelStaticInfo.GeoInfo.City?.Name,
                            AreaCode = hotelStaticInfo.GeoInfo.Area?.Code,
                            AreaName = hotelStaticInfo.GeoInfo.Area?.Name,
                            PostalCode = string.IsNullOrWhiteSpace(hotelStaticInfo.GeoInfo.PostalCode) ? null : hotelStaticInfo.GeoInfo.PostalCode,
                            Address = hotelStaticInfo.GeoInfo?.Address,
                            AdjacentIntersection = hotelStaticInfo.GeoInfo?.AdjacentIntersection,
                            GetInfo = JsonHelper.SerializeObject(hotelStaticInfo.GeoInfo),
                            Ratings = JsonHelper.SerializeObject(hotelStaticInfo.Ratings),
                            Pictures = JsonHelper.SerializeObject(hotelStaticInfo.Pictures),
                            ImportantNotices = JsonHelper.SerializeObject(hotelStaticInfo.ImportantNotices),
                            TransportationInfos = JsonHelper.SerializeObject(hotelStaticInfo.TransportationInfos)
                        });
                        if (k == hotelIdList.Length - 1)
                        {
                            SolrApi.Adds<HotelSimpleInfoSolrModel>(hotels, "simplehotel");
                            break;
                        }
                        else if ((k + 1) % 1000 == 0)
                        {
                            SolrApi.Adds<HotelSimpleInfoSolrModel>(hotels, "simplehotel");
                            hotels.Clear();
                        }

                    }
                    catch (Exception e)
                    {
                        System.Console.WriteLine(e.Message);
                        continue;
                    }

                }
            }
        }
        public void UpLoadHotelOriginalInfoToSolr(int[] cityCodes)
        {
            foreach(var i in cityCodes)
            {
                Random rd = new Random();
                var hotelIdList = GetHotelIdList(i);
                var hotels = new List<HotelOriginalInfoSolrModel>();
                for (int k = 0; k < hotelIdList.Length; k++)
                {
                    
                    try
                    {
                        var hotelStaticInfo = GetHotelInfo(hotelIdList[k]);
                        hotels.Add(new HotelOriginalInfoSolrModel
                        {
                            HotelId = hotelStaticInfo.HotelId,
                            HotelName = hotelStaticInfo.HotelName,
                            HotelNameEN = hotelStaticInfo.HotelNameEN,
                            StarRating = hotelStaticInfo.StarRating,
                            Price = rd.Next(100, 1000),
                            CityCode = hotelStaticInfo.GeoInfo.City?.Code,
                            CityName = hotelStaticInfo.GeoInfo.City?.Name,
                            AreaCode = hotelStaticInfo.GeoInfo.Area?.Code,
                            AreaName = hotelStaticInfo.GeoInfo.Area?.Name,
                            PostalCode = string.IsNullOrWhiteSpace(hotelStaticInfo.GeoInfo.PostalCode) ? null : hotelStaticInfo.GeoInfo.PostalCode,
                            Address = hotelStaticInfo.GeoInfo?.Address,
                            AdjacentIntersection = hotelStaticInfo.GeoInfo?.AdjacentIntersection,
                            OriginalValue = JsonHelper.SerializeObject(hotelStaticInfo)
                        });
                        if (k == hotelIdList.Length - 1)
                        {
                            SolrApi.Adds<HotelOriginalInfoSolrModel>(hotels, "originalhotel");
                            break;
                        }
                        else if ((k+1) % 1000 == 0)
                        {
                            SolrApi.Adds<HotelOriginalInfoSolrModel>(hotels, "originalhotel");
                            hotels.Clear();
                        }
                        
                    }
                    catch (Exception e)
                    {
                        System.Console.WriteLine(e.Message);
                        continue;
                    }

                }
            }
            
        }
        public string[] GetHotelIdList(int cityCode)
        {
            StringBuilder hotelIdList = new StringBuilder();
            var hotelIdlistRes = HotelApiAccess.QueryObj<HotelIdListReqEntity, HotelIdListResEntity>(new HotelIdListReqEntity
            {
                City = cityCode,
                PageIndex = 1,
                PageSize = 4000

            });
            if (hotelIdlistRes.Total != 0)
            {
                hotelIdList = hotelIdList.Append(hotelIdlistRes.HotelIDs);
                var temp = hotelIdlistRes.Total / 4000;
                for (int i = 1; i <= temp; i++)
                {
                    hotelIdList = hotelIdList.Append(HotelApiAccess.QueryObj<HotelIdListReqEntity, HotelIdListResEntity>(new HotelIdListReqEntity
                    {
                        City = 2,
                        PageIndex = (i + 1),
                        PageSize = 4000

                    }).HotelIDs);
                }
            }
            return hotelIdList.ToString().Split(',');
        }
        public HotelStaticInfo GetHotelInfo(string hotelId)
        {
            var hotelDesInfoResEntity = HotelApiAccess.QueryObj<HotelDesInfoReqEntity, HotelDesInfoResEntity>(new HotelDesInfoReqEntity
            {
                SearchCandidate = new SearchCandidate { HotelID = hotelId  },
                Settings = new Settings
                {
                    PrimaryLangID = "zh-cn",
                    ExtendedNodes = new string[]{"HotelStaticInfo.GeoInfo",
                                                    "HotelStaticInfo.NearbyPOIs",
                                                    "HotelStaticInfo.TransportationInfos",
                                                    "HotelStaticInfo.Brand",
                                                    "HotelStaticInfo.Group",
                                                    "HotelStaticInfo.Ratings",
                                                    "HotelStaticInfo.Policies",
                                        "HotelStaticInfo.NormalizedPolicies.ChildAndExtraBedPolicy",
                                                    "HotelStaticInfo.AcceptedCreditCards",
                                                    "HotelStaticInfo.ImportantNotices",
                                                    "HotelStaticInfo.Facilities",
                                                    "HotelStaticInfo.Pictures",
                                                    "HotelStaticInfo.Descriptions",
                                                    "HotelStaticInfo.Themes",
                                                    "HotelStaticInfo.ContactInfo",
                                                    "HotelStaticInfo.ArrivalTimeLimitInfo",
                                        "HotelStaticInfo.DepartureTimeLimitInfo",
                                                    "HotelStaticInfo.HotelTags.IsBookable"
                                                    }

                }
            });
            return hotelDesInfoResEntity.HotelStaticInfo;
        }
    }
}
