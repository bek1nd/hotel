using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mzl.DomainModel.Common.AuditOrder;
using Mzl.Framework.Base;

namespace Mzl.IBLL.Customer.CorpAduit
{
    public interface IGetCorpAduitOrderListServiceBll : IBaseServiceBll
    {

        /// <summary>
        /// 获取待审批单信息
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        AuditOrderListModel GetWaitCorpAduitOrderList(AuditOrderListQueryModel query);

        /// <summary>
        /// 获取已通过的审批信息
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        AuditOrderListModel GetPassCorpAduitOrderList(AuditOrderListQueryModel query);

        /// <summary>
        /// 获取已拒绝的审批信息
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        AuditOrderListModel GetNoPassCorpAduitOrderList(AuditOrderListQueryModel query);
    }
}
