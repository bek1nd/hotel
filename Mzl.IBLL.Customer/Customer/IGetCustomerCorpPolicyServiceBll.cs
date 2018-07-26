using System;
using System.Collections.Generic;
using Mzl.DomainModel.Customer.CorpPolicy;
using Mzl.Framework.Base;

namespace Mzl.IBLL.Customer.Customer
{
    /// <summary>
    /// 查询差旅政策服务
    /// </summary>
    public interface IGetCustomerCorpPolicyServiceBll : IBaseServiceBll
    {
        /// <summary>
        /// 根据客户id，获取配置在他上的差旅政策信息
        /// </summary>
        /// <param name="cid"></param>
        [Obsolete("这个获取差旅政策的方法已经无效，请使用同类中的GetCorpPolicyById方法代替")]
        CorpPolicyDetailConfigModel GetCorpPolicy(int cid);

        /// <summary>
        /// 根据政策Id获取差旅政策信息
        /// </summary>
        /// <param name="policyId"></param>
        /// <param name="corpId"></param>
        /// <param name="policyType"></param>
        /// <returns></returns>
        CorpPolicyDetailConfigModel GetCorpPolicyById(int policyId, string corpId, string policyType);

        List<ChoiceReasonModel> GetCorpReasonByCorpId(string corpId);

    }
}
