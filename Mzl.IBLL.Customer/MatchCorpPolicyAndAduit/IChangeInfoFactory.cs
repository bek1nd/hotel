using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mzl.DomainModel.Customer.CorpDepartment;
using Mzl.DomainModel.Customer.CorpPolicy;
using Mzl.DomainModel.Customer.MatchCorpPolicyAndAduit;

namespace Mzl.IBLL.Customer.MatchCorpPolicyAndAduit
{
    public interface IChangeInfoFactory
    {
        /// <summary>
        /// 获取客户id对应的差旅政策信息
        /// </summary>
        /// <param name="cid"></param>
        /// <param name="departId"></param>
        /// <param name="isAllowUserInsurance"></param>
        /// <returns></returns>
        List<CorpPolicyChangeModel> GetCorpPolicyChangeInfo(int cid, int departId, int isAllowUserInsurance);

        /// <summary>
        /// 根据项目成本中心对应的差旅政策信息
        /// </summary>
        /// <param name="projectId"></param>
        /// <param name="isAllowUserInsurance"></param>
        /// <returns></returns>
        List<CorpPolicyChangeModel> GetCorpPolicyChangeInfoByProjectId(int projectId, int isAllowUserInsurance);

        /// <summary>
        /// 获取客户id对应的审批规则信息
        /// </summary>
        /// <param name="cid"></param>
        /// <param name="departId"></param>
        /// <returns></returns>
        List<CorpAduitChangeModel> GetCorpAduitChangeInfo(int cid, int departId);
        /// <summary>
        /// 根据项目成本中心对应的审批规则信息
        /// </summary>
        /// <param name="projectId"></param>
        /// <returns></returns>
        List<CorpAduitChangeModel> GetCorpAduitChangeInfoByProjectId(int projectId);

        List<CorpDepartmentModel> GetCorpDepart(string corpId, List<int> removeDepartIdList);
    }
}
