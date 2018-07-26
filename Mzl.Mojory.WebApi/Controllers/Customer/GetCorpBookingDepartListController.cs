using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using Mzl.IApplication.Customer;
using Mzl.Mojory.WebApi.Config;
using Mzl.UIModel.Base;
using Mzl.UIModel.Customer.Customer;

namespace Mzl.Mojory.WebApi.Controllers.Customer
{
    /// <summary>
    /// 获取预订员的预定部门范围
    /// </summary>
    public class GetCorpBookingDepartListController : ApiController
    {
        private readonly IGetCorpBookingDepartListApplication _getCorpBookingDepartListApplication;

        public GetCorpBookingDepartListController(IGetCorpBookingDepartListApplication getCorpBookingDepartListApplication)
        {
            _getCorpBookingDepartListApplication = getCorpBookingDepartListApplication;
        }

        /// <summary>
        /// 获取预订员的预定部门范围
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ResponseBaseViewModel<GetCorpBookingDepartListResponseViewModel>> GetCorpBookingDepartList(
        [FromBody] GetCorpBookingDepartListRequestViewModel request)
        {
            request.Cid = this.GetCid();
            GetCorpBookingDepartListResponseViewModel viewModel = new GetCorpBookingDepartListResponseViewModel();
            await new TaskFactory().StartNew(() =>
            {
                viewModel = _getCorpBookingDepartListApplication.GetCorpBookingDepartList(request);
            });

            ResponseBaseViewModel<GetCorpBookingDepartListResponseViewModel> v = new ResponseBaseViewModel
                <GetCorpBookingDepartListResponseViewModel>
            {
                Flag = new ResponseCodeViewModel() { Code = 0, MojoryToken = this.GetToken() },
                Data = viewModel
            };
            return v;
        }
    }
}
