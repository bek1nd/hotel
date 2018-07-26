using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mzl.DomainModel.Customer.Passenger;
using Mzl.EntityModel.Customer.BaseInfo;

namespace Mzl.BLL.Customer.Customer
{
    /// <summary>
    ///  差旅客户抽象
    /// </summary>
    public abstract class TripCustomerBll : BaseCustomerBll
    {
        protected TripCustomerBll(CustomerInfoEntity customer) : base(customer)
        {

        }
    }
}
