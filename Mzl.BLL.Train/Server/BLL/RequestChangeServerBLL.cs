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
public    class RequestChangeServerBLL : IRequestChangeServerBLL<TraRequestChangeResponseModel>
    {
        private readonly string postUrl = "http://trainorder.ws.hangtian123.com/cn_interface/tcTrain";

       
        static string STR = System.AppDomain.CurrentDomain.SetupInformation.ApplicationBase + @"\App_Data\TrainConfig.xml";

        private readonly string callBackUrl = XMLHelper.ReadXmlNode(STR, "TrainCallBack").SelectSingleNode("ModHoldSeatCallBack").InnerText;

        public string CallBackUrl { get { return callBackUrl; } }

        public string Data { get; set; }
        public string DoGetRequest()
        {
            return string.Empty;
        }

        public string DoPostRequest()
        {
            string date = DateTime.Now.ToString();
            LogHelper.WriteLog("改签接口:" + date + "||||||" + Data, "Request");
            string post = PostHelper.PostUrl(postUrl, Data, Encoding.UTF8);
            LogHelper.WriteLog("改签接口返回:" + date + "||||||" + post, "Request");
            return post;
        }

        public TraRequestChangeResponseModel DoRequestChange()
        {
            string getStr = DoPostRequest();

            TraRequestChangeResponseModel trainResponseModel = JsonHelper.DeserializeJsonToObject<TraRequestChangeResponseModel>(getStr);

            return trainResponseModel;







        }



        public void SaveLog(string logInfo)
        {
            LogHelper.WriteLog("订单确认：" + logInfo);
        }

    }
}
