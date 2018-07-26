using Mzl.DomainModel.Train.Order;
using Mzl.EntityModel.Train.Order;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mzl.IBLL.Train.Order.BLL
{
    public interface ITraOrderListBLL<T> where T : class
    {
        /// <summary>
        /// 分页获取订单集合信息
        /// </summary>
        /// <returns></returns>
        List<T> GetOrderListByPage(TraOrderListQueryModel queryModel, ref int totalCount);
        /// <summary>
        /// 分页获取改签订单集合信息
        /// </summary>
        /// <param name="queryModel"></param>
        /// <param name="totalCount"></param>
        /// <returns></returns>
        List<T> GetTraModOrderByPageList(TraModOrderListQueryModel queryModel, ref int totalCount);
    }
}
