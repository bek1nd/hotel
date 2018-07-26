using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Mzl.IApplication.Common;
using Mzl.Mojory.WebApi.Config;
using Mzl.UIModel.Base;
using Mzl.UIModel.Common.AuditOrder;
using Mzl.UIModel.Common.TravelManage;

namespace Mzl.Mojory.WebApi.Controllers.Common
{
    /// <summary>
    /// 获取行程信息
    /// </summary>
    public class GetTravelListController : ApiController
    {
        private readonly IGetTravelListApplication _getTravelListApplication;

        public GetTravelListController(IGetTravelListApplication getTravelListApplication)
        {
            _getTravelListApplication = getTravelListApplication;
        }

        [HttpPost]
        public ResponseBaseViewModel<TravelResponseViewModel> GetTravelList([FromBody] TravelRequestViewModel request)
        {
            if (request == null)
                request = new TravelRequestViewModel();
            request.Cid = this.GetCid();
            TravelResponseViewModel responseViewModel = _getTravelListApplication.GetTravel(request);
            ResponseBaseViewModel<TravelResponseViewModel> v = new ResponseBaseViewModel<TravelResponseViewModel>
            {
                Flag = new ResponseCodeViewModel() {Code = 0, MojoryToken = this.GetToken()},
                Data = responseViewModel
            };
            return v;

        }
    }
}
