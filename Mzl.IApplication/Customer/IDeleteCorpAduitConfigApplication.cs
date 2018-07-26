using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mzl.Framework.Base;
using Mzl.UIModel.Customer.CorpAduit;

namespace Mzl.IApplication.Customer
{
    public interface IDeleteCorpAduitConfigApplication : IBaseApplication
    {
        /// <summary>
        /// 删除差旅审批规则
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        DeleteCorpAduitConfigResponseViewModel DeleteCorpAduitConfig(DeleteCorpAduitConfigRequestViewModel request);
    }
}
