using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Mzl.IApplication.Train.GrabTicket;
using Mzl.Mojory.WebApi.Config;
using Mzl.UIModel.Base;
using Mzl.UIModel.Train.GrabTicket;

namespace Mzl.Mojory.WebApi.Controllers.Train.GrabTicket
{
    /// <summary>
    /// 火车抢票列表
    /// </summary>
    public class TraGrabTicketListController : ApiController
    {
        private readonly IGetTraGrabTicketListApplication _getTraGrabTicketListApplication;

        public TraGrabTicketListController(IGetTraGrabTicketListApplication getTraGrabTicketListApplication)
        {
            _getTraGrabTicketListApplication = getTraGrabTicketListApplication;
        }
        /// <summary>
        /// 获取火车抢票信息
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost]
        public ResponseBaseViewModel<TraGrabTicketListResponseViewModel> GetTraGrabTicketList(
            [FromBody] TraGrabTicketListRequestViewModel request)
        {
            TraGrabTicketListResponseViewModel responseViewModel =
                _getTraGrabTicketListApplication.GetTraGrabTicketList(request);
            ResponseBaseViewModel<TraGrabTicketListResponseViewModel> v = new ResponseBaseViewModel
                <TraGrabTicketListResponseViewModel>
            {
                Flag = new ResponseCodeViewModel() {Code = 0, MojoryToken = this.GetToken()},
                Data = responseViewModel
            };
            return v;
        }

    }
}
