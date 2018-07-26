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
  public  class TrainInfoServerBLL : ITrainInfoServerBLL<List<TraTrainInfoResponseDateDetailModel>>
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
            LogHelper.WriteLog("查询经停接口:" + date + "||||||" + Data, "Request");
            string post = PostHelper.PostUrl(postUrl, Data, Encoding.UTF8);
            LogHelper.WriteLog("查询经停接口返回:" + date + "||||||" + post, "Request");
            return post;
        }

        public List<TraTrainInfoResponseDateDetailModel> DoTrainInfo()
        {
            string getStr = DoPostRequest();
            TraTrainInfoResponseModel trainResponseModel = JsonHelper.DeserializeJsonToObject<TraTrainInfoResponseModel>(getStr);
            if (trainResponseModel.code == 200)
            {

                List<TraTrainInfoResponseDateDetailModel> detail = new List<TraTrainInfoResponseDateDetailModel>();
                detail = trainResponseModel.data.FirstOrDefault().data;
                return detail;
            }

            return null;
        }



        public void SaveLog(string logInfo)
        {
            LogHelper.WriteLog("火车查询：" + logInfo);
        }

    }
}
