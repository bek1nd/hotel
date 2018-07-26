using Mzl.DomainModel.Customer.ProjectName;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mzl.Framework.Base;

namespace Mzl.IBLL.Customer.ProjectName
{
    public interface IGetProjectNameServiceBll : IBaseServiceBll
    {
        /// <summary>
        /// 获取公司对应的项目名称
        /// </summary>
        /// <param name="corpId"></param>
        /// <returns></returns>
        List<ProjectNameModel> GetProjectName(string corpId);
        List<ProjectNameModel> GetProjectNameByNotDelete(string corpId);
        List<ProjectNameModel> GetProjectName(int cid);
        List<ProjectNameModel> GetProjectNameByNotDelete(int cid);
        /// <summary>
        /// 根据政策或者审批规则获取项目成本中心信息
        /// </summary>
        /// <param name="corpId"></param>
        /// <param name="policyId"></param>
        /// <param name="aduitId"></param>
        /// <returns></returns>
        List<ProjectNameModel> GetCorpPolicyProjectByCorpId(string corpId, int? policyId, int? aduitId);
    }
}
