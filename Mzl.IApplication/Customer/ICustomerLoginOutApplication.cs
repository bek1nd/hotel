using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mzl.Framework.Base;

namespace Mzl.IApplication.Customer
{
    public interface ICustomerLoginOutApplication: IBaseApplication
    {
        /// <summary>
        /// 注销用户登录
        /// </summary>
        /// <param name="token"></param>
        void MojoryLoginOut(string token);
    }
}
