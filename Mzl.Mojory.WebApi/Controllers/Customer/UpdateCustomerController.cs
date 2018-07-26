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
    /// 修改客户信息
    /// </summary>
    public class UpdateCustomerController : ApiController
    {
        private readonly IUpdateCustomerApplication _updateCustomerApplication;

        public UpdateCustomerController(IUpdateCustomerApplication updateCustomerApplication)
        {
            _updateCustomerApplication = updateCustomerApplication;
        }

        /// <summary>
        /// 修改头像路径
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ResponseBaseViewModel<UpdateCustomerHeadPictureResponseViewModel>> UpdateCustomerHeadPicture(
            [FromBody] UpdateCustomerHeadPictureRequestViewModel request)
        {
            request.Cid = this.GetCid();
            UpdateCustomerHeadPictureResponseViewModel flag = new UpdateCustomerHeadPictureResponseViewModel();
            await new TaskFactory().StartNew(() =>
            {
                flag = _updateCustomerApplication.UpdateCustomerHeadPicture(request);
            });

            ResponseBaseViewModel<UpdateCustomerHeadPictureResponseViewModel> v = new ResponseBaseViewModel
                <UpdateCustomerHeadPictureResponseViewModel>
            {
                Flag = new ResponseCodeViewModel() {Code = 0, MojoryToken = this.GetToken()},
                Data = flag
            };
            return v;
        }

        /// <summary>
        /// 修改客户基本信息
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ResponseBaseViewModel<UpdateCustomerInfoResponseViewModel>> UpdateCustomerInfo(
           [FromBody] UpdateCustomerInfoRequestViewModel request)
        {
            request.Cid = this.GetCid();
            UpdateCustomerInfoResponseViewModel flag = new UpdateCustomerInfoResponseViewModel();
            await new TaskFactory().StartNew(() =>
            {
                flag = _updateCustomerApplication.UpdateCustomerInfo(request);
            });

            ResponseBaseViewModel<UpdateCustomerInfoResponseViewModel> v = new ResponseBaseViewModel
                <UpdateCustomerInfoResponseViewModel>
            {
                Flag = new ResponseCodeViewModel() { Code = 0, MojoryToken = this.GetToken() },
                Data = flag
            };
            return v;
        }


    }
}
