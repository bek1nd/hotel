using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mzl.Common.JsonHelper;
using Mzl.EntityModel.Proxy.CTripHotel;
using Mzl.EntityModel.Proxy.CTripHotel.HotelDesInfo;

namespace Mzl.Proxy.Hotel.CTrip.Query
{
    public class HotelDesInfo : IHotelDesInfo
    {
        public HotelStaticInfo QueryHotelStaticInfo(string hotelId)
        {
            var hotelDesInfoResEntity = HotelApiAccess.QueryObj<HotelDesInfoReqEntity, HotelDesInfoResEntity>(new HotelDesInfoReqEntity
            {
                SearchCandidate = new SearchCandidate { HotelID = hotelId },
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

        public string QueryStr(HotelDesInfoReqEntity req)
        {
            return HotelApiAccess.QueryStr(req);
        }
    }
}
