using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mzl.IBLL.Train.Order.BLL
{
    public interface ITraOrderStatusBLL<T> where T : class
    {
        /// <summary>
        /// 新增订单状态信息
        /// </summary>
        /// <param name="t">订单状态</param>
        /// <returns></returns>
        int AddOrderStatus(T t);
        /// <summary>
        /// 更新订单状态
        /// </summary>
        /// <param name="t"></param>
        /// <param name="paramsStrings"></param>
        /// <returns></returns>
        int UpdateOrderStatus(T t,string[] paramsStrings=null);
        /// <summary>
        /// 根据订单号获取订单状态信息
        /// </summary>
        /// <param name="orderid">订单号</param>
        /// <returns></returns>
        T GetOrderStatusByOrderId(int orderid);
        /// <summary>
        /// 根据订单号获取订单状态信息
        /// </summary>
        /// <param name="orderidList"></param>
        /// <returns></returns>
        List<T> GetOrderStatusByOrderIds(List<int> orderidList);
    }
}
