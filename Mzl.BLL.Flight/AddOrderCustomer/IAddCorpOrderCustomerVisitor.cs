using Mzl.DomainModel.Flight;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mzl.BLL.Flight.AddOrderCustomer
{
    public interface IAddCorpOrderCustomerVisitor
    {
        AddOrderModel AddCorpOrderValidate(AddCorpOrderBookingCustomer bookingCustomer);
        AddOrderModel AddCorpOrderValidate(AddCorpOrderNotNeedCheckCustomer notNeedCheckCustomer);
        AddOrderModel AddCorpOrderValidate(AddCorpOrderNeedCheckCustomer needCheckCustomer);

    }
}
