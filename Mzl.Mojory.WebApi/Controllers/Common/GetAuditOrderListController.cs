using Mzl.IApplication.Common;
using System.Web.Http;
using Mzl.UIModel.Base;
using Mzl.UIModel.Common.AuditOrder;
using Mzl.Mojory.WebApi.Config;

namespace Mzl.Mojory.WebApi.Controllers.Common
{
    /// <summary>
    /// 获取审批信息
    /// </summary>
    public class GetAuditOrderListController : ApiController
    {
        private readonly IGetAuditOrderListApplication _getAuditOrderListApplication;

        public GetAuditOrderListController(IGetAuditOrderListApplication getAuditOrderListApplication)
        {
            _getAuditOrderListApplication = getAuditOrderListApplication;
        }
        /// <summary>
        /// 获取审批列表信息
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost]
        public ResponseBaseViewModel<GetAuditOrderListResponseViewModel> GetList([FromBody] GetAuditOrderListRequestViewModel request)
        {
            if (request == null)
                request = new GetAuditOrderListRequestViewModel();
            request.Cid = this.GetCid();
            GetAuditOrderListResponseViewModel responseViewModel = _getAuditOrderListApplication.GetAuditOrderList(request);
            ResponseBaseViewModel<GetAuditOrderListResponseViewModel> v = new ResponseBaseViewModel<GetAuditOrderListResponseViewModel>
            {
                Flag = new ResponseCodeViewModel() { Code = 0, MojoryToken = this.GetToken() },
                Data = responseViewModel
            };
            return v;

        }

    }
}
