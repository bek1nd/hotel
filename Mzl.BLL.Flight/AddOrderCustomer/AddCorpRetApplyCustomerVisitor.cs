using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mzl.Common.EnumHelper;
using Mzl.DomainModel.Flight;

namespace Mzl.BLL.Flight.AddOrderCustomer
{
    public class AddCorpRetApplyCustomerVisitor : IAddCorpRetApplyCustomerVisitor
    {
        /// <summary>
        ///  改签申请——预订员
        /// </summary>
        /// <param name="bookingCustomer"></param>
        /// <returns></returns>
        public AddRetModApplyModel AddCorpRetApplyValidate(AddCorpOrderBookingCustomer bookingCustomer)
        {
            bookingCustomer.AddModApply.OrderStatus = FltRetApplyStatusEnum.W.ToString();
            bookingCustomer.AddModApply.DetailList.ForEach(n => n.OrderStatus = FltRetApplyStatusEnum.W.ToString());
            return bookingCustomer.AddModApply;
        }
        /// <summary>
        /// 改签申请——不需审核
        /// </summary>
        /// <param name="notNeedCheckCustomer"></param>
        /// <returns></returns>
        public AddRetModApplyModel AddCorpRetApplyValidate(AddCorpOrderNotNeedCheckCustomer notNeedCheckCustomer)
        {
            notNeedCheckCustomer.AddModApply.OrderStatus = FltRetApplyStatusEnum.W.ToString();
            notNeedCheckCustomer.AddModApply.DetailList.ForEach(n => n.OrderStatus = FltRetApplyStatusEnum.W.ToString());
            return notNeedCheckCustomer.AddModApply;
        }
        /// <summary>
        /// 改签申请——需要审核
        /// </summary>
        /// <param name="needCheckCustomer"></param>
        /// <returns></returns>
        public AddRetModApplyModel AddCorpRetApplyValidate(AddCorpOrderNeedCheckCustomer needCheckCustomer)
        {
            needCheckCustomer.AddModApply.OrderStatus = FltRetApplyStatusEnum.T.ToString();
            needCheckCustomer.AddModApply.DetailList.ForEach(n => n.OrderStatus = FltRetApplyStatusEnum.T.ToString());
            return needCheckCustomer.AddModApply;
        }
    }
}
