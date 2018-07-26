using System;
using System.Text;
using Mzl.IBLL.Train.Server;
using Mzl.IBLL.Train.Server.BLL;
using Mzl.Common.PostHelper;
using Mzl.DomainModel.Train.Server;
using Mzl.Common.LogHelper;
using Mzl.Common.MD5Helper;
using Mzl.Common.JsonHelper;
using System.Collections.Generic;
using Mzl.Common.AutoMapperHelper;
using System.Linq;
using Mzl.DomainModel.Enum;

namespace Mzl.BLL.Train.Server.BLL
{
    public class QueryTrainServerBLL : IQueryTrainServerBLL<List<TraTravelInfoModel>>
    {
        private readonly string postUrl = "http://searchtrain.hangtian123.net/trainSearch";

        public string Data { get; set; }
        public string DoGetRequest()
        {
            return string.Empty;
        }

        public string DoPostRequest()
        {
            string date = DateTime.Now.ToString();
            LogHelper.WriteLog("行程查询接口:" + date + "||||||" + Data, "SearchTrain");
            string post = PostHelper.PostUrl(postUrl, Data, Encoding.UTF8);
            LogHelper.WriteLog("行程查询接口返回:" + date + "||||||" + post, "SearchTrain");
            return post;
        }

        public List<TraTravelInfoModel> DoQueryTrain()
        {
            //1.访问接口获取Json字符串
            string getStr = DoPostRequest();

            TraQueryTrainResponseModel trainResponseModel = new TraQueryTrainResponseModel ();
            BaseOutputModel model = new BaseOutputModel();
            //2.转换成对象
            try
            {
                 model = JsonHelper.DeserializeJsonToObject<BaseOutputModel>(getStr);
                trainResponseModel = JsonHelper.DeserializeJsonToObject<TraQueryTrainResponseModel>(getStr);
            }
            catch (Exception)
            {

                throw new Exception("查询未成功,原因是： "+ model.msg );
            }
           
            if (trainResponseModel.code == 200)
            { 
                List<TraTravelInfoModel> resultList = new List<TraTravelInfoModel>();

                #region 对象转换


                if (trainResponseModel.code == 200)
                {
                    foreach (var m in trainResponseModel.data)
                    {
                        TraTravelInfoModel infoModel = new TraTravelInfoModel();
                        infoModel = AutoMapperHelper.DoMap<TraQueryTrainResponseDateModel, TraTravelInfoModel>(m);

                        resultList.Add(infoModel);
                        infoModel.DetailList = new List<TraTravelInfoDetailModel>();
                        //F
                        if (m.dw_num != "--" && m.dw_num !="*" && !string.IsNullOrEmpty(m.dw_price) && m.dw_price.Trim() !="" )
                        {
                            var exa = TrainTypeEnum.DW;
                            exa.SeatPrice = m.dwx_price;
                            exa.SeatCount = m.dw_num;
                            infoModel.DetailList.Add(exa);
                           
                        }
                        //9
                        if (m.swz_num != "--" && m.swz_num!="*" && !string.IsNullOrEmpty(m.swz_price) && m.swz_price.Trim() != "")
                        {
                            var exa = TrainTypeEnum.SWZ;
                            exa.SeatPrice = m.swz_price;
                            exa.SeatCount = m.swz_num;
                           infoModel.DetailList.Add(exa);

                            
                        }
                        //P
                        if (m.tdz_num != "--"&& m.tdz_num != "*" && !string.IsNullOrEmpty(m.tdz_price) && m.tdz_price.Trim() != "")
                        {
                            var exa = TrainTypeEnum.TDZ;
                            exa.SeatPrice = m.tdz_price;
                            exa.SeatCount = m.tdz_num;
                           infoModel.DetailList.Add(exa);
                        }
                       
                        //M
                        if (m.ydz_num != "--" && m.ydz_num != "*" && !string.IsNullOrEmpty(m.ydz_price) && m.ydz_price.Trim() != "")
                        {
                            var exa = TrainTypeEnum.YDZ;
                            exa.SeatPrice = m.ydz_price;
                            exa.SeatCount = m.ydz_num;
                           infoModel.DetailList.Add(exa);
                        }
                        //O
                        if (m.edz_num != "--" && m.edz_num != "*" && !string.IsNullOrEmpty(m.edz_price) && m.edz_price.Trim() != "")
                        {
                            var exa = TrainTypeEnum.EDZ;
                            exa.SeatPrice = m.edz_price;
                            exa.SeatCount = m.edz_num;
                           infoModel.DetailList.Add(exa);
                        }

                        //6
                        if (m.gjrw_num != "--" && m.gjrw_num != "*" && !string.IsNullOrEmpty(m.gjrw_price) && m.gjrw_price.Trim() != "")
                        {
                            var exa = TrainTypeEnum.GJRW;
                            exa.SeatPrice = m.gjrw_price;
                            exa.SeatCount = m.gjrw_num;
                           infoModel.DetailList.Add(exa);

                        }

                        //4
                        if (m.rw_num != "--" &&  m.rw_num != "*" && !string.IsNullOrEmpty(m.rw_price) && m.rw_price.Trim() != "")
                        {
                            var exa = TrainTypeEnum.RW;
                            exa.SeatPrice = m.rwx_price;
                            exa.SeatCount = m.rw_num;
                           infoModel.DetailList.Add(exa);
                        }

                        //3
                        if (m.yw_num != "--" && m.yw_num != "*" && !string.IsNullOrEmpty(m.yw_price) && m.yw_price.Trim() != "")
                        {
                            var exa = TrainTypeEnum.YW;
                            exa.SeatPrice = m.ywx_price;
                            exa.SeatCount = m.yw_num;
                           infoModel.DetailList.Add(exa);

                        }

                        


                        //2
                        if (m.rz_num != "--" && m.rz_num != "*"&& !string.IsNullOrEmpty(m.rz_price) && m.rz_price.Trim() != "")
                        {
                            var exa = TrainTypeEnum.RZ;
                            exa.SeatPrice = m.rz_price;
                            exa.SeatCount = m.rz_num;
                           infoModel.DetailList.Add(exa);
                        }


                        //1
                        if (m.yz_num != "--" && m.yz_num != "*" && !string.IsNullOrEmpty(m.yz_price) && m.yz_price.Trim() != "")
                        {
                            var exa = TrainTypeEnum.YZ;
                            exa.SeatPrice = m.yz_price;
                            exa.SeatCount = m.yz_num;
                           infoModel.DetailList.Add(exa);
                        }



                        //暂无
                        if (m.qtxb_num != "--" && m.qtxb_num != "*" && !string.IsNullOrEmpty(m.qtxb_price) && m.qtxb_price.Trim() != "")
                        {
                            var exa = TrainTypeEnum.QTXB;
                            exa.SeatPrice = m.qtxb_price;
                            exa.SeatCount = m.qtxb_num;
                           infoModel.DetailList.Add(exa);
                        }

                        //无座
                        if (m.wz_num != "--" && m.wz_num != "*" && !string.IsNullOrEmpty(m.wz_price) && m.wz_price.Trim() != "")
                        {
                            var exa = TrainTypeEnum.WZ;
                            exa.SeatPrice = m.wz_price;
                            exa.SeatCount = m.wz_num;
                           infoModel.DetailList.Add(exa);
                        }
                         infoModel.DetailList.OrderBy(a => a.SeatIndex);
                        if (infoModel.DetailList.Count==0)
                        {
                            resultList.Remove(infoModel);
                        }

                    }
                    return resultList;

                }
                else
                {
                    throw new Exception();
                }
                #endregion
            }
            else
            {
                throw new Exception("查询未成功,原因是： " + model.msg);

            }
               

        }

        public void SaveLog(string logInfo)
        {
            LogHelper.WriteLog("火车票查询：" + logInfo );
        }

        
    }
}
