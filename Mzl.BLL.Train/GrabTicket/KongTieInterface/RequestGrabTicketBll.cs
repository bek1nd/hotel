using System;
using System.Text;
using Mzl.Common.ConfigHelper;
using Mzl.Common.LogHelper;
using Mzl.Common.PostHelper;
using Mzl.DomainModel.Train.GrabTicket.KongTieInterface;
using Mzl.IBLL.Train.GrabTicket.KongTieInterface;
using Newtonsoft.Json;

namespace Mzl.BLL.Train.GrabTicket.KongTieInterface
{
    internal class RequestGrabTicketBll : IRequestGrabTicketBll
    {
        private static readonly string Url = "http://bespeak.kt.hangtian123.net/cn_interface/tcTrain";

        /// <summary>
        /// 访问抢票接口
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public GrabTicketResponseModel RunGrabTicketInterface(GrabTicketRequestModel request)
        {
            try
            {
                string postData = JsonConvert.SerializeObject(request);
                postData = "jsonStr=" + postData;
                LogHelper.WriteLog("请求抢票接口：" + postData, "TraGrabTicketCallBack");
                string isServer = AppSettingsHelper.GetAppSettings(AppSettingsEnum.IsAllowTrainGrabTicket);
                if (isServer != "T")
                    throw new Exception("测试");
                string responseData = PostHelper.PostUrl(Url, postData, Encoding.UTF8);
                LogHelper.WriteLog("抢票接口同步响应：" + responseData, "TraGrabTicketCallBack");
                if (string.IsNullOrEmpty(responseData))
                    return new GrabTicketResponseModel()
                    {
                        msg = "请求接口失败",
                        success = false,
                        code = "-1"
                    };

                GrabTicketResponseModel responseModel =
                    JsonConvert.DeserializeObject<GrabTicketResponseModel>(responseData);
                return responseModel;

            }
            catch (Exception ex) //直接捕获一下异常，不返回到前端
            {
                return new GrabTicketResponseModel()
                {
                    msg = ex.Message,
                    success = false,
                    code = "-1"
                };
            }

        }
    }
}
