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
    /// 删除差旅审批规则
    /// </summary>
    public class DeleteCorpAduitConfigController : ApiController
    {
        private readonly IDeleteCorpAduitConfigApplication _deleteCorpAduitConfigApplication;

        public DeleteCorpAduitConfigController(IDeleteCorpAduitConfigApplication deleteCorpAduitConfigApplication)
        {
            _deleteCorpAduitConfigApplication = deleteCorpAduitConfigApplication;
        }

        /// <summary>
        /// 删除差旅审批规则
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ResponseBaseViewModel<DeleteCorpAduitConfigResponseViewModel>> DeleteCorpAduitConfig(
          [FromBody] DeleteCorpAduitConfigRequestViewModel request)
        {
            request.Cid = this.GetCid();
            DeleteCorpAduitConfigResponseViewModel viewModel = new DeleteCorpAduitConfigResponseViewModel();
            await new TaskFactory().StartNew(() =>
            {
                viewModel = _deleteCorpAduitConfigApplication.DeleteCorpAduitConfig(request);
            });

            ResponseBaseViewModel<DeleteCorpAduitConfigResponseViewModel> v = new ResponseBaseViewModel
                <DeleteCorpAduitConfigResponseViewModel>
            {
                Flag = new ResponseCodeViewModel() { Code = 0, MojoryToken = this.GetToken() },
                Data = viewModel
            };
            return v;
        }
    }
}
