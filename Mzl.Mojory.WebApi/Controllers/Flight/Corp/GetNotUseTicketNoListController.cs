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

namespace Mzl.Mojory.WebApi.Controllers.Flight.Corp
{
    /// <summary>
    /// 获取未使用机票信息
    /// </summary>
    public class GetNotUseTicketNoListController : ApiController
    {
        private readonly IGetNotUseTicketNoListApplication _getNotUseTicketNoListApplication;

        public GetNotUseTicketNoListController(IGetNotUseTicketNoListApplication getNotUseTicketNoListApplication)
        {
            _getNotUseTicketNoListApplication = getNotUseTicketNoListApplication;
        }

        /// <summary>
        /// 获取国内未使用机票信息
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost]
        public ResponseBaseViewModel<GetNotUseTicketNoViewModel> GetNotUseNationTicketNoList(
            GetNotUseTicketNoQueryViewModel request)
        {
            request.Cid = this.GetCid();
            GetNotUseTicketNoViewModel responseViewModel =
                _getNotUseTicketNoListApplication.GetNotUseNationTicketNoList(request);
            ResponseBaseViewModel<GetNotUseTicketNoViewModel> v =
                new ResponseBaseViewModel<GetNotUseTicketNoViewModel>
                {
                    Flag = new ResponseCodeViewModel() {Code = 0, MojoryToken = this.GetToken()},
                    Data = responseViewModel
                };

            return v;
        }
    }
}
