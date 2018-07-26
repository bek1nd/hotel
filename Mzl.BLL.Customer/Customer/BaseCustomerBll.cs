using Mzl.DomainModel.Customer.Passenger;
using Mzl.EntityModel.Customer.BaseInfo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mzl.BLL.Customer.Customer
{
    public abstract class BaseCustomerBll
    {
        public CustomerInfoEntity Customer { get;private set; }

        protected BaseCustomerBll(CustomerInfoEntity customer)
        {
            Customer = customer;
        }

        /// <summary>
        /// 在创建订单页面获取乘客信息
        /// </summary>
        /// <returns></returns>
        public abstract List<PassengerInfoModel> GetPassenger(ICustomerVisitor customerVisitor);
    }
}
