using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mzl.Common.JsonHelper;
using Mzl.Common.LogHelper;
using Mzl.Common.PostHelper;
using Mzl.Common.XMLHelper;
using Mzl.DomainModel.Train.Server;
using Mzl.IBLL.Train.RequestInterface;
using Newtonsoft.Json;

namespace Mzl.BLL.Train.RequestInterface
{
    internal class RequestKongTieHoldSeatBll: IRequestHoldSeatBll
    {
        private static string _str = System.AppDomain.CurrentDomain.SetupInformation.ApplicationBase + @"\bin\App_Data\TrainConfig.xml";
        private static string _callBackUrl = XMLHelper.ReadXmlNode(_str, "TrainCallBack").SelectSingleNode("HoldSeatCallBack").InnerText;
        private static string _postUrl = "http://trainorder.ws.hangtian123.com/cn_interface/tcTrain";
        public TraOrderSubmitResponseModel RequestHoldSeatInterface(TraOrderSubmitModel model)
        {
            model.callbackurl = _callBackUrl;
            RequestInterfaceHelper<TraOrderSubmitModel>.SupplementInPutModel(model, "train_order");
            string jsonstr = "jsonStr=" + JsonHelper.SerializeObject(model);

            DateTime date = DateTime.Now;
            LogHelper.WriteLog("请求占位:" + date + "||||||" + jsonstr, "Request");
            string post = PostHelper.PostUrl(_postUrl, jsonstr, Encoding.UTF8);
            LogHelper.WriteLog("请求占位返回:" + date + "||||||" + post, "Request");

            TraOrderSubmitResponseModel trainResponseModel = JsonConvert.DeserializeObject<TraOrderSubmitResponseModel>(post);

            return trainResponseModel;
        }
    }
}
