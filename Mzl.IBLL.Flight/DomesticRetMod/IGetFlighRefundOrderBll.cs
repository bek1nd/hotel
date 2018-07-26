using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mzl.DomainModel.Flight;

namespace Mzl.IBLL.Flight.DomesticRetMod
{
    public interface IGetFlighRefundOrderBll
    {
        /// <summary>
        /// 根据id获取退票信息
        /// </summary>
        /// <param name="refundId"></param>
        /// <returns></returns>
        FltRefundOrderModel GetFlighRefundOrderById(int refundId);
        /// <summary>
        /// 根据订单号获取退票信息
        /// </summary>
        /// <param name="orderId"></param>
        /// <returns></returns>
        List<FltRefundOrderModel> GetFlighRefundOrderByOrderId(int orderId);
        /// <summary>
        /// 根据退票申请Id获取退票信息
        /// </summary>
        /// <param name="rmid"></param>
        /// <returns></returns>
        FltRefundOrderModel GetFlighRefundOrderByRmid(int rmid);
    } 
}
