using Mzl.UIModel.Base;
using Mzl.UIModel.Flight;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Mzl.IApplication.Flight;
using Mzl.Mojory.WebApi.Config;

namespace Mzl.Mojory.WebApi.Controllers.Flight.Corp
{
    /// <summary>
    /// 机票订单详情
    /// </summary>
    public class QueryFlightDomesticOrderController : ApiController
    {

        private readonly IQueryFlightOrderApplication _queryFlightOrderApplication;

        public QueryFlightDomesticOrderController(IQueryFlightOrderApplication queryFlightOrderApplication)
        {
            _queryFlightOrderApplication = queryFlightOrderApplication;
        }

        public ResponseBaseViewModel<QueryFltOrderResponseViewModel> QueryOrder(QueryFltOrderRequestViewModel request)
        {
            request.Cid = this.GetCid();
            QueryFltOrderResponseViewModel responseViewModel = _queryFlightOrderApplication.QueryOrder(request);
            ResponseBaseViewModel<QueryFltOrderResponseViewModel> v =
             new ResponseBaseViewModel<QueryFltOrderResponseViewModel>
             {
                 Flag = new ResponseCodeViewModel() { Code = 0, MojoryToken = this.GetToken() },
                 Data = responseViewModel
             };

            return v;
        }
    }
}
