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
using Mzl.UIModel.Customer.CorpAduit;

namespace Mzl.Mojory.WebApi.Controllers.Customer
{
    /// <summary>
    /// 对审批单进行审批
    /// </summary>
    public class DoAduitOrderController : ApiController
    {
        private readonly IDoAduitOrderApplication _doAduitOrderApplication;

        public DoAduitOrderController(IDoAduitOrderApplication doAduitOrderApplication)
        {
            _doAduitOrderApplication = doAduitOrderApplication;
        }

        /// <summary>
        /// 对审批单进行审批
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ResponseBaseViewModel<DoAduitOrderResponseViewModel>> DoAduitOrder(
         [FromBody] DoAduitOrderRequestViewModel request)
        {
            request.Cid = this.GetCid();
            request.Oid= this.GetOid();
            request.OrderSource = this.GetOrderSource();
            DoAduitOrderResponseViewModel viewModel = new DoAduitOrderResponseViewModel();
            await new TaskFactory().StartNew(() =>
            {
                viewModel = _doAduitOrderApplication.DoAduitOrder(request);
            });

            ResponseBaseViewModel<DoAduitOrderResponseViewModel> v = new ResponseBaseViewModel
                <DoAduitOrderResponseViewModel>
            {
                Flag = new ResponseCodeViewModel() { Code = 0, MojoryToken = this.GetToken() },
                Data = viewModel
            };
            return v;
        }
    }
}
