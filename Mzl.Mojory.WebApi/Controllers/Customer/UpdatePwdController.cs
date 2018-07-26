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
using Mzl.UIModel.Flight;

namespace Mzl.Mojory.WebApi.Controllers.Customer
{
    /// <summary>
    /// 修改密码
    /// </summary>
    public class UpdatePwdController : ApiController
    {
        private readonly IUpdateCustomerPwdApplication _updateCustomerPwdApplication;

        public UpdatePwdController(IUpdateCustomerPwdApplication updateCustomerPwdApplication)
        {
            _updateCustomerPwdApplication = updateCustomerPwdApplication;
        }

        /// <summary>
        /// 更改差旅网站用户密码
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ResponseBaseViewModel<UpdateCustomerPwdResponseViewModel>> UpdateMojoryCustomerPwd(
            [FromBody] UpdateCustomerPwdRequestViewModel request)
        {
            request.Cid = this.GetCid();
            bool flag = false;
            await new TaskFactory().StartNew(() =>
            {
                flag = _updateCustomerPwdApplication.UpdateMojoryCustomerPwd(request);
            });

            ResponseBaseViewModel<UpdateCustomerPwdResponseViewModel> v = new ResponseBaseViewModel
                <UpdateCustomerPwdResponseViewModel>
            {
                Flag = new ResponseCodeViewModel() {Code = 0, MojoryToken = this.GetToken()},
                Data = new UpdateCustomerPwdResponseViewModel() {IsSuccessed = flag}
            };
            return v;
        }

    }
}
