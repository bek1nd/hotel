using Mzl.Common.JsonHelper;
using Mzl.Common.LogHelper;
using Mzl.Common.PostHelper;
using Mzl.Common.XMLHelper;
using Mzl.DomainModel.Train.Server;
using Mzl.IBLL.Train.Server.BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mzl.BLL.Train.Server.BLL
{
  public  class OrderConfirmServerBLL : IOrderConfirmServerBLL<TraOrderConfirmResponseModel>
    {
        private readonly string postUrl = "http://trainorder.ws.hangtian123.com/cn_interface/tcTrain";



        static string STR = System.AppDomain.CurrentDomain.SetupInformation.ApplicationBase + @"\App_Data\TrainConfig.xml";

        private readonly string callBackUrl = XMLHelper.ReadXmlNode(STR, "TrainCallBack").SelectSingleNode("PrintTicketCallBack").InnerText;


      



        public string CallBackUrl { get { return callBackUrl; } }

        public string Data { get; set; }
        public string DoGetRequest()
        {
            return string.Empty;
        }

        public string DoPostRequest()
        {
            string date = DateTime.Now.ToString();
            LogHelper.WriteLog("确认订单接口:" + date + "||||||" + Data, "Request");
            string post = PostHelper.PostUrl(postUrl, Data, Encoding.UTF8);
            LogHelper.WriteLog("确认订单接口返回:" + date + "||||||" + post, "Request");
            return post;
        }

        public TraOrderConfirmResponseModel DoOrderConfirm()
        {
            string getStr = DoPostRequest();

            TraOrderConfirmResponseModel trainResponseModel = JsonHelper.DeserializeJsonToObject<TraOrderConfirmResponseModel>(getStr);

            return trainResponseModel;







        }



        public void SaveLog(string logInfo)
        {
            LogHelper.WriteLog("订单确认：" + logInfo);
        }

    }
}
