using Mzl.Common.Factory;
using Mzl.EntityModel.Train.Order;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Mzl.IDAL.Train.Order.DAL
{
    public interface ITraOrderDAL : IBaseDAL<TraOrderEntity>
    {
        /// <summary>
        /// 根据条件获取订单信息
        /// </summary>
        /// <param name="predicate"></param>
        /// <param name="isNeedCancle">是否获取已经取消的订单</param>
        /// <returns></returns>
        List<TraOrderEntity> GetTraOrderListExpression(Expression<Func<TraOrderEntity, bool>> predicate,
            bool isNeedCancle = false);

        /// <summary>
        /// 根据原订单号和车票信息查询对应的退票信息
        /// </summary>
        /// <param name="orderRoot"></param>
        /// <param name="ticketNoList"></param>
        /// <param name="orderType"></param>
        /// <returns></returns>
        TraOrderEntity GetTraRetOrderByOrderRootAndTicketNo(int orderRoot, List<string> ticketNoList, int orderType = 2);
        List<TraOrderEntity> GetTraRetOrderListByOrderRootAndTicketNo(int orderRoot, List<string> ticketNoList, int orderType = 2);
    }
}
