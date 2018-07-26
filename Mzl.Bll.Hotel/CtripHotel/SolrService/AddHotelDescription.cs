using Mzl.DAL.CTripHotel.SolrDAL;
using Mzl.EntityModel.Proxy.CTripHotel;
using Mzl.EntityModel.Proxy.CTripHotel.RoomStatusChange;
using Mzl.IBll.Hotel.CtripHotel.SolrService;
using Mzl.IDAL.CTripHotel.SolrDAL;
using Mzl.Proxy.Hotel.CTrip;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mzl.Bll.Hotel.CtripHotel.SolrService
{
    public class AddHotelDescription : IAddHotelDescription
    {
        private ICTripHotelDesDal _cTripHotelDesDal;
        public AddHotelDescription(ICTripHotelDesDal cTripHotelDesDal)
        {
            _cTripHotelDesDal = cTripHotelDesDal;
        }
        public AddHotelDescription()
        {
            _cTripHotelDesDal = new CTripHotelDesDal();
        }
        public void AddHotels(string hotelId)
        {
            var hotelDesReq = new HotelDesInfoReqEntity
            {
                SearchCandidate = new EntityModel.Proxy.CTripHotel.SearchCandidate { HotelID = hotelId },
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
            };

            var resultObj = HotelApiAccess.QueryObj<HotelDesInfoReqEntity, HotelDesInfoResEntity>(hotelDesReq);
            //_cTripHotelDesDal.AddHotelDesToSolr();


        }
    }
}
