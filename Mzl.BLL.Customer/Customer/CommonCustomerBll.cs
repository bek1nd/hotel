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
    /// 普通客户，非差旅客户
    /// </summary>
    public class CommonCustomerBll : BaseCustomerBll
    {
        public CommonCustomerBll(CustomerInfoEntity customer) : base(customer)
        {
        }
        public override List<PassengerInfoModel> GetPassenger(ICustomerVisitor customerVisitor)
        {
            return customerVisitor.GetPassenger(this);
        }

        
    }
}
