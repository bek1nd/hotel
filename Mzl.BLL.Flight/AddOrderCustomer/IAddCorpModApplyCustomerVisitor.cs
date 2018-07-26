using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mzl.DomainModel.Flight;

namespace Mzl.BLL.Flight.AddOrderCustomer
{
    public interface IAddCorpModApplyCustomerVisitor
    {
        AddRetModApplyModel AddCorpModApplyValidate(AddCorpOrderBookingCustomer bookingCustomer);
        AddRetModApplyModel AddCorpModApplyValidate(AddCorpOrderNotNeedCheckCustomer notNeedCheckCustomer);
        AddRetModApplyModel AddCorpModApplyValidate(AddCorpOrderNeedCheckCustomer needCheckCustomer);
    }
}
