using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using Mzl.IApplication.Flight;
using Mzl.Mojory.WebApi.Config;
using Mzl.UIModel.Base;
using Mzl.UIModel.Flight;
using Mzl.UIModel.Flight.CopyOrder;

namespace Mzl.Mojory.WebApi.Controllers.Flight.Corp
{
    /// <summary>
    /// 复制国内机票订单
    /// </summary>
    public class CopyFltDomesticOrderController : ApiController
    {
        private readonly ICopyFltDomesticOrderApplication _corpCopyFltDomesticOrderApplication;

        public CopyFltDomesticOrderController(ICopyFltDomesticOrderApplication corpCopyFltDomesticOrderApplication)
        {
            _corpCopyFltDomesticOrderApplication = corpCopyFltDomesticOrderApplication;
        }

        /// <summary>
        /// 复制国内机票订单
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ResponseBaseViewModel<CopyFltDomesticOrderResponseViewModel>> CopyCorpFltDomesticOrder(
            [FromBody] CopyFltDomesticOrderRequestViewModel request)
        {
            request.Cid = this.GetCid();
            request.OrderSource = this.GetOrderSource();
            request.CreateOid = this.GetOid();
            CopyFltDomesticOrderResponseViewModel viewModel = new CopyFltDomesticOrderResponseViewModel();
            await new TaskFactory().StartNew(() =>
            {
                viewModel = _corpCopyFltDomesticOrderApplication.CopyFltDomesticOrder(request);
            });

            ResponseBaseViewModel<CopyFltDomesticOrderResponseViewModel> v = new ResponseBaseViewModel
                <CopyFltDomesticOrderResponseViewModel>
            {
                Flag = new ResponseCodeViewModel() { Code = 0, MojoryToken = this.GetToken() },
                Data = viewModel
            };
            return v;
        }
    }
}
