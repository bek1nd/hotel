using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mzl.Framework.Base;
using Mzl.UIModel.Customer.CorpAduit;

namespace Mzl.IApplication.Customer
{
    /// <summary>
    /// 对审批单进行审批
    /// </summary>
    public interface IDoAduitOrderApplication : IBaseApplication
    {
        /// <summary>
        /// 对审批单进行审批
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        DoAduitOrderResponseViewModel DoAduitOrder(DoAduitOrderRequestViewModel request);
    }
}
