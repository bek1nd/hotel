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
    internal class RequestKongTieCancelOrderBll: IRequestCancelOrderBll
    {
        private static string _postUrl = "http://trainorder.ws.hangtian123.com/cn_interface/tcTrain";
        public TraOrderCancelResponseModel RequestCancelOrder(TraOrderCancelModel model)
        {

            RequestInterfaceHelper<TraOrderSubmitModel>.SupplementInPutModel(model, "train_cancel");
            string jsonstr = "jsonStr=" + JsonHelper.SerializeObject(model);

            DateTime date = DateTime.Now;
            LogHelper.WriteLog("取消订单接口:" + date + "||||||" + jsonstr, "Request");
            string post = PostHelper.PostUrl(_postUrl, jsonstr, Encoding.UTF8);
            LogHelper.WriteLog("取消订单接口返回:" + date + "||||||" + post, "Request");

            TraOrderCancelResponseModel trainResponseModel = JsonConvert.DeserializeObject<TraOrderCancelResponseModel>(post);

            return trainResponseModel;
        }
    }
}
