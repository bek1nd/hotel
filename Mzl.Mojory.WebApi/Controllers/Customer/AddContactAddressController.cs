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
    /// 添加送票地址
    /// </summary>
    public class AddContactAddressController : ApiController
    {
        private readonly IAddContactAddressApplication _addContactAddressApplication;

        public AddContactAddressController(IAddContactAddressApplication addContactAddressApplication)
        {
            _addContactAddressApplication = addContactAddressApplication;
        }

        /// <summary>
        /// 添加送票地址
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ResponseBaseViewModel<AddContactAddressResponseViewModel>> AddContactAddress(
            [FromBody] AddContactAddressRequestViewModel request)
        {
            request.Cid = this.GetCid();
            request.Oid = this.GetOid();
            AddContactAddressResponseViewModel viewModel = new AddContactAddressResponseViewModel();
            await new TaskFactory().StartNew(() =>
            {
                viewModel = _addContactAddressApplication.AddAddress(request);
            });

            ResponseBaseViewModel<AddContactAddressResponseViewModel> v = new ResponseBaseViewModel
                <AddContactAddressResponseViewModel>
            {
                Flag = new ResponseCodeViewModel() { Code = 0, MojoryToken = this.GetToken() },
                Data = viewModel
            };
            return v;
        }
    }
}
