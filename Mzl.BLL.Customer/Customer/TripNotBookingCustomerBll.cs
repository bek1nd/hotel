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
    /// 差旅非预订员客户
    /// </summary>
    public class TripNotBookingCustomerBll: TripCustomerBll
    {
        public TripNotBookingCustomerBll(CustomerInfoEntity customer) : base(customer)
        {
        }
        public override List<PassengerInfoModel> GetPassenger(ICustomerVisitor customerVisitor)
        {
            return customerVisitor.GetPassenger(this);
        }

       
    }
}
