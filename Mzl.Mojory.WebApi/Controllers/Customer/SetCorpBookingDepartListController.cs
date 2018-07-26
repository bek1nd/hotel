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
    /// 设置差旅预定部门范围
    /// </summary>
    public class SetCorpBookingDepartListController : ApiController
    {
        private readonly ISetCorpBookingDepartListApplication _setCorpBookingDepartListApplication;

        public SetCorpBookingDepartListController(ISetCorpBookingDepartListApplication setCorpBookingDepartListApplication)
        {
            _setCorpBookingDepartListApplication = setCorpBookingDepartListApplication;
        }
        /// <summary>
        /// 设置差旅预定部门范围
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ResponseBaseViewModel<SetCorpBookingDepartListResponseViewModel>> SetCorpBookingDepartList(
       [FromBody] SetCorpBookingDepartListRequestViewModel request)
        {
            request.Cid = this.GetCid();
            SetCorpBookingDepartListResponseViewModel viewModel = new SetCorpBookingDepartListResponseViewModel();
            await new TaskFactory().StartNew(() =>
            {
                viewModel = _setCorpBookingDepartListApplication.SetDepartList(request);
            });

            ResponseBaseViewModel<SetCorpBookingDepartListResponseViewModel> v = new ResponseBaseViewModel
                <SetCorpBookingDepartListResponseViewModel>
            {
                Flag = new ResponseCodeViewModel() { Code = 0, MojoryToken = this.GetToken() },
                Data = viewModel
            };
            return v;
        }
    }
}
