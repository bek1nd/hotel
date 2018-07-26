using Mzl.EntityModel.Proxy.MuB2T;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Net;
using System.Text;
using System.Web;
using System.Web.Mvc;
using Mzl.Common.Ioc;
using Microsoft.Practices.Unity;
using Mzl.IApplication.Tool;
using Mzl.EntityModel.Tool;
using Mzl.EntityModel.Tool.MuB2T;
using System.Threading.Tasks;

namespace Mzl.Tool.Web.Controllers
{
    public class MuB2TController : Controller
    {
        // GET: MuB2T
        public ActionResult Index()
        {
            return View();
        }

        #region 国内直达航班查询接口
        public ActionResult CaresClient() {
            return View();
        }

        public JsonResult GetCaresClientData(EcfareInfoInput eii) {
            string urls = "http://192.168.1.111:8080/MuB2TPriceQuery/CaresClient";
            string eii1 = ZhiFlightSearchRequestData(new EcfareInfoInput());
            string responsedata = webRequestPost(urls, eii1, null).ToString().Trim();
            //Logger.WriteLog("直达航班查询接口解密数据:" + System.DateTime.Now + responsedata);
            string responsedata2 = "";
            if (!string.IsNullOrEmpty(responsedata))
            {
                responsedata2 = responsedata.Substring(responsedata.IndexOf("{"), responsedata.LastIndexOf("}") + 1);
            }
            else
            {
                responsedata2 = responsedata;
            }
            //Logger.WriteLog("直达航班查询接口响应数据:" + System.DateTime.Now + responsedata2);
            RtnEcfareInfo model = JsonConvert.DeserializeObject<RtnEcfareInfo>(responsedata2);
            //Logger.WriteLog("直达航班查询接口反序列化数据:" + System.DateTime.Now + model);
            return Json(model);
        }

        public string ZhiFlightSearchRequestData(EcfareInfoInput eii) {
            try
            {
                eii.USR_ID = "B2T_b2tuser";
                eii.USR_PWD = "d052bb9b5d5368669d4811c46f7e5cb8";
                eii.CHANNEL_CODE = "220";
                eii.CURRENCY_CODE = "CNY";
                eii.FARE_TYPE = "D";
                eii.GROUP_INDICATOR = "I";
                eii.JF_TYPE = "";
                eii.LANGUAGE = "zh";
                eii.LOG_FG = false;
                eii.MEM_POINTS_ITEM = null;
                eii.OFFICE_CODE = "";
                eii.PASSENGER_NUMBER = "";
                eii.PASSENGER_TYPE = "ADT";
                eii.PRODUCT_SPECIAL = "";
                eii.PRODUCT_TYPE = "FF";
                eii.ROUTE_TYPE = "OW";
                eii.SEGMENT_ITEM = new List<SegmentItem>();
                eii.SEGMENT_ITEM.Add(new SegmentItem { DEP_DT = "2017-10-27", SEGMENT = "SHAPEK", SEG_TKT_DEADLINE = "", STOP_ENG = "", fltItem = new List<FltItem>() });
                eii.SEGMENT_ITEM[0].fltItem.Add(new FltItem() { ARR_TM = "", BOOKING_RATE = "", CARRIER = "MU", CLAS_TPS = "FYB", DEP_TM = "19:30", FLT_NO = "MU5391", FLT_TP = "", clasFare = new List<ClasFare>(), f_SEAT_RATE = "", f_WEEKENDCODE = 0, j_SEAT_RATE = "", y_SEAT_RATE = "", y_WEEKENDCODE = 0 });
                eii.SEGMENT_NUMBER = "";
                eii.SPECIAL_FARE_CODE = "";
                eii.STAY_DAYS = "";
                eii.TICKETING_DATE = "2017-10-26";
                eii.SPECIAL_FARE_CODE = "";
                eii.addonFlg = "";
                eii.agtItem = null;
                eii.ffpItem = null;
                eii.kaItem = null;
                eii.paxInfo = new List<PaxInfo>() { };
                eii.promoCode = "";
                eii.selPaxNum = null;
                string postdata = JsonConvert.SerializeObject(eii);
                return postdata;
            }
            catch (Exception ex)
            {
                //Logger.WriteLog("直达航班接口查询请求数据异常日志:" + System.DateTime.Now + ex.Message);
                throw ex;
            }
        }

        #endregion

        #region 国际直达航班查询接口
        public ActionResult Inter() {
            return View();
        }

        public JsonResult GetInterData(OdInfoInput oii) {
            var urls = "http://192.168.1.111:8080/MuB2TPriceQuery/InterRT";
            string data = ZhiFlightIntertRTRequestData(oii);
            string responsedata = webRequestPost(urls, data, null).ToString().Trim();
            //Logger.WriteLog("直达航班国际RT往返查询接口响应数据:" + System.DateTime.Now + responsedata);
            OdInfoOutput model = JsonConvert.DeserializeObject<OdInfoOutput>(responsedata);

            return Json(model);
        }

        public string ZhiFlightIntertRTRequestData(OdInfoInput oii)
        {
            try
            {
                oii.cabinRank = "ECONOMY";
                oii.channelNo = 220;
                oii.currency = "CNY";
                oii.kamNo = "";
                oii.language = "ZH";
                oii.paxType = "";
                oii.promotionCode = "";
                oii.queryType = "all";
                oii.routeList = new List<RouteInfo>();
                oii.routeList.Add(new RouteInfo() {
                    cabinName = "Y",
                    flightNo = "MU577",
                    routeDirect = "depart", routeName = "SHA/LAX", travelDate = "2017-09-20" });
                oii.routeList.Add(new RouteInfo() {
                    cabinName = "Y",
                    flightNo = "MU578",
                    routeDirect = "return", routeName = "LAX/SHA", travelDate = "2017-09-30" });
                oii.routeType = "RT";
                oii.saleDate = "2017-10-12";
                oii.specialFareCode = "";
                oii.taxesFlag = false;
                string postdata = JsonConvert.SerializeObject(oii);
                return postdata;
            }
            catch (Exception ex)
            {
                //Logger.WriteLog("直达航班国际RT往返查询接口:" + System.DateTime.Now + ex.Message);
                throw ex;
            }
        }
        #endregion

        #region 直达税费查询
        public ActionResult Tax() {
            return View();
        }

        public JsonResult GetTaxData(B2XTaxYQ bt) {
            var data = TaxRequestData(bt);

            var urls = "http://192.168.1.111:8080/MuB2TPriceQuery/TaxClient";
            string responsedata = webRequestPost(urls, data, null).ToString().Trim();
            //Logger.WriteLog("税费查询接口响应数据:" + System.DateTime.Now + responsedata);
            B2XTaxYQ model = JsonConvert.DeserializeObject<B2XTaxYQ>(responsedata);
            return Json(model);

        }

        public string TaxRequestData(B2XTaxYQ bt)
        {
            try
            {
                bt.pfList = new List<PsgFare>();
                bt.pfList.Add(new PsgFare() { psgType = "ADT" });
                bt.pfList.Add(new PsgFare() { psgType = "CHD" });
                bt.salesCountry = "CN";
                bt.salesCurrency = "CNY";
                bt.segList = new List<Segment>();
                bt.segList.Add(new Segment() { clazz = "Y", destcd = "HKG", orgcd = "PVG" });
                bt.segList.Add(new Segment() { clazz = "Y", destcd = "PVG", orgcd = "HKG" });
                bt.ticketingDate = "2017-10-12";
                string postdata = JsonConvert.SerializeObject(bt);
                return postdata;
            }
            catch (Exception ex)
            {
                //Logger.WriteLog("税费查询接口请求异常日志" + System.DateTime.Now + ex.Message);
                throw ex;
            }
        }
        #endregion

        #region 中转航班查询接口
        /// <summary>
        /// 中转航班查询接口
        /// </summary>
        /// <returns></returns>
        public ActionResult ODFlightSearch()
        {
            return View();
        }

        public JsonResult GetODFlightSearchData(FlightSearchRequest fsr) {




            //请求地址
            var urls = "http://channel.ceair.com:8849/oDShopping_ODFlightSearch.do";
            //请求参数
            string jsondata = "flightSearchRequest=" + FlightSearchRequestData(fsr);
            ////写入日志
            //Logger.WriteLog("中转预定查询请求参数:" + System.DateTime.Now + jsondata);
            //加密数据
            //string jsondata2 = Compress(jsondata);
            ////写入日志
            //Logger.WriteLog("中转预定查询加密请求参数:" + System.DateTime.Now + jsondata2);
            //请求并获得结果
            string responseData = webRequestGet(urls + "?" + jsondata, null).ToString();
            //写入日志
            //Logger.WriteLog("中转预定查询未解密数据:" + System.DateTime.Now + responseData);
            //解密数据
            string data = GZipPress(responseData);
            //写入日志
            //Logger.WriteLog("中转预定查询解密数据:" + System.DateTime.Now + data);
            //手动解析获得结果
            FlightSearchResponse model = JsonConvert.DeserializeObject<FlightSearchResponse>(data);


            return Json(model);
        }


        public string FlightSearchRequestData(FlightSearchRequest fsr)
        {
            try
            {
                //string postdata = "flightSearchRequest={'depCd':'SHA','arrCd':'PEK','depDt':'2017-09-01','passNum':'1','account':'test','flightTp':'D','routeTp':'RT','retDt':'2017-09-20'}";
                //fsr.depCd = "SHA";
                //fsr.arrCd = "PEK";
                //fsr.depDt = "2017-12-02";
                //fsr.passNum = 1;
                if (string.IsNullOrWhiteSpace(fsr.retDt))
                {
                    fsr.routeTp = "OW";
                }
                else
                {
                    fsr.routeTp = "RT";
                }
                fsr.account = "b2tuser";
                //fsr.flightTp = "D";
                //fsr.routeTp = "OW";
                string postdata = JsonConvert.SerializeObject(fsr);
                return postdata;
            }
            catch (Exception ex)
            {
                //Logger.WriteLog("中转查询请求参数:" + System.DateTime.Now + ex.ToString());
                throw ex;
            }
        }
        #endregion



        public ActionResult ZhiFlightBookingRequestData() {
            try
            {
                ZhiFlightBookingRequest zfbr = new ZhiFlightBookingRequest();
                zfbr.Account = "b2tuser";
                zfbr.AgentName = "上海妙知旅电子商务服务有限公司";
                zfbr.BookingChannel = Convert.ToInt32(1);
                zfbr.FlightType = "";
                zfbr.PnrCode = "MC63JP";
                zfbr.ContactEmail = "";
                zfbr.ListSegmentInfo = new List<SegmentInfo>();
                zfbr.ListPassengerInfo = new List<PassengerInfo>();

                string postdata = JsonConvert.SerializeObject(zfbr);

                string data2 = Compress(postdata);
                var urls = "http://channel.ceair.com:8849/bookingmanage/External_FlightBookingRequest.do";
                string responsedata = webRequestPost(urls, data2, null).ToString();
                //Logger.WriteLog("直达航班预定接口加密响应数据:" + System.DateTime.Now + responsedata);
                string data = GZipPress(responsedata);
                //Logger.WriteLog("直达航班预定接口解密数据:" + System.DateTime.Now + responsedata);
                ZhiFlightBookingResponse model = JsonConvert.DeserializeObject<ZhiFlightBookingResponse>(data);
                return Content(data);
            }
            catch (Exception ex)
            {
                //Logger.WriteLog("直达航班预定接口请求参数日志:" + System.DateTime.Now + ex.Message);
                throw ex;
            }

            
        }

        #region Gzip加密
        /// <summary>
        /// 压缩
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
        public static string Compress(string param)
        {
            byte[] bytes = System.Text.Encoding.UTF8.GetBytes(param);
            string result = Convert.ToBase64String(Compress(bytes));
            return result;
        }

        public static byte[] Compress(byte[] orginalStr)
        {
            using (MemoryStream ms = new MemoryStream(orginalStr))
            {
                var msArray = ms.ToArray();
                using (MemoryStream outBuffer = new MemoryStream())
                {
                    using (GZipStream compresszipStream =
                        new GZipStream(outBuffer, CompressionMode.Compress))
                    {

                        //ms.CopyTo(compresszipStream);
                        compresszipStream.Write(orginalStr, 0, orginalStr.Length);
                    }
                    return outBuffer.ToArray();
                }
            }
        }

        #endregion

        protected string GZipPress(string result)
        {
            byte[] zippedData = Convert.FromBase64String(result);
            return (string)(System.Text.Encoding.UTF8.GetString(Decompress(zippedData)));
        }

        public static byte[] Decompress(byte[] zippedData)
        {
            using (MemoryStream ms = new MemoryStream(zippedData))
            {
                using (GZipStream compressedzipStream = new GZipStream(ms, CompressionMode.Decompress))
                {
                    using (MemoryStream outBuffer = new MemoryStream())
                    {
                        byte[] block = new byte[1024];
                        while (true)
                        {
                            int bytesRead = compressedzipStream.Read(block, 0, block.Length);
                            if (bytesRead <= 0)
                                break;
                            else
                                outBuffer.Write(block, 0, bytesRead);
                        }
                        compressedzipStream.Close();
                        return outBuffer.ToArray();
                    }
                }
            }
        }


        /// <summary>
        /// 请求B2TPost,Unicode编码
        /// </summary>
        public static string webRequestGet(string geturl, SortedList<string, string> headerInfo = null)
        {
            Stream outstream = null;
            Stream instream = null;
            StreamReader sr = null;
            HttpWebResponse response = null;
            HttpWebRequest request = null;
            Encoding encoding = Encoding.UTF8;
            try
            {
                // 设置参数  
                request = WebRequest.Create(geturl) as HttpWebRequest;
                if (headerInfo != null)
                {
                    for (int i = 0; i < headerInfo.Count; i++)
                    {
                        request.Headers.Add(headerInfo.Keys[i], headerInfo.Values[i]);
                    }
                }
                CookieContainer cookieContainer = new CookieContainer();
                request.CookieContainer = cookieContainer;
                request.AllowAutoRedirect = true;
                request.Method = "GET";
                //发送请求并获取相应回应数据  
                response = request.GetResponse() as HttpWebResponse;
                //直到request.GetResponse()程序才开始向目标网页发送Post请求  
                instream = response.GetResponseStream();
                sr = new StreamReader(instream, encoding);
                //返回结果网页（html）代码  
                string content = sr.ReadToEnd();
                return content;
            }
            catch (Exception ex)
            {
                //Logger.WriteLog("Post提交出现问题：" + ex.Message);
                if (ex.Message.Contains("无法解析此远程名称"))
                {
                    return "无法解析此远程名称";
                }
                else
                {
                    return "";
                }
            }
        }



        /// <summary>
        /// 请求接口Post
        /// </summary>
        public static string webRequestPost(string posturl, string postData, SortedList<string, string> headerInfo = null)
        {
            Stream outstream = null;
            Stream instream = null;
            StreamReader sr = null;
            HttpWebResponse response = null;
            HttpWebRequest request = null;
            Encoding encoding = Encoding.UTF8;
            byte[] data = encoding.GetBytes(postData);
            try
            {
                // 设置参数  
                request = WebRequest.Create(posturl) as HttpWebRequest;
                if (headerInfo != null)
                {
                    for (int i = 0; i < headerInfo.Count; i++)
                    {
                        request.Headers.Add(headerInfo.Keys[i], headerInfo.Values[i]);
                    }
                }
                CookieContainer cookieContainer = new CookieContainer();
                request.CookieContainer = cookieContainer;
                request.AllowAutoRedirect = true;
                request.Method = "POST";
                request.ContentType = "application/x-www-form-urlencoded";
                request.ContentLength = data.Length;
                outstream = request.GetRequestStream();
                outstream.Write(data, 0, data.Length);
                outstream.Close();
                //发送请求并获取相应回应数据  
                response = request.GetResponse() as HttpWebResponse;
                //直到request.GetResponse()程序才开始向目标网页发送Post请求  
                instream = response.GetResponseStream();
                sr = new StreamReader(instream, encoding);
                //返回结果网页（html）代码  
                string content = sr.ReadToEnd();
                return content;
            }
            catch (Exception ex)
            {
                //Logger.WriteLog("Post提交出现问题：" + ex.Message);
                if (ex.Message.Contains("无法解析此远程名称"))
                {
                    return "无法解析此远程名称";
                }
                else
                {
                    return "";
                }
            }
        }

        public ActionResult GetB2TFlightNo() {
            string departPort = "SHA/PVG/NKG/WNZ/HGH/WUX/NGB";
            string arrivePort = "AKJ/AKL/BKK/CDG/CJU/CMB/CNX/CTS/DEL/DPS/DXB/FCO/FRA/FUK/GMP/HIJ/HKG/HKT/HND/HNL/ICN/JFK/KIJ/KIX/KMQ/KUL/LAX/LED/LHR/MAD/MEL/MFM/MLE/MNL/MWX/NGO/NRT/OKA/OKJ/ORD/PNH/PUS/REP/SFO/SGN/SIN/SVO/SYD/TAE/TOY/TPE/TSA/YVR/YYZ";


            DateTime beginDate = DateTime.Today.AddDays(1);
            DateTime endDate = new DateTime(2017, 12, 31);

            string cabinNameStr = "C/D/F/I/J/P/B/E/H/K/L/M/N/R/S/T/V/W/Y";
            var cabinNames = cabinNameStr.Split('/');
            var urls = "http://192.168.1.111:8080/MuB2TPriceQuery/InterRT";
            var taxUrls = "http://192.168.1.111:8080/MuB2TPriceQuery/TaxClient";
            
            #region 获取航班号
            var departs = departPort.Split('/');
            var arrives = arrivePort.Split('/');

            foreach (var itemDepart in departs) {
                foreach (var itemArrive in arrives) {
                    using (ToolDbContext dbContext = new ToolDbContext())
                    {
                        
                        if (!dbContext.FlightNos.Where(a => a.ArrivePort == itemArrive && a.DepartPort == itemDepart).Any())
                        {
                            var flights = GetB2TFlightNo(itemDepart, itemArrive);
                            if (flights != null && flights.Any())
                            {
                                dbContext.FlightNos.Add(new EntityModel.Tool.MuB2T.FlightNo()
                                {
                                    ArrivePort = itemArrive,
                                    DepartPort = itemDepart,
                                    CreateDate = DateTime.Now,
                                    FlightNos = string.Join(",", flights),
                                    Status = 0
                                });
                            }
                        }


                        if (!dbContext.FlightNos.Where(a => a.ArrivePort == itemDepart && a.DepartPort == itemArrive).Any())
                        {
                            var flights = GetB2TFlightNo(itemArrive, itemDepart);
                            if (flights != null && flights.Any())
                            {
                                dbContext.FlightNos.Add(new EntityModel.Tool.MuB2T.FlightNo()
                                {
                                    ArrivePort = itemDepart,
                                    DepartPort = itemArrive,
                                    CreateDate = DateTime.Now,
                                    FlightNos = string.Join(",", flights),
                                    Status = 0
                                });
                            }
                        }
                        
                        dbContext.SaveChanges();
                    }
                }
            }
            #endregion

            

            #region 获取价格及税费
            List<FlightNo> ls = null;
            using (ToolDbContext dbContext = new ToolDbContext())
            {
                ls = dbContext.FlightNos.ToList();
            }
            if (ls != null && ls.Any()) {
                var flightLs = ls.Select(a => a.FlightNos.Split(',')).ToList();
                foreach(var item in ls)
                {
                    var flightNos = item.FlightNos.Split(',');


                    foreach (var flightNo in flightNos)
                        foreach (var cabinNameD in cabinNames)
                            for (var date = beginDate; date <= endDate; date = date.AddDays(1))
                            {
                                var results = new List<RtInterFlightPriceQueryLog>();
                                var taxResults = new List<RtFlightTaxQueryLog>();

                                
                                #region 价格查询
                                try
                                {
                                    OdInfoInput oiiOW = new OdInfoInput();
                                    oiiOW.cabinRank = "ECONOMY";
                                    oiiOW.channelNo = 220;
                                    oiiOW.currency = "CNY";
                                    oiiOW.kamNo = "";
                                    oiiOW.language = "ZH";
                                    oiiOW.paxType = "";
                                    oiiOW.promotionCode = "";
                                    oiiOW.queryType = "all";
                                    oiiOW.routeList = new List<RouteInfo>();
                                    oiiOW.routeList.Add(new RouteInfo()
                                    {
                                        cabinName = cabinNameD,
                                        flightNo = flightNo,
                                        routeDirect = "depart",
                                        routeName = item.DepartPort + "/" + item.ArrivePort,
                                        travelDate = date.ToString("yyyy-MM-dd")
                                    });
                                    oiiOW.routeType = "OW";
                                    oiiOW.saleDate = DateTime.Now.ToString("yyyy-MM-dd");
                                    oiiOW.specialFareCode = "";
                                    oiiOW.taxesFlag = false;
                                    string postdata = JsonConvert.SerializeObject(oiiOW);
                                    string responsedata = webRequestPost(urls, postdata, null).ToString().Trim();
                                    results.Add(new RtInterFlightPriceQueryLog()
                                    {
                                        ArrivePort = item.ArrivePort,
                                        DepartCabinName = cabinNameD,
                                        DepartDate = date,
                                        DepartPort = item.DepartPort,
                                        FlightNo = flightNo,
                                        ResponseData = responsedata,
                                        RouteType = "OW",
                                        CreateDate = DateTime.Now,
                                        Status = 0
                                    });
                                }
                                catch
                                {

                                }
                                #endregion

                                

                                #region 税费查询
                                try
                                {
                                    B2XTaxYQ bt = new B2XTaxYQ();
                                    bt.pfList = new List<PsgFare>();
                                    bt.pfList.Add(new PsgFare() { psgType = "ADT" });
                                    bt.pfList.Add(new PsgFare() { psgType = "CHD" });
                                    bt.salesCountry = "CN";
                                    bt.salesCurrency = "CNY";
                                    bt.segList = new List<Segment>();
                                    bt.segList.Add(new Segment() { clazz = cabinNameD, destcd = item.ArrivePort, orgcd = item.DepartPort });
                                    bt.ticketingDate = DateTime.Now.ToString("yyyy-MM-dd");
                                    string postdata = JsonConvert.SerializeObject(bt);
                                    string responsedata = webRequestPost(taxUrls, postdata, null).ToString().Trim();
                                    taxResults.Add(new RtFlightTaxQueryLog()
                                    {
                                        ArrivePort = item.ArrivePort,
                                        CreateDate = DateTime.Now,
                                        DepartCabinName = cabinNameD,
                                        DepartPort = item.DepartPort,
                                        ResponseData = responsedata,
                                        RouteType = "OW",
                                        Status = 0
                                    });

                                }
                                catch (Exception ex)
                                {
                                    //Logger.WriteLog("税费查询接口请求异常日志" + System.DateTime.Now + ex.Message);
                                }
                                #endregion

                                var r = ls.Where(a => a.DepartPort == item.ArrivePort && a.ArrivePort == item.DepartPort);
                                string rtFlightNos = "";
                                if (r != null && r.Any())
                                    rtFlightNos = r.First().FlightNos;
                                if (!string.IsNullOrWhiteSpace(rtFlightNos))
                                {
                                    foreach (var cabinNameR in cabinNames)
                                    {
                                        /*
                                        #region 往返价格查询
                                        foreach (var rtFlightNo in rtFlightNos.Split(','))
                                        {
                                            
                                            for (var i = 3; i < 30; i++)
                                            {
                                                try
                                                {
                                                    OdInfoInput oiiRT = new OdInfoInput();
                                                    oiiRT.cabinRank = "ECONOMY";
                                                    oiiRT.channelNo = 220;
                                                    oiiRT.currency = "CNY";
                                                    oiiRT.kamNo = "";
                                                    oiiRT.language = "ZH";
                                                    oiiRT.paxType = "";
                                                    oiiRT.promotionCode = "";
                                                    oiiRT.queryType = "all";
                                                    oiiRT.routeList = new List<RouteInfo>();
                                                    oiiRT.routeList.Add(new RouteInfo()
                                                    {
                                                        cabinName = cabinNameD,
                                                        flightNo = flightNo,
                                                        routeDirect = "depart",
                                                        routeName = item.DepartPort + "/" + item.ArrivePort,
                                                        travelDate = date.ToString("yyyy-MM-dd")
                                                    });
                                                    oiiRT.routeList.Add(new RouteInfo()
                                                    {
                                                        cabinName = cabinNameR,
                                                        flightNo = rtFlightNo,
                                                        routeDirect = "return",
                                                        routeName = item.ArrivePort + "/" + item.DepartPort,
                                                        travelDate = date.AddDays(i).ToString("yyyy-MM-dd")
                                                    });
                                                    oiiRT.routeType = "RT";
                                                    oiiRT.saleDate = DateTime.Now.ToString("yyyy-MM-dd");
                                                    oiiRT.specialFareCode = "";
                                                    oiiRT.taxesFlag = false;
                                                    string postdata = JsonConvert.SerializeObject(oiiRT);
                                                    string responsedata = webRequestPost(urls, postdata, null).ToString().Trim();
                                                    results.Add(new RtInterFlightPriceQueryLog()
                                                    {
                                                        ArrivePort = item.ArrivePort,
                                                        DepartCabinName = cabinNameD,
                                                        DepartDate = date,
                                                        DepartPort = item.DepartPort,
                                                        FlightNo = flightNo,
                                                        ResponseData = responsedata,
                                                        RouteType = "RT",
                                                        ReturnCabinName = cabinNameR,
                                                        ReturnDate = date.AddDays(i),
                                                        RtFlightNo = rtFlightNo,
                                                        CreateDate = DateTime.Now,
                                                        Status = 0
                                                    });
                                                }
                                                catch
                                                {
                                                }
                                            }
                                            
                                        }
                                        #endregion

                                        */

                                        #region 往返税费查询
                                        try
                                        {
                                            B2XTaxYQ bt = new B2XTaxYQ();
                                            bt.pfList = new List<PsgFare>();
                                            bt.pfList.Add(new PsgFare() { psgType = "ADT" });
                                            bt.pfList.Add(new PsgFare() { psgType = "CHD" });
                                            bt.salesCountry = "CN";
                                            bt.salesCurrency = "CNY";
                                            bt.segList = new List<Segment>();
                                            bt.segList.Add(new Segment() { clazz = cabinNameD, destcd = item.ArrivePort, orgcd = item.DepartPort });
                                            bt.segList.Add(new Segment() { clazz = cabinNameR, destcd = item.DepartPort, orgcd = item.ArrivePort });
                                            bt.ticketingDate = DateTime.Now.ToString("yyyy-MM-dd");
                                            string postdata = JsonConvert.SerializeObject(bt);
                                            string responsedata = webRequestPost(taxUrls, postdata, null).ToString().Trim();
                                            taxResults.Add(new RtFlightTaxQueryLog()
                                            {
                                                ArrivePort = item.ArrivePort,
                                                CreateDate = DateTime.Now,
                                                DepartCabinName = cabinNameD,
                                                DepartPort = item.DepartPort,
                                                ResponseData = responsedata,
                                                ReturnCabinName = cabinNameR,
                                                RouteType = "RT",
                                                Status = 0
                                            });

                                        }
                                        catch (Exception ex)
                                        {
                                            //Logger.WriteLog("税费查询接口请求异常日志" + System.DateTime.Now + ex.Message);
                                        }
                                        #endregion

                                    }
                                }
                                lock (this)
                                {

                                    try
                                    {
                                        using (ToolDbContext dbContext = new ToolDbContext())
                                        {
                                            #region 价格查询插入数据库
                                            if (results != null && results.Any())
                                            {
                                                foreach (var result in results)
                                                {
                                                    dbContext.RtInterFlightPriceQueryLogs.Add(result);
                                                }
                                                
                                            }
                                            #endregion

                                            #region 税费查询插入数据库
                                            if (taxResults != null && taxResults.Any())
                                            {
                                                foreach (var result in taxResults) {
                                                    dbContext.RtFlightTaxQueryLogs.Add(result);
                                                }
                                            }
                                            #endregion
                                            dbContext.SaveChanges();
                                        }
                                    }
                                    catch
                                    { }

                                }
                            }
                }
            }
            #endregion

            return Content("");
        }

        /// <summary>
        /// 获取B2T航班信息
        /// </summary>
        /// <param name="dport">出发机场三字码</param>
        /// <param name="aport">到达机场三字码</param>
        /// <returns></returns>
        private List<string> GetB2TFlightNo(string dport, string aport)
        {
            IocHelper iocHelper = new IocHelper("GetB2TFlightNo");
            IUnityContainer unityContainer = iocHelper.GetUnityContainer();
            IGetB2TFlightNoApplication getB2TFlightNoApplication= unityContainer.Resolve<IGetB2TFlightNoApplication>();
            return getB2TFlightNoApplication.GetB2TFlightNo(dport, aport);
        }
    }
}