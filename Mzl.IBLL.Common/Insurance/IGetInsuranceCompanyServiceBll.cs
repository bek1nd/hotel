using Mzl.DomainModel.Common.Insurance;
using Mzl.Framework.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mzl.IBLL.Common.Insurance
{
    public interface IGetInsuranceCompanyServiceBll : IBaseServiceBll
    {
        /// <summary>
        /// 获取所有保险项目信息
        /// </summary>
        /// <returns></returns>
        List<InsuranceCompanyModel> GetInsuranceCompany();
        /// <summary>
        /// 获取线上保险项目信息
        /// </summary>
        /// <returns></returns>
        List<InsuranceCompanyModel> GetOnlineInsuranceCompany();
    }
}
