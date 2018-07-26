using Mzl.DomainModel.Customer.Passenger;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mzl.BLL.Customer.Customer
{
    public interface ICustomerVisitor
    {
        /// <summary>
        /// 非差旅客户获取乘客信息
        /// </summary>
        /// <param name="customerBll"></param>
        /// <returns></returns>
        List<PassengerInfoModel> GetPassenger(CommonCustomerBll customerBll);
        /// <summary>
        /// 差旅预订员客户获取乘客信息
        /// </summary>
        /// <param name="customerBll"></param>
        /// <returns></returns>
        List<PassengerInfoModel> GetPassenger(TripBookingCustomerBll customerBll);
        /// <summary>
        /// 差旅非预订员客户获取乘客信息
        /// </summary>
        /// <param name="customerBll"></param>
        /// <returns></returns>
        List<PassengerInfoModel> GetPassenger(TripNotBookingCustomerBll customerBll);
        /// <summary>
        /// 差旅预订员客户获取所有公司的乘客信息
        /// </summary>
        /// <param name="customerBll"></param>
        /// <returns></returns>
        List<PassengerInfoModel> GetPassenger(TripDepartBookingCustomerBll customerBll);
    }
}
