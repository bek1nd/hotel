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
    public interface ITraModOrderDAL : IBaseDAL<TraModOrderEntity>
    {
        /// <summary>
        /// 根据条件获取改签订单集合信息
        /// </summary>
        /// <param name="predicate"></param>
        /// <returns></returns>
        List<TraModOrderEntity> GetTraOrderListExpression(Expression<Func<TraModOrderEntity, bool>> predicate);
        /// <summary>
        /// 根据条件获取改签订单信息
        /// </summary>
        /// <param name="predicate"></param>
        /// <returns></returns>
        TraModOrderEntity GetTraOrderExpression(Expression<Func<TraModOrderEntity, bool>> predicate);
        /// <summary>
        /// 火车改签订单分页列表
        /// </summary>
        /// <param name="query"></param>
        /// <param name="totalCount"></param>
        /// <returns></returns>
        List<TraModOrderListDataEntity> GetTraModOrderByPageList(TraModOrderListQueryEntity query, ref int totalCount);
        /// <summary>
        /// 根据正单号和票号，获取改签信息
        /// </summary>
        /// <param name="orderId"></param>
        /// <param name="ticketNoList"></param>
        /// <returns></returns>
        TraModOrderEntity GetTraModOrderByOrderIdAndTicketNo(int orderId, List<string> ticketNoList);
        /// <summary>
        /// 根据正单号和票号，获取改签信息
        /// </summary>
        /// <param name="orderId"></param>
        /// <param name="ticketNoList"></param>
        /// <returns></returns>
        List<TraModOrderEntity> GetTraModOrderListByOrderIdAndTicketNo(int orderId, List<string> ticketNoList);
    }
}
