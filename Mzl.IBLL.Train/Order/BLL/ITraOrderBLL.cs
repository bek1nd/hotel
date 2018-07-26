using Mzl.DomainModel.Train.Order;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mzl.IBLL.Train.Order.BLL
{
    public interface ITraOrderBLL<T> where T : class
    {
        /// <summary>
        /// 新增一条订单信息记录
        /// </summary>
        /// <param name="t">订单信息</param>
        /// <returns></returns>
        int AddOrder(T t);

        /// <summary>
        /// 更新订单主表记录
        /// </summary>
        /// <param name="t">订单信息</param>
        /// <param name="paramStrings"></param>
        /// <returns></returns>
        int UpdateOrder(T t, string[] paramStrings = null);
        /// <summary>
        /// 根据订单号获取订单主表记录
        /// </summary>
        /// <param name="orderId">订单号</param>
        /// <returns></returns>
        T GetOrderByOrderId(int orderId);
        /// <summary>
        /// 根据正单号获取退票订单
        /// </summary>
        /// <returns></returns>
        List<T> GetRetOrderByRootOrderId(int rootOrderid, bool isNeedCancle = false);

        List<T> GetRetOrderByRootOrderId(List<int> rootOrderidList);
        /// <summary>
        /// 获取订单集合信息
        /// </summary>
        /// <returns></returns>
        List<T> GetOrderList();

        /// <summary>
        /// 根据原订单号和车票信息查询对应的退票信息
        /// </summary>
        /// <param name="orderRoot"></param>
        /// <param name="ticketNoList"></param>
        /// <param name="orderType"></param>
        /// <returns></returns>
        T GetTraRetOrderByOrderRootAndTicketNo(int orderRoot, List<string> ticketNoList, int orderType = 2);
        /// <summary>
        /// 根据原订单号和车票信息查询对应的退票信息
        /// </summary>
        /// <param name="orderRoot"></param>
        /// <param name="ticketNoList"></param>
        /// <param name="orderType"></param>
        /// <returns></returns>
        List<T> GetTraRetOrderListByOrderRootAndTicketNo(int orderRoot, List<string> ticketNoList, int orderType = 2);
    }
}
