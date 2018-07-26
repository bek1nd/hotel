using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mzl.Common.EnumHelper;
using Mzl.DomainModel.Flight;

namespace Mzl.BLL.Flight.AddOrderCustomer
{
    public class AddCorpModApplyCustomerVisitor : IAddCorpModApplyCustomerVisitor
    {

        /// <summary>
        /// 改签申请——预订员
        /// </summary>
        /// <param name="bookingCustomer"></param>
        /// <returns></returns>
        public AddRetModApplyModel AddCorpModApplyValidate(AddCorpOrderBookingCustomer bookingCustomer)
        {
            bookingCustomer.AddModApply.OrderStatus = FltModApplyStatusEnum.W.ToString();
            bookingCustomer.AddModApply.DetailList.ForEach(n => n.OrderStatus = FltModApplyStatusEnum.W.ToString());
            return bookingCustomer.AddModApply;
        }
        /// <summary>
        /// 改签申请——不需审核
        /// </summary>
        /// <param name="notNeedCheckCustomer"></param>
        /// <returns></returns>
        public AddRetModApplyModel AddCorpModApplyValidate(AddCorpOrderNotNeedCheckCustomer notNeedCheckCustomer)
        {
            notNeedCheckCustomer.AddModApply.OrderStatus = FltModApplyStatusEnum.W.ToString();
            notNeedCheckCustomer.AddModApply.DetailList.ForEach(n => n.OrderStatus = FltModApplyStatusEnum.W.ToString());
            return notNeedCheckCustomer.AddModApply;
        }
        /// <summary>
        /// 改签申请——需要审核
        /// </summary>
        /// <param name="needCheckCustomer"></param>
        /// <returns></returns>
        public AddRetModApplyModel AddCorpModApplyValidate(AddCorpOrderNeedCheckCustomer needCheckCustomer)
        {
            needCheckCustomer.AddModApply.OrderStatus = FltModApplyStatusEnum.T.ToString();
            needCheckCustomer.AddModApply.DetailList.ForEach(n => n.OrderStatus = FltModApplyStatusEnum.T.ToString());
            return needCheckCustomer.AddModApply;
        }
    }
}
