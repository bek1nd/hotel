using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mzl.IBLL.Train.Order.BLL
{
    public interface ITraModOrderBLL<T> where T : class
    {
        /// <summary>
        /// 根据改签订单号获取改签订单信息
        /// </summary>
        /// <param name="corderid"></param>
        /// <returns></returns>
        T GetModOrderBycorderid(int corderid);
        /// <summary>
        /// 根据原订单号获取改签订单信息
        /// </summary>
        /// <param name="orderid"></param>
        /// <returns></returns>
        List<T> GetModOrderByOrderId(int orderid);

        List<T> GetModOrderByOrderId(List<int> orderidList);
        /// <summary>
        /// 新增改签订单信息
        /// </summary>
        /// <param name="t"></param>
        /// <returns></returns>
        int AddModOrder(T t);

        /// <summary>
        /// 修改改签订单信息
        /// </summary>
        /// <param name="t"></param>
        /// <param name="paramsStr"></param>
        /// <returns></returns>
        int UpdateModOrder(T t, string[] paramsStr = null);
        /// <summary>
        /// 根据订单号和票号获取改签信息
        /// </summary>
        /// <param name="orderId"></param>
        /// <param name="ticketNoList"></param>
        /// <returns></returns>
        T GetTraModOrderByOrderIdAndTicketNo(int orderId, List<string> ticketNoList);
        /// <summary>
        /// 根据订单号和票号获取改签信息
        /// </summary>
        /// <param name="orderId"></param>
        /// <param name="ticketNoList"></param>
        /// <returns></returns>
        List<T> GetTraModOrderListByOrderIdAndTicketNo(int orderId, List<string> ticketNoList);
    }
}
