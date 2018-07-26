using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mzl.DomainModel.Customer.Passenger;
using Mzl.EntityModel.Customer.BaseInfo;

namespace Mzl.BLL.Customer.Customer
{
    public class TripDepartBookingCustomerBll : TripCustomerBll
    {
        public string CorpId { get; private set; }
        public string CorpDepartIdList { get; private set; }
        public TripDepartBookingCustomerBll(CustomerInfoEntity customer,string corpId, string corpDepartIdList) : base(customer)
        {
            CorpId = corpId;
            CorpDepartIdList = corpDepartIdList;
        }

        public override List<PassengerInfoModel> GetPassenger(ICustomerVisitor customerVisitor)
        {
            return customerVisitor.GetPassenger(this);
        }
    }
}
