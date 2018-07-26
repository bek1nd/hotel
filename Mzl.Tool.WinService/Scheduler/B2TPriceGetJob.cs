using Mzl.Common.Scheduler;
using Mzl.EntityModel.Proxy.MuB2T;
using Mzl.EntityModel.Tool;
using Mzl.EntityModel.Tool.MuB2T;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Mzl.Tool.WinService.Scheduler
{
    public class B2TPriceGetJob : AbstractJob
    {
        
        public override void Execute()
        {
            var urls = "http://192.168.1.111:8088/MuB2TPriceQuery/InterRT";
            var taxUrls = "http://192.168.1.111:8088/MuB2TPriceQuery/TaxClient";

            List<PriceSearchQuery> querys = null;
            using (ToolDbContext dbContext = new ToolDbContext()) {
                querys = dbContext.PriceSearchQuerys.ToList();
            }
            Parallel.ForEach(querys, (itemQuery) =>
            {
                var flightNos = itemQuery.FlightNo.Split('/');
                var cabinNames = itemQuery.CabinName.Split('/');

                if (itemQuery.BeginDate.Value < DateTime.Now.AddDays(1)) {
                    itemQuery.BeginDate = DateTime.Now.AddDays(1);
                }
                foreach (var itemCabinName in cabinNames)
                    for (var date = itemQuery.BeginDate.Value; date < itemQuery.EndDate.Value; date = date.AddDays(1))
                    {
                        B2XTaxYQ taxModel = null;
                        #region 税费查询
                        try
                        {
                            B2XTaxYQ bt = new B2XTaxYQ();
                            bt.pfList = new List<PsgFare>();
                            bt.pfList.Add(new PsgFare() { psgType = "ADT" });
                            bt.salesCountry = "CN";
                            bt.salesCurrency = "CNY";
                            bt.segList = new List<Segment>();
                            bt.segList.Add(new Segment() { clazz = itemCabinName, destcd = itemQuery.ArrivePort, orgcd = itemQuery.DepartPort });
                            bt.ticketingDate = DateTime.Now.ToString("yyyy-MM-dd");
                            string postdata = JsonConvert.SerializeObject(bt);
                            string responsedata = webRequestPost(taxUrls, postdata, null).ToString().Trim();
                            var taxResults = new RtFlightTaxQueryLog()
                            {
                                ArrivePort = itemQuery.ArrivePort,
                                CreateDate = DateTime.Now,
                                //DepartCabinName = "N",
                                DepartCabinName = itemCabinName,
                                DepartPort = itemQuery.DepartPort,
                                ResponseData = responsedata,
                                RouteType = "OW",
                                DepartDate = date,
                                Status = 0
                            };
                            taxModel = JsonConvert.DeserializeObject<B2XTaxYQ>(responsedata);

                            using (ToolDbContext context = new ToolDbContext())
                            {
                                context.RtFlightTaxQueryLogs.Add(taxResults);
                                context.SaveChanges();
                            }
                        }
                        catch (Exception ex)
                        {
                            //Logger.WriteLog("税费查询接口请求异常日志" + System.DateTime.Now + ex.Message);
                        }
                        #endregion



                        foreach (var itemFlightNo in flightNos)
                        {
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
                                    cabinName = itemCabinName,
                                    //cabinName = "N",
                                    flightNo = itemFlightNo,
                                    routeDirect = "depart",
                                    routeName = itemQuery.DepartPort + "/" + itemQuery.ArrivePort,
                                    travelDate = date.ToString("yyyy-MM-dd")
                                });
                                oiiOW.routeType = "OW";
                                oiiOW.saleDate = DateTime.Now.ToString("yyyy-MM-dd");
                                oiiOW.specialFareCode = "";
                                oiiOW.taxesFlag = false;
                                string postdata = JsonConvert.SerializeObject(oiiOW);
                                string responsedata = webRequestPost(urls, postdata, null).ToString().Trim();
                                var priceQueryLog = new RtInterFlightPriceQueryLog()
                                {
                                    ArrivePort = itemQuery.ArrivePort,
                                    DepartCabinName = itemCabinName,
                                    DepartDate = date,
                                    DepartPort = itemQuery.DepartPort,
                                    FlightNo = itemFlightNo,
                                    ResponseData = responsedata,
                                    RouteType = "OW",
                                    CreateDate = DateTime.Now,
                                    Status = 0
                                };
                                OdInfoOutput model = JsonConvert.DeserializeObject<OdInfoOutput>(responsedata);


                                var flightPrice = new ETL0RtFlightPrice()
                                {
                                    ArrivePort = itemQuery.ArrivePort,
                                    
                                    CreateDate = DateTime.Now,
                                    DepartPort = itemQuery.DepartPort,
                                    DepartDate = date,
                                    FlightNo = itemFlightNo,
                                    Status = 0
                                };
                                if (taxModel != null && taxModel.pfList != null && taxModel.pfList.Any() && taxModel.pfList[0].taxList != null)
                                {
                                    flightPrice.Tax = new Decimal(taxModel.pfList[0].taxList.Sum(a => a.taxAmount ?? 0));
                                }
                                Func<string, decimal> sum = (ls) =>
                                {
                                    var s = ls.Split('/');
                                    return s.Sum(b => decimal.Parse(b));
                                };
                                flightPrice.Price = model.routeCombineList[0].odFareInfoList.Where(a => a.passengerType == "ADT").Min(b => sum(b.price));
                                flightPrice.CabinName = model.routeCombineList[0].odFareInfoList.Where(a => a.passengerType == "ADT").Where(b => sum(b.price) == flightPrice.Price).First().cabinName;
                                using (ToolDbContext context = new ToolDbContext())
                                {
                                    context.RtInterFlightPriceQueryLogs.Add(priceQueryLog);
                                    context.ETL0RtFlightPrices.Add(flightPrice);
                                    context.SaveChanges();
                                }

                                Console.WriteLine(itemFlightNo + "  " + itemCabinName + "  " + date.ToString("yyyy-MM-dd"));
                            }
                            catch(Exception ex)
                            {
                                //throw ex;

                            }
                            #endregion
                        }


                    }
            });
            Console.WriteLine("End");
            Console.Read();

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

    }
}
