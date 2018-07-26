using Mzl.IApplication.Train.GrabTicket;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Mzl.Mojory.WebApi.Config;
using Mzl.UIModel.Base;
using Mzl.UIModel.Train.GrabTicket;

namespace Mzl.Mojory.WebApi.Controllers.Train.GrabTicket
{
    /// <summary>
    /// 火车抢票提交
    /// </summary>
    public class TraAddGrabTicketController : ApiController
    {
        private readonly IAddGrabTicketApplication _addGrabTicketApplication;

        public TraAddGrabTicketController(IAddGrabTicketApplication addGrabTicketApplication)
        {
            _addGrabTicketApplication = addGrabTicketApplication;
        }

        /// <summary>
        /// 添加抢票信息
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost]
        public ResponseBaseViewModel<AddGrabTicketResponseViewModel> AddGrabTicket([FromBody] AddGrabTicketRequestViewModel request)
        {
            request.Cid = this.GetCid();
            request.Oid = this.GetOid();
            request.OrderSource = this.GetOrderSource();
            AddGrabTicketResponseViewModel responseViewModel= _addGrabTicketApplication.AddGrabTicket(request);
            ResponseBaseViewModel<AddGrabTicketResponseViewModel> v = new ResponseBaseViewModel
               <AddGrabTicketResponseViewModel>
            {
                Flag = new ResponseCodeViewModel() { Code = 0, MojoryToken = this.GetToken() },
                Data = responseViewModel
            };
            return v;
        }

    }
}
