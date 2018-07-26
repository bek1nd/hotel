using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mzl.IBLL.Train.Order.BLL
{
    public interface ITraOrderDetailBLL<T> where T : class
    {
        /// <summary>
        /// 批量新增订单行程信息
        /// </summary>
        /// <param name="t">订单行程信息</param>
        /// <returns></returns>
        int AddOrderDetail(T t);
        /// <summary>
        /// 更新行程信息
        /// </summary>
        /// <param name="t"></param>
        /// <param name="paramsStrings"></param>
        /// <returns></returns>
        int UpdateOrderDetail(List<T> t, string[] paramsStrings = null);
        /// <summary>
        /// 根据订单号获取对应行程信息
        /// </summary>
        /// <param name="orderid">订单号</param>
        /// <returns></returns>
        List<T> GetOrderDetailListByOrderId(int orderid);

        List<T> GetOrderDetailListByOrderId(List<int> orderids);
    }
}
