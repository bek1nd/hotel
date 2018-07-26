using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Mzl.DomainModel.Customer.ContactInfo;
using Mzl.Framework.Base;
using Mzl.IApplication.Customer;
using Mzl.IBLL.Customer.ContactInfo;
using Mzl.UIModel.Customer.Customer;

namespace Mzl.Application.Customer
{
    internal class SearchContactsApplication: BaseApplicationService,ISearchContactsApplication
    {
        private readonly ISearchContactsServiceBll _searchContactsServiceBll;

        public SearchContactsApplication(ISearchContactsServiceBll searchContactsServiceBll)
        {
            _searchContactsServiceBll = searchContactsServiceBll;
        }

        public SearchContactsResponseViewModel SearchContacts(SearchContactsRequestViewModel request)
        {
            SearchContactsResponseViewModel responseViewModel = new SearchContactsResponseViewModel();
            List < ContactInfoModel > contactInfoModels= _searchContactsServiceBll.SearchContacts(request.SearchArgs, request.Cid);

            responseViewModel.ContactList = Mapper.Map<List<ContactInfoModel>, List<ContactViewModel>>(contactInfoModels);

            return responseViewModel;
        }
    }
}
