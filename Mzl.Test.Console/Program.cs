using Mzl.EntityModel.Hotel.Elong;
using Mzl.Proxy.Hotel.Elong.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mzl.EntityModel.Proxy.CTripHotel;
using Mzl.EntityModel.Proxy.CTripHotel.RoomDesInfo;
using Mzl.EntityModel.Proxy.CTripHotel.ChangeInfo;
using Mzl.Proxy.Hotel.CTrip.Query;
using Mzl.Proxy.Hotel.CTrip;
using Mzl.EntityModel.Proxy.CTripHotel.RoomStatusChange;
using Mzl.Bll.Hotel.CtripHotel;
using Mzl.DAL.CTripHotel.SolrDAL;
using Mzl.Common.JsonHelper;
using System.Net;
using System.IO;
using Mzl.Bll.Hotel.CtripHotel.SolrService;
using Mzl.Proxy.Hotel.CTrip.UpdateSolr;

namespace Mzl.Test.Console
{
    class Program
    {
        static void Main(string[] args)
        {
            //艺龙
            //var geo = new Mzl.Proxy.Hotel.Elong.StaticData.HotelGeoService().GetAll();
            //var result = new HotelListService().Query(new HotelListRequestEntity() { ArrivalDate = DateTime.Today.AddDays(2), DepartureDate = DateTime.Today.AddDays(4), CheckInPersonAmount = 1, CityId="0101" });
            //var resultHotel = new Mzl.Proxy.Hotel.Elong.Query.HotelDetail().Query(new HotelDetailRequestEntity() { HotelIds = "50101002", ArrivalDate = DateTime.Today.AddDays(2), DepartureDate = DateTime.Today.AddDays(4) });


            //携程酒店列表
            //var hil = new Mzl.Proxy.Hotel.CTrip.Query.HotelIdList();
            //var test = new HotelIdListRequestEntity();
            //test.City = 1;
            //test.PageIndex = 1;
            //test.PageSize = 1000;
            //var ret = hil.QueryStr(test);

            //酒店详情
            //var hdi = new Mzl.Proxy.Hotel.CTrip.Query.HotelDesInfo();
            //var hdre = new HotelDesInfoReqEntity
            //{
            //    SearchCandidate = new EntityModel.Proxy.CTripHotel.SearchCandidate { HotelID = 480728 },
            //    Settings = new Settings
            //    {
            //        PrimaryLangID = "zh-cn",
            //        ExtendedNodes = new string[]{"HotelStaticInfo.GeoInfo",
            //                                    "HotelStaticInfo.NearbyPOIs",
            //                                    "HotelStaticInfo.TransportationInfos",
            //                                    "HotelStaticInfo.Brand",
            //                                    "HotelStaticInfo.Group",
            //                                    "HotelStaticInfo.Ratings",
            //                                    "HotelStaticInfo.Policies",
            //                        "HotelStaticInfo.NormalizedPolicies.ChildAndExtraBedPolicy",
            //                                    "HotelStaticInfo.AcceptedCreditCards",
            //                                    "HotelStaticInfo.ImportantNotices",
            //                                    "HotelStaticInfo.Facilities",
            //                                    "HotelStaticInfo.Pictures",
            //                                    "HotelStaticInfo.Descriptions",
            //                                    "HotelStaticInfo.Themes",
            //                                    "HotelStaticInfo.ContactInfo",
            //                                    "HotelStaticInfo.ArrivalTimeLimitInfo",
            //                        "HotelStaticInfo.DepartureTimeLimitInfo",
            //                                    "HotelStaticInfo.HotelTags.IsBookable"
            //                                    }

            //    }
            //};
            //var ret2 = hdi.Query(hdre);
            //var str = hdi.QueryStr(hdre);

            //酒店静态信息2
            //var resultObj = HotelApiAccess.QueryObj<HotelDesInfoReqEntity, HotelDesInfoResEntity>(new HotelDesInfoReqEntity
            //{
            //    SearchCandidate = new EntityModel.Proxy.CTripHotel.SearchCandidate { HotelID = 480728 },
            //    Settings = new Settings
            //    {
            //        PrimaryLangID = "zh-cn",
            //        ExtendedNodes = new string[]{"HotelStaticInfo.GeoInfo",
            //                                    "HotelStaticInfo.NearbyPOIs",
            //                                    "HotelStaticInfo.TransportationInfos",
            //                                    "HotelStaticInfo.Brand",
            //                                    "HotelStaticInfo.Group",
            //                                    "HotelStaticInfo.Ratings",
            //                                    "HotelStaticInfo.Policies",
            //                        "HotelStaticInfo.NormalizedPolicies.ChildAndExtraBedPolicy",
            //                                    "HotelStaticInfo.AcceptedCreditCards",
            //                                    "HotelStaticInfo.ImportantNotices",
            //                                    "HotelStaticInfo.Facilities",
            //                                    "HotelStaticInfo.Pictures",
            //                                    "HotelStaticInfo.Descriptions",
            //                                    "HotelStaticInfo.Themes",
            //                                    "HotelStaticInfo.ContactInfo",
            //                                    "HotelStaticInfo.ArrivalTimeLimitInfo",
            //                        "HotelStaticInfo.DepartureTimeLimitInfo",
            //                                    "HotelStaticInfo.HotelTags.IsBookable"
            //                                    }

            //    }
            //});


            //房型
            //var rdi = new Mzl.Proxy.Hotel.CTrip.Query.RoomDesInfo();
            //var rdireq = new RoomDesInfoReqEntity()
            //{
            //    SearchCandidate = new EntityModel.Proxy.CTripHotel.SearchCandidate
            //    {
            //        HotelID = 436187,
            //        RoomIds = new string[] { "18162" }
            //    },
            //    Settings = new Settings
            //    {
            //        PrimaryLangID = "zh-cn",
            //        ExtendedNodes = new string[]{ "RoomTypeInfo.Facilities",
            //                                        "RoomTypeInfo.Pictures",
            //                                        "RoomTypeInfo.Descriptions",
            //                                        "RoomTypeInfo.Smoking",
            //                                        "RoomTypeInfo.BroadNet",
            //                                        "RoomTypeInfo.ChildLimit",
            //                                        "RoomTypeInfo.RoomBedInfos",
            //                                        "RoomInfo.ApplicabilityInfo",
            //                                        "RoomInfo.Smoking",
            //                                        "RoomInfo.BroadNet",
            //                                        "RoomInfo.RoomBedInfos",
            //                                        "RoomInfo.RoomFGToPPInfo",
            //                                        "RoomInfo.RoomGiftInfos",
            //                                        "RoomInfo.ChannelLimit",
            //                                        "RoomInfo.ExpressCheckout",
            //                                        "RoomInfo.RoomTags",
            //                                        "RoomInfo.BookingRules",
            //                                        "RoomInfo.Descriptions"

            //                                    }

            //    }
            //};
            //var rdires = rdi.Query(rdireq);
            //var rdiresStr = rdi.QueryStr(rdireq);

            //酒店和房型增量
            //var ci = new GetChangeInfo();
            //var cireq = new ChangeInfoReqEntity
            //{
            //    SearchCandidate = new EntityModel.Proxy.CTripHotel.ChangeInfo.SearchCandidate
            //    {
            //        StartTime = "2017-11-07T21:00:00",
            //        Duration = 0
            //    },
            //    Settings = new Settings
            //    {
            //        IsShowChangeDetails = "F"
            //    },
            //    PagingSettings = new PagingSettings
            //    {
            //        PageSize = 200,
            //        LastRecordID = "0"
            //    }
            //};
            //var cires = ci.Query(cireq);
            //var ciresStr = ci.QueryStr(cireq);

            //房型上下线
            //var resultStr = HotelApiAccess.QueryStr(new RoomStatusChangeReqEntity
            //{
            //    SearchCandidate = new EntityModel.Proxy.CTripHotel.RoomStatusChange.SearchCandidate
            //    {
            //        DateTimeRange = new DateTimeRange
            //        {
            //            Start = "2017-11-28T10:34:00",
            //            End = "2017-11-28T11:33:00"
            //        }
            //    }
            //}, "RoomStatusChange");

            //通用接口
            //var resultStr = HotelApiAccess.QueryObj<RoomStatusChangeReqEntity, RoomStatusChangeResEntity>(new RoomStatusChangeReqEntity
            //{
            //    SearchCandidate = new EntityModel.Proxy.CTripHotel.RoomStatusChange.SearchCandidate
            //    {
            //        DateTimeRange = new DateTimeRange
            //        {
            //            Start = "2017-11-28T10:34:00",
            //            End = "2017-11-28T11:33:00"
            //        }
            //    }
            //}, "RoomStatusChange");

            //solrTest
            //var tt = new TestSolr
            //{
            //   add=new Add
            //   {
            //       doc=new Doc
            //       {
            //           first2="caocaocao",
            //           last="goodluck"
            //       }
            //   }
            //};
            //var str = JsonHelper.SerializeObject(tt);
            //var strfinal = Index("str");

            //upload
            //var tt = new AddHotelDescription();
            //tt.AddHotels(480728);
            var hd = new HotelUpdate();
            hd.UpLoadHotelSimpleInfoToSolr(new int[] { 2 });

            //download solr
            //var ctripHoteldal = new CTripHotelDesDal();
            //var hotel=ctripHoteldal.QueryById(480728);
        }

        private static string Index(string strData)
        {
            string url = "http://localhost:8983/solr/mycore/update?_=1531893458023&commitWithin=1000&overwrite=true&wt=json";

            //string strData = @"<add>
            //    <doc>
            //        <field name='id'>2</field>
            //        <field name='title'>平凡的世界（根据路遥同名小说改变）</field>
            //        <field name='author'>路遥</field>
            //    </doc>
            //</add>";

            byte[] bytes;
            bytes = System.Text.Encoding.UTF8.GetBytes(strData);


            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            request.Method = "POST";
            request.Accept = "*/*";
            request.ContentLength = bytes.Length;
            //request.ContentType = "text/xml; encoding='utf-8'";
            request.ContentType = "text/json; encoding='utf-8'";

            Stream requestStream = request.GetRequestStream();
            requestStream.Write(bytes, 0, bytes.Length);
            requestStream.Close();


            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            if (response.StatusCode == HttpStatusCode.OK)
            {
                Stream responseStream = response.GetResponseStream();
                string strJson = new StreamReader(responseStream).ReadToEnd();
                //Console.WriteLine(strJson);
                return strJson;
            }
            return "faield";

        }
    }
}
