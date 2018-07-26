using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using Mzl.IApplication.Common;
using Mzl.Mojory.WebApi.Config;
using Mzl.UIModel.Base;
using Mzl.UIModel.Common.CheckAccount;
using Mzl.UIModel.Flight;

namespace Mzl.Mojory.WebApi.Controllers.Common
{
    /// <summary>
    /// 检查差旅网站帐号权限
    /// </summary>
    public class CheckCorpAccountPowerController : ApiController
    {
        private readonly ICheckCorpAccountPowerApplication _checkCorpAccountPowerApplication;

        public CheckCorpAccountPowerController(ICheckCorpAccountPowerApplication checkCorpAccountPowerApplication)
        {
            _checkCorpAccountPowerApplication = checkCorpAccountPowerApplication;
        }

        /// <summary>
        /// 检查差旅网站帐号权限
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ResponseBaseViewModel<CheckCorpAccountPowerResponseViewModel>> CheckCorpAccountPower(
          [FromBody] CheckCorpAccountPowerRequestViewModel request)
        {
            request.Cid = this.GetCid();
            CheckCorpAccountPowerResponseViewModel viewModel = new CheckCorpAccountPowerResponseViewModel();
            await new TaskFactory().StartNew(() =>
            {
                viewModel = _checkCorpAccountPowerApplication.CheckCorpAccountPower(request);
            });

            ResponseBaseViewModel<CheckCorpAccountPowerResponseViewModel> v = new ResponseBaseViewModel
                <CheckCorpAccountPowerResponseViewModel>
            {
                Flag = new ResponseCodeViewModel() { Code = 0, MojoryToken = this.GetToken() },
                Data = viewModel
            };
            return v;
        }
    }
}
