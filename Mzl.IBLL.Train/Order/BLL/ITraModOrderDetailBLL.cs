using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mzl.IBLL.Train.Order.BLL
{
    public interface ITraModOrderDetailBLL<T> where T : class
    {
        /// <summary>
        /// 根据改签订单获取改签信息
        /// </summary>
        /// <param name="corderid"></param>
        /// <returns></returns>
        List<T> GetTraModOrderDetailListByCorderid(int corderid);
        /// <summary>
        /// 根据改签订单获取改签信息
        /// </summary>
        /// <param name="corderid"></param>
        /// <returns></returns>
        List<T> GetTraModOrderDetailListByCorderid(List<int> corderid);
        /// <summary>
        /// 添加行程信息
        /// </summary>
        /// <param name="detailList"></param>
        /// <returns></returns>
        int AddTraModOrderDetail(List<T> detailList);
        int UpdateTraModOrderDetail(List<T> detailList, string[] paramsStr=null);
    }
}
