using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Mzl.UIModel.Flight;
using Mzl.IApplication.Flight;
using Mzl.Mojory.WebApi.Config;
using Mzl.UIModel.Base;

namespace Mzl.Mojory.WebApi.Controllers.Flight.Corp
{
    /// <summary>
    /// 改签申请详情
    /// </summary>
    public class QueryFlightModApplyController : ApiController
    {
        private readonly IQueryFlightModApplyApplication _queryFlightModApplyApplication;

        public QueryFlightModApplyController(IQueryFlightModApplyApplication queryFlightModApplyApplication)
        {
            _queryFlightModApplyApplication = queryFlightModApplyApplication;
        }

        public ResponseBaseViewModel<QueryFlightModApplyResponseViewModel> QueryModApply(QueryFltRetModApplyRequestViewModel request)
        {
            request.Cid = this.GetCid();
            QueryFlightModApplyResponseViewModel responseViewModel= _queryFlightModApplyApplication.QueryFlightModApply(request);
            ResponseBaseViewModel<QueryFlightModApplyResponseViewModel> v =
             new ResponseBaseViewModel<QueryFlightModApplyResponseViewModel>
             {
                 Flag = new ResponseCodeViewModel() { Code = 0, MojoryToken = this.GetToken() },
                 Data = responseViewModel
             };

            return v;
        }


    }
}
