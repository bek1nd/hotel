using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mzl.DomainModel.Flight;

namespace Mzl.BLL.Flight.AddOrderCustomer
{
    /// <summary>
    /// 添加差旅订单访问者
    /// </summary>
    public class AddCorpOrderCustomerVisitor : IAddCorpOrderCustomerVisitor
    {
        /// <summary>
        /// 预定员
        /// </summary>
        /// <param name="bookingCustomer"></param>
        /// <returns></returns>
        public AddOrderModel AddCorpOrderValidate(AddCorpOrderBookingCustomer bookingCustomer)
        {
            bookingCustomer.AddOrder.CheckStatus = "F";
            return bookingCustomer.AddOrder;
        }
        /// <summary>
        /// 不需要审核
        /// </summary>
        /// <param name="notNeedCheckCustomer"></param>
        /// <returns></returns>
        public AddOrderModel AddCorpOrderValidate(AddCorpOrderNotNeedCheckCustomer notNeedCheckCustomer)
        {
            notNeedCheckCustomer.AddOrder.CheckStatus = "F";
            return notNeedCheckCustomer.AddOrder;
        }
        /// <summary>
        /// 需要审核
        /// </summary>
        /// <param name="needCheckCustomer"></param>
        /// <returns></returns>
        public AddOrderModel AddCorpOrderValidate(AddCorpOrderNeedCheckCustomer needCheckCustomer)
        {
            needCheckCustomer.AddOrder.CheckStatus = "T";
            //1.获取乘机人的审核人信息和对应的代审核人信息
            if (needCheckCustomer.AddOrder.PassengerCustomerList[0].CPCID.HasValue)//乘机人存在审核人信息
            {
                needCheckCustomer.AddOrder.CPId = needCheckCustomer.AddOrder.PassengerCustomerList[0].CPCID;
                needCheckCustomer.AddOrder.CheckType = needCheckCustomer.AddOrder.PassengerCustomerList[0].CheckType;
                needCheckCustomer.AddOrder.TelTime = needCheckCustomer.AddOrder.PassengerCustomerList[0].TelTime ?? 30;
                if (needCheckCustomer.AddOrder.PassengerCustomerList[0].CPIDSecond.HasValue)
                {
                    needCheckCustomer.AddOrder.CPIdSecond = needCheckCustomer.AddOrder.PassengerCustomerList[0].CPIDSecond;
                }
            }
            else if (needCheckCustomer.AddOrder.PassengerCustomerList[0].Department?.CPCID != null) //不存在乘机人审核信息，找部门信息
            {
                needCheckCustomer.AddOrder.CPId =
                    needCheckCustomer.AddOrder.PassengerCustomerList[0].Department.CPCID;
                needCheckCustomer.AddOrder.CheckType =
                    needCheckCustomer.AddOrder.PassengerCustomerList[0].Department.CheckType;
                needCheckCustomer.AddOrder.TelTime =
                    needCheckCustomer.AddOrder.PassengerCustomerList[0].Department.TelTime ?? 30;
                if (needCheckCustomer.AddOrder.PassengerCustomerList[0].Department.CPIDSecond.HasValue)
                {
                    needCheckCustomer.AddOrder.CPIdSecond =
                        needCheckCustomer.AddOrder.PassengerCustomerList[0].Department.CPIDSecond;
                }
            }

            return needCheckCustomer.AddOrder;
        }

    }
}
