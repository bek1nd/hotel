using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Web;
using System.Web.Http;
using Mzl.Common.LogHelper;
using Mzl.Common.PostHelper;
using Mzl.IApplication.Train.GrabTicket;

namespace Mzl.Mojory.WebApi.Controllers.Train.GrabTicket
{
    /// <summary>
    /// 火车票抢票异步通知
    /// </summary>
    [AllowAnonymous]
    public class TraGrabTicketCallBackController : ApiController
    {
        private readonly IGetGrabTicketNoticeApplication _getGrabTicketNoticeApplication;

        public TraGrabTicketCallBackController(IGetGrabTicketNoticeApplication getGrabTicketNoticeApplication)
        {
            _getGrabTicketNoticeApplication = getGrabTicketNoticeApplication;
        }

        /// <summary>
        /// 接受火车票抢票异步通知
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public HttpResponseMessage GrabTicketCallBack()
        {
            string responseData = PostHelper.ReceivePostInfo();
            LogHelper.WriteLog("抢票异步通知：" + responseData, "TraGrabTicketCallBack");
            responseData = HttpUtility.UrlDecode(responseData.Trim(), Encoding.UTF8);
            LogHelper.WriteLog("抢票异步通知(html解析)：" + responseData, "TraGrabTicketCallBack");

            _getGrabTicketNoticeApplication.GetGrabTicketNotice(responseData);


            HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.OK);
            response.Content = new StringContent("SUCCESS", Encoding.UTF8);
            return response;
        }
    }
}
