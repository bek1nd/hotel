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
    /// 查询联系人
    /// </summary>
    public class SearchContactsController : ApiController
    {
        private readonly ISearchContactsApplication _searchContactsApplication;

        public SearchContactsController(ISearchContactsApplication searchContactsApplication)
        {
            _searchContactsApplication = searchContactsApplication;
        }

        /// <summary>
        /// 查询联系人信息
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ResponseBaseViewModel<SearchContactsResponseViewModel>> SearchContacts(
         [FromBody] SearchContactsRequestViewModel request)
        {
            request.Cid = this.GetCid();
            SearchContactsResponseViewModel viewModel = new SearchContactsResponseViewModel();
            await new TaskFactory().StartNew(() =>
            {
                viewModel = _searchContactsApplication.SearchContacts(request);
            });

            ResponseBaseViewModel<SearchContactsResponseViewModel> v = new ResponseBaseViewModel
                <SearchContactsResponseViewModel>
            {
                Flag = new ResponseCodeViewModel() {Code = 0, MojoryToken = this.GetToken()},
                Data = viewModel
            };
            return v;
        }
    }
}
