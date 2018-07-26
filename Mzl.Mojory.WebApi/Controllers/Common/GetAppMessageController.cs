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
using Mzl.UIModel.Customer.AppMessage;
using Mzl.UIModel.Customer.CorpAduit;

namespace Mzl.Mojory.WebApi.Controllers.Common
{
    /// <summary>
    /// 获取App消息信息
    /// </summary>
    public class GetAppMessageController : ApiController
    {
        private readonly IGetAppMessageApplication _getAppMessageApplication;

        public GetAppMessageController(IGetAppMessageApplication getAppMessageApplication)
        {
            _getAppMessageApplication = getAppMessageApplication;
        }

        /// <summary>
        /// 获取未读的app消息数量
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ResponseBaseViewModel<GetUnReadMessageCountResponseViewModel>> GetUnReadMessageCount(
         [FromBody] GetUnReadMessageCountRequestViewModel request)
        {
            if(request==null)
                request=new GetUnReadMessageCountRequestViewModel();

            request.Cid = this.GetCid();

            GetUnReadMessageCountResponseViewModel viewModel = new GetUnReadMessageCountResponseViewModel();
            await new TaskFactory().StartNew(() =>
            {
                viewModel = _getAppMessageApplication.GetUnReadMessageCount(request);
            });

            ResponseBaseViewModel<GetUnReadMessageCountResponseViewModel> v = new ResponseBaseViewModel
                <GetUnReadMessageCountResponseViewModel>
            {
                Flag = new ResponseCodeViewModel() { Code = 0, MojoryToken = this.GetToken() },
                Data = viewModel
            };
            return v;
        }
        /// <summary>
        /// 获取未读的app消息
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ResponseBaseViewModel<GetAppMessageResponseViewModel>> GetUnReadMessage(
         [FromBody] GetAppMessageRequestViewModel request)
        {
            if (request == null)
                request = new GetAppMessageRequestViewModel();

            request.Cid = this.GetCid();

            GetAppMessageResponseViewModel viewModel = new GetAppMessageResponseViewModel();
            await new TaskFactory().StartNew(() =>
            {
                viewModel = _getAppMessageApplication.GetUnReadMessage(request);
            });

            ResponseBaseViewModel<GetAppMessageResponseViewModel> v = new ResponseBaseViewModel
                <GetAppMessageResponseViewModel>
            {
                Flag = new ResponseCodeViewModel() {Code = 0, MojoryToken = this.GetToken()},
                Data = viewModel
            };
            return v;
        }

        /// <summary>
        /// 将消息设置已读
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ResponseBaseViewModel<SetReadMessageResponseViewModel>> SetReadMessage(
       [FromBody] SetReadMessageRequestViewModel request)
        {
            if (request == null)
                request = new SetReadMessageRequestViewModel();

            request.Cid = this.GetCid();

            SetReadMessageResponseViewModel viewModel = new SetReadMessageResponseViewModel();
            await new TaskFactory().StartNew(() =>
            {
                bool flag = _getAppMessageApplication.SetRead(request.SendId);
                viewModel = new SetReadMessageResponseViewModel() {IsSuccessed = flag};
            });

            ResponseBaseViewModel<SetReadMessageResponseViewModel> v = new ResponseBaseViewModel
                <SetReadMessageResponseViewModel>
            {
                Flag = new ResponseCodeViewModel() { Code = 0, MojoryToken = this.GetToken() },
                Data = viewModel
            };
            return v;
        }
    }
}
