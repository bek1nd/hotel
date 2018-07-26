using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mzl.Framework.Base;
using Mzl.UIModel.Customer.Customer;

namespace Mzl.IApplication.Customer
{
    public interface IAddAppOpinionApplication : IBaseApplication
    {
        /// <summary>
        /// 添加差旅网站app意见
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        bool AddMojoryOpinion(AppOpinionRequestViewModel request);
    }
}
