using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mzl.Common.LogHelper;
using Mzl.Common.PostHelper;
using Mzl.DomainModel.Train.GrabTicket.KongTieInterface;
using Mzl.IBLL.Train.GrabTicket.KongTieInterface;
using Newtonsoft.Json;

namespace Mzl.BLL.Train.GrabTicket.KongTieInterface
{
    internal class RequestGrabTicketCancelBll : IRequestGrabTicketCancelBll
    {
        private static readonly string Url = "http://bespeak.hangtian123.net/trainorder_bespeak/CancelTicket";
        public GrabTicketCancelResponseModel CancelGrabTicket(GrabTicketCancelRequestModel request)
        {
            try
            {
                string postData = JsonConvert.SerializeObject(request);
                postData = "jsonStr=" + postData;
                LogHelper.WriteLog("请求取消抢票接口：" + postData, "TraGrabTicketCallBack");
                string responseData = PostHelper.PostUrl(Url, postData, Encoding.UTF8);
                LogHelper.WriteLog("取消抢票接口同步响应：" + responseData, "TraGrabTicketCallBack");
                if (string.IsNullOrEmpty(responseData))
                    return new GrabTicketCancelResponseModel()
                    {
                        msg = "请求接口失败",
                        isSuccess = false,
                        code = "-1"
                    };

                GrabTicketCancelResponseModel responseModel = JsonConvert.DeserializeObject<GrabTicketCancelResponseModel>(responseData);
                return responseModel;
            }
            catch (Exception ex)
            {
                return new GrabTicketCancelResponseModel()
                {
                    msg = ex.Message,
                    isSuccess = false,
                    code = "-1"
                };
            }
        }
    }
}
