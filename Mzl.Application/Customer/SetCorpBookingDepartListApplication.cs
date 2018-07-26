using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mzl.Framework.Base;
using Mzl.IApplication.Customer;
using Mzl.IBLL.Customer.Customer;
using Mzl.UIModel.Customer.Customer;

namespace Mzl.Application.Customer
{
    internal class SetCorpBookingDepartListApplication : BaseApplicationService, ISetCorpBookingDepartListApplication
    {
        private readonly IUpdateCustomerServiceBll _updateCustomerServiceBll;

        public SetCorpBookingDepartListApplication(IUpdateCustomerServiceBll updateCustomerServiceBll)
        {
            _updateCustomerServiceBll = updateCustomerServiceBll;
        }

        public SetCorpBookingDepartListResponseViewModel SetDepartList(SetCorpBookingDepartListRequestViewModel request)
        {
            bool flag = _updateCustomerServiceBll.UpdateCustomerCorpDepartIdList(request.CustomerCid,
                request.DepartIdList, request.IsAll);
            return new SetCorpBookingDepartListResponseViewModel() {IsSuccessed = flag};
        }
    }
}
