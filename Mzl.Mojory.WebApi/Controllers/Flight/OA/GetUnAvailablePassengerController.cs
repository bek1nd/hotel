using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Mzl.IApplication.Flight;
using Mzl.Mojory.WebApi.Config;
using Mzl.UIModel.Base;
using Mzl.UIModel.Flight;

namespace Mzl.Mojory.WebApi.Controllers.Flight.OA
{
    public class GetUnAvailablePassengerController : ApiController
    {
        private readonly IGetUnAvailablePassengerApplication _getUnAvailablePassengerApplication;

        public GetUnAvailablePassengerController(IGetUnAvailablePassengerApplication getUnAvailablePassengerApplication)
        {
            _getUnAvailablePassengerApplication = getUnAvailablePassengerApplication;
        }
        /// <summary>
        /// 获取信息不可用的订单信息
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost]
        public ResponseBaseViewModel<GetUnAvailablePassengerListResponseViewModel> GetUnAvailablePassengerList(
            [FromBody] GetUnAvailablePassengerRequestViewModel request)
        {
            request.Oid = this.GetOid();
            GetUnAvailablePassengerListResponseViewModel responseViewModel =
                _getUnAvailablePassengerApplication.GetUnAvailablePassengerList(request);
            ResponseBaseViewModel<GetUnAvailablePassengerListResponseViewModel> v = new ResponseBaseViewModel
                <GetUnAvailablePassengerListResponseViewModel>
            {
                Flag = new ResponseCodeViewModel() {Code = 0, MojoryToken = this.GetToken()},
                Data = responseViewModel
            };
            return v;
        }
    }
}
