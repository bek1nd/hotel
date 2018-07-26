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
using Mzl.UIModel.Customer.Customer;

namespace Mzl.Mojory.WebApi.Controllers.Customer
{
    /// <summary>
    /// 新增联系人(临客)信息
    /// </summary>
    public class AddContactController : ApiController
    {
        private readonly IAddContactApplication _addContactApplication;

        public AddContactController(IAddContactApplication addContactApplication)
        {
            _addContactApplication = addContactApplication;
        }

        /// <summary>
        /// 新增联系人信息
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ResponseBaseViewModel<AddContactResponseViewModel>> AddContact(
           [FromBody] AddContactRequestViewModel request)
        {
            request.Cid = this.GetCid();
            request.OrderSource = this.GetOrderSource();
            AddContactResponseViewModel viewModel = new AddContactResponseViewModel();
            await new TaskFactory().StartNew(() =>
            {
                viewModel = _addContactApplication.AddContact(request);
            });

            ResponseBaseViewModel<AddContactResponseViewModel> v = new ResponseBaseViewModel
                <AddContactResponseViewModel>
            {
                Flag = new ResponseCodeViewModel() { Code = 0, MojoryToken = this.GetToken() },
                Data = viewModel
            };
            return v;
        }
    }
}
