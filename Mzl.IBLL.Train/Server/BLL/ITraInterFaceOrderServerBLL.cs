using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mzl.IBLL.Train.Server.BLL
{
    public interface ITraInterFaceOrderServerBLL<T> where T : class
    {

        List<T> GetTraInterFaceOrderByTransactionid(string transactionid);
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
        /// <param name="properties"></param>
        /// <returns></returns>
        int UpdateOrder(T t, string[] properties = null);
        /// <summary>
        /// 根据接口订单号获取接口订单主表记录
        /// </summary>
        /// <param name="transactionid">接口订单号</param>
        /// <returns></returns>
        T GetOrderByTransactionid(string transactionid);
        /// <summary>
        /// 根据系统订单号获取接口订单主表记录
        /// </summary>
        /// <param name="orderId"></param>
        /// <returns></returns>
        T GetOrderByOrderId(string orderId);
        /// <summary>
        /// 分页获取订单集合信息
        /// </summary>
        /// <returns></returns>
        IEnumerable<T> GetOrderListByPage();
        /// <summary>
        /// 获取订单集合信息
        /// </summary>
        /// <returns></returns>
        IEnumerable<T> GetOrderList();
        List<T> GetOrderByOrderIdList(List<string> orderIdList);
        /// <summary>
        /// 根据查询时间和状态获取接口订单信息
        /// </summary>
        /// <param name="statusList"></param>
        /// <param name="queryTime"></param>
        /// <returns></returns>
        List<T> GetOrderListByStatus(List<int> statusList,DateTime queryTime);
    }
}
