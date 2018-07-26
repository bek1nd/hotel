using Mzl.DomainModel.Customer.Base;
using Mzl.DomainModel.Flight;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mzl.Framework.Base;

namespace Mzl.IBLL.Customer.Customer
{
    public interface IGetCorpPassengerCustomerServiceBll : IBaseServiceBll
    {
        List<CorpPassengerCustomerModel> GetCorpPassengerCustomer(List<int> contactList);
    }
}
