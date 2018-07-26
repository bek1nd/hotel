using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mzl.Framework.Base;
using Mzl.IApplication.Customer;
using Mzl.IBLL.Customer.ContactInfo;
using Mzl.UIModel.Customer.Customer;

namespace Mzl.Application.Customer
{
    internal class AddContactAddressApplication : BaseApplicationService, IAddContactAddressApplication
    {
        private readonly IAddContactAddressServiceBll _addContactAddressServiceBll;

        public AddContactAddressApplication(IAddContactAddressServiceBll addContactAddressServiceBll)
        {
            _addContactAddressServiceBll = addContactAddressServiceBll;
        }

        public AddContactAddressResponseViewModel AddAddress(AddContactAddressRequestViewModel request)
        {

            bool flag = _addContactAddressServiceBll.AddAddress(request.Address, request.Cid, request.Oid);

            return new AddContactAddressResponseViewModel() {IsSuccessed = flag};
        }
    }
}
