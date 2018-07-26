using Mzl.DomainModel.Customer.CostCenter;
using Mzl.DomainModel.Customer.ProjectName;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mzl.DomainModel.Customer.Corp;

namespace Mzl.IApplication.Customer.Domain
{
    public interface ICorporationDomain
    {
        /// <summary>
        /// 获取公司下所属的成本中心信息集合
        /// </summary>
        /// <param name="corpId"></param>
        /// <returns></returns>
        List<CostCenterModel> GetCostCenter(string corpId);
        /// <summary>
        /// 获取公司下所属的项目名称信息集合
        /// </summary>
        /// <param name="corpId"></param>
        /// <returns></returns>
        List<ProjectNameModel> GetProjectName(string corpId);

        /// <summary>
        /// 获取公司的服务费信息
        /// </summary>
        /// <param name="cid"></param>
        /// <param name="type">类型</param>
        /// <returns></returns>
        decimal GetServiceFeeByCorpId(int cid, string type);

        /// <summary>
        /// 根据公司Id获取公司信息
        /// </summary>
        /// <param name="corpid"></param>
        /// <returns></returns>
        CorporationModel GetCorporationByCorId(string corpid);
    }
}
