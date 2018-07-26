using Mzl.Common.JsonHelper;
using Mzl.Common.LogHelper;
using Mzl.Common.PostHelper;
using Mzl.DomainModel.Train.Server;
using Mzl.IBLL.Train.Server.BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mzl.BLL.Train.Server.BLL
{
   public class SearchOrderInfoServerBLL : ISearchOrderInfoServerBLL<TraSearchOrderInfoResponseModel>
    {
        private readonly string postUrl = "http://trainorder.ws.hangtian123.com/cn_interface/tcTrain";

        private readonly string callBackUrl = "http://180.169.11.178:8082/MojoryApi/TrainCallBack/HoldSeatCallBack";



        public string CallBackUrl { get { return callBackUrl; } }

        public string Data { get; set; }
        public string DoGetRequest()
        {
            return string.Empty;
        }

        public string DoPostRequest()
        {
            string date = DateTime.Now.ToString();
            LogHelper.WriteLog("对方订单查询接口:" + date + "||||||" + Data, "Request");
            string post = PostHelper.PostUrl(postUrl, Data, Encoding.UTF8);
            LogHelper.WriteLog("对方订单查询返回:" + date + "||||||" + post, "Request");
            return post;
        }

        public TraSearchOrderInfoResponseModel DoOrderInfo()
        {
            string getStr = DoPostRequest();

            TraSearchOrderInfoResponseModel trainResponseModel = JsonHelper.DeserializeJsonToObject<TraSearchOrderInfoResponseModel>(getStr);

            return trainResponseModel;

        }



        public void SaveLog(string logInfo)
        {
            LogHelper.WriteLog("订单提交：" + logInfo);
        }

       
    }
}
