using Microsoft.Practices.Unity;
using Mzl.Common.Ioc;
using Mzl.IApplication.Flight;
using Mzl.Mojory.WebApi.Config;
using Mzl.UIModel.Base;
using Mzl.UIModel.Flight;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Mzl.Mojory.WebApi.Controllers.Flight.Corp
{
    /// <summary>
    /// 展示国内机票下单页面信息
    /// </summary>
    public class ComfireFlightOrderViewController : ApiController
    {
        private readonly IComfireOrderApplication _comfireOrderApplication;

        public ComfireFlightOrderViewController(IComfireOrderApplication comfireOrderApplication)
        {
            _comfireOrderApplication = comfireOrderApplication;
        }
        /// <summary>
        /// 展示下单页面信息
        /// </summary>
        /// <returns></returns>
        public ResponseBaseViewModel<ComfireFlightOrderResponseViewModel> ComfireOrderView([FromBody] ComfireFlightOrderRequestViewModel request)
        {
            if (request == null)
                request = new ComfireFlightOrderRequestViewModel();
            request.Cid = this.GetCid();
            request.Oid = this.GetOid();
            request.OrderSource = this.GetOrderSource();
            ComfireFlightOrderResponseViewModel responseViewModel =
                _comfireOrderApplication.ComfireOrderViewApplicationService(request);

            ResponseBaseViewModel<ComfireFlightOrderResponseViewModel> v =
                new ResponseBaseViewModel<ComfireFlightOrderResponseViewModel>
                {
                    Flag = new ResponseCodeViewModel() { Code = 0, MojoryToken = this.GetToken() },
                    Data = responseViewModel
                };

            return v;
        }
    }
}
