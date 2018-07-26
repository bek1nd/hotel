using Mzl.DomainModel.Flight;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mzl.BLL.Flight.AddOrderCustomer
{
    public interface IAddCorpRetApplyCustomerVisitor
    {
        /// <summary>
        ///  改签申请——预订员
        /// </summary>
        /// <param name="bookingCustomer"></param>
        /// <returns></returns>
        AddRetModApplyModel AddCorpRetApplyValidate(AddCorpOrderBookingCustomer bookingCustomer);
        /// <summary>
        /// 改签申请——不需审核
        /// </summary>
        /// <param name="notNeedCheckCustomer"></param>
        /// <returns></returns>
        AddRetModApplyModel AddCorpRetApplyValidate(AddCorpOrderNotNeedCheckCustomer notNeedCheckCustomer);
        /// <summary>
        ///  改签申请——需要审核
        /// </summary>
        /// <param name="needCheckCustomer"></param>
        /// <returns></returns>
        AddRetModApplyModel AddCorpRetApplyValidate(AddCorpOrderNeedCheckCustomer needCheckCustomer);
    }
}
