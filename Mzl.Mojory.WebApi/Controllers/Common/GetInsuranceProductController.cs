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
using Mzl.UIModel.Common.Insurance;

namespace Mzl.Mojory.WebApi.Controllers.Common
{
    public class GetInsuranceProductController : ApiController
    {
        private readonly IGetInsuranceProductApplication _getInsuranceProductApplication;

        public GetInsuranceProductController(IGetInsuranceProductApplication getInsuranceProductApplication)
        {
            _getInsuranceProductApplication = getInsuranceProductApplication;
        }
        /// <summary>
        /// 获取线上保险信息
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost]
        public ResponseBaseViewModel<InsuranceProductResponseViewModel> GetOnlineInsuranceProduct([FromBody] InsuranceProductRequestViewModel request)
        {
            if (request == null)
                request = new InsuranceProductRequestViewModel();
            request.Cid = this.GetCid();
            InsuranceProductResponseViewModel responseViewModel = _getInsuranceProductApplication.GetOnlineInsuranceProductList();
            ResponseBaseViewModel<InsuranceProductResponseViewModel> v = new ResponseBaseViewModel<InsuranceProductResponseViewModel>
            {
                Flag = new ResponseCodeViewModel() { Code = 0, MojoryToken = this.GetToken() },
                Data = responseViewModel
            };
            return v;

        }

    }
}
