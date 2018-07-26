using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mzl.IBLL.Train.Order.BLL
{
    public interface ITraPassengerBLL<T> where T : class
    {
        /// <summary>
        /// 新增乘车人信息
        /// </summary>
        /// <param name="tList">乘车人信息</param>
        /// <returns></returns>
        int AddPassengerList(IEnumerable<T> tList);
        /// <summary>
        /// 根据订单号获取乘车人信息
        /// </summary>
        /// <param name="orderid">订单号</param>
        /// <returns></returns>
        List<T> GetPassengerListByOrderId(int orderid);
        /// <summary>
        /// 根据行程id获取对应的乘车人信息
        /// </summary>
        /// <param name="odIdsList"></param>
        /// <returns></returns>
        List<T> GetPassengerListByOdId(List<int> odIdsList);
        /// <summary>
        /// 根据pid获取乘车人信息
        /// </summary>
        /// <param name="pidList"></param>
        /// <returns></returns>
        List<T> GetPassengerListByPid(List<int> pidList);

        /// <summary>
        /// 更新乘车人信息
        /// </summary>
        /// <param name="tList"></param>
        /// <param name="paramStrings"></param>
        int UpdatePassengerList(List<T> tList,string[] paramStrings=null);
    }
}
