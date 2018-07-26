using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mzl.DomainModel.Customer.CorpAduit;
using Mzl.Framework.Base;

namespace Mzl.IBLL.Customer.CorpAduit
{
    public interface IGetCorpAduitOrderServiceBll : IBaseServiceBll
    {
        /// <summary>
        /// 根据审批单号获取审批详情信息
        /// </summary>
        /// <param name="aduitOrderId"></param>
        /// <returns></returns>
        CorpAduitOrderInfoModel GetAduitOrderInfoById(int aduitOrderId);
        /// <summary>
        /// 根据订单号获取审批详情集合
        /// </summary>
        /// <param name="orderId"></param>
        /// <returns></returns>
        List<CorpAduitOrderInfoModel> GetAduitOrderInfoByOrderId(int orderId);
        /// <summary>
        /// 批量根据订单号获取审批详情集合
        /// </summary>
        /// <param name="orderIdList"></param>
        /// <returns></returns>
        List<CorpAduitOrderInfoModel> GetAduitOrderInfoByOrderIds(List<int> orderIdList);
    }
}
