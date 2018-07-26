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
 public   class OrderCancelServerBLL : IOrderCancelServerBLL<TraOrderCancelResponseModel>
    {
        private readonly string postUrl = "http://trainorder.ws.hangtian123.com/cn_interface/tcTrain";

       



       
        public string Data { get; set; }
        public string DoGetRequest()
        {
            return string.Empty;
        }

        public string DoPostRequest()
        {
            string date = DateTime.Now.ToString();
            LogHelper.WriteLog("取消订单接口:" + date + "||||||" + Data, "Request");
            string post = PostHelper.PostUrl(postUrl, Data, Encoding.UTF8);
            LogHelper.WriteLog("取消订单接口返回:" + date + "||||||" + post, "Request");
            return post;
        }

        public TraOrderCancelResponseModel DoOrderCancel()
        {
            string getStr = DoPostRequest();

            TraOrderCancelResponseModel trainResponseModel = JsonHelper.DeserializeJsonToObject<TraOrderCancelResponseModel>(getStr);

            return trainResponseModel;







        }



        public void SaveLog(string logInfo)
        {
            LogHelper.WriteLog("订单取消：" + logInfo);
        }

    }
}
