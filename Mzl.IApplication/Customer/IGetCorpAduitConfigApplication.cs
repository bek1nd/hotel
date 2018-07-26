using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mzl.Framework.Base;
using Mzl.UIModel.Customer.CorpAduit;

namespace Mzl.IApplication.Customer
{
    public interface IGetCorpAduitConfigApplication : IBaseApplication
    {
        /// <summary>
        /// 获取公司审批规则信息
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        GetCorpAduitConfigListResponseViewModel GetCorpAduitConfigList(
            GetCorpAduitConfigListRequestViewModel request);
        /// <summary>
        /// 根据id获取审批规则信息
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        GetCorpAduitConfigResponseViewModel GetCorpAduitConfigById(GetCorpAduitConfigRequestViewModel request);
    }
}
