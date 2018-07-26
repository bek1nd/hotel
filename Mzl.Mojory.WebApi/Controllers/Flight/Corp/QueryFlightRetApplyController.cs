using Mzl.IApplication.Flight;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Mzl.Mojory.WebApi.Config;
using Mzl.UIModel.Base;
using Mzl.UIModel.Flight;

namespace Mzl.Mojory.WebApi.Controllers.Flight.Corp
{
    /// <summary>
    /// 退票申请详情
    /// </summary>
    public class QueryFlightRetApplyController : ApiController
    {
        private readonly IQueryFlightRetApplyApplication _queryFlightRetApplyApplication;

        public QueryFlightRetApplyController(IQueryFlightRetApplyApplication queryFlightRetApplyApplication)
        {
            _queryFlightRetApplyApplication = queryFlightRetApplyApplication;
        }

        public ResponseBaseViewModel<QueryFlightRetApplyResponseViewModel> QueryRetApply(QueryFltRetModApplyRequestViewModel request)
        {
            request.Cid = this.GetCid();
            QueryFlightRetApplyResponseViewModel responseViewModel =
                _queryFlightRetApplyApplication.QueryFlightRetApply(request);
            ResponseBaseViewModel<QueryFlightRetApplyResponseViewModel> v =
                new ResponseBaseViewModel<QueryFlightRetApplyResponseViewModel>
                {
                    Flag = new ResponseCodeViewModel() {Code = 0, MojoryToken = this.GetToken()},
                    Data = responseViewModel
                };
             

            return v;
        }

    }
}
