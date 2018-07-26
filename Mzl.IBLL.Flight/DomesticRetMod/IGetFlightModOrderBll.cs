using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mzl.DomainModel.Flight;

namespace Mzl.IBLL.Flight.DomesticRetMod
{
    public interface IGetFlightModOrderBll
    {
        SearchCityAportModel AportInfo { set; }
        /// <summary>
        /// 通过改签id获取改签订单信息
        /// </summary>
        /// <param name="rmid"></param>
        /// <returns></returns>
        FltModOrderModel GetModOrderByRmid(int rmid);

        /// <summary>
        /// 通过改签订单号获取改签订单信息
        /// </summary>
        /// <param name="modOrderId"></param>
        /// <returns></returns>
        FltModOrderModel GetModOrderByModOrderId(string modOrderId);
        /// <summary>
        /// 通过订单号获取改签订单信息
        /// </summary>
        /// <param name="orderId"></param>
        /// <returns></returns>
        List<FltModOrderModel> GetModOrderByOrderId(int orderId);
    }
}
