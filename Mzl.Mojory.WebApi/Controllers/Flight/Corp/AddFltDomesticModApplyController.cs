using System.Web.Http;
using Mzl.IApplication.Flight;
using Mzl.Mojory.WebApi.Config;
using Mzl.UIModel.Base;
using Mzl.UIModel.Flight;

namespace Mzl.Mojory.WebApi.Controllers.Flight.Corp
{
    /// <summary>
    /// 添加国内机票改签申请
    /// </summary>
    public class AddFltDomesticModApplyController : ApiController
    {
        private readonly IAddFltDomesticModApplyApplication _addFltDomesticModApplyViewApplication;

        public AddFltDomesticModApplyController(IAddFltDomesticModApplyApplication addFltDomesticModApplyViewApplication)
        {
            _addFltDomesticModApplyViewApplication = addFltDomesticModApplyViewApplication;
        }

        public ResponseBaseViewModel<AddModApplyResponseViewModel> AddModApply([FromBody]AddModApplyRequestViewModel request)
        {
            request.Cid = this.GetCid();
            request.OrderSource = this.GetOrderSource();
            AddModApplyResponseViewModel responseViewModel = _addFltDomesticModApplyViewApplication.AddModApply(request);

            ResponseBaseViewModel<AddModApplyResponseViewModel> v = new ResponseBaseViewModel<AddModApplyResponseViewModel>
            {
                Flag = new ResponseCodeViewModel() { Code = 0, MojoryToken = this.GetToken() },
                Data = responseViewModel
            };
            return v;
        }
    }
}
