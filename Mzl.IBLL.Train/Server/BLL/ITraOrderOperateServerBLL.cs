using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mzl.IBLL.Train.Server.BLL
{
  public  interface ITraOrderOperateServerBLL<T> where T : class
    {


        int GetOrderByOrderId(string orderId);
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
        /// <returns></returns>
        int UpdateOrder(T t);
        /// <summary>
        /// 根据订单号获取订单主表记录
        /// </summary>
        /// <param name="orderId">订单号</param>
        /// <returns></returns>
        T GetOrderByOrderId(int orderId);
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
    }
}
