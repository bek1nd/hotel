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
    /// 差旅预订员客户
    /// </summary>
    public class TripBookingCustomerBll : TripCustomerBll
    {
        public int? DepartId { get;private set; }
        public TripBookingCustomerBll(CustomerInfoEntity customer,int? departId) : base(customer)
        {
            DepartId = departId;
        }

        public override List<PassengerInfoModel> GetPassenger(ICustomerVisitor customerVisitor)
        {
            return customerVisitor.GetPassenger(this);
        }
    }
}
