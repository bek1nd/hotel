using System.Collections.Generic;

namespace Mzl.IBLL.Customer.Customer.BLL
{
    public interface ICustomerBLL<T> where T : class
    {
        /// <summary>
        /// 根据部门获取客户信息
        /// </summary>
        /// <param name="departId"></param>
        /// <returns></returns>
        List<T> GetCustomerByDepartId(int departId, string name = "");
        /// <summary>
        /// 根据部门获取客户信息
        /// </summary>
        /// <param name="departIds"></param>
        /// <returns></returns>
        List<T> GetCustomerByDepartId(List<int> departIds);
        /// <summary>
        /// 根据客户id获取客户信息
        /// </summary>
        /// <param name="cid"></param>
        /// <returns></returns>
        T GetCustomerByCid(int cid);
    }
}
