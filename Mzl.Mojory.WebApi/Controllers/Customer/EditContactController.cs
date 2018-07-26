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
    /// 修改联系人(临客)信息
    /// </summary>
    public class EditContactController : ApiController
    {
        private readonly IEditContactApplication _editContactApplication;

        public EditContactController(IEditContactApplication editContactApplication)
        {
            _editContactApplication = editContactApplication;
        }

        /// <summary>
        /// 修改联系人(临客)信息
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ResponseBaseViewModel<EditContactResponseViewModel>> EditContact(
           [FromBody] EditContactRequestViewModel request)
        {
            request.Cid = this.GetCid();
            EditContactResponseViewModel viewModel = new EditContactResponseViewModel();
            await new TaskFactory().StartNew(() =>
            {
                viewModel = _editContactApplication.EditContact(request);
            });

            ResponseBaseViewModel<EditContactResponseViewModel> v = new ResponseBaseViewModel
                <EditContactResponseViewModel>
            {
                Flag = new ResponseCodeViewModel() { Code = 0, MojoryToken = this.GetToken() },
                Data = viewModel
            };
            return v;
        }
    }
}
