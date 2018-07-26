using Mzl.DomainModel.Token;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mzl.DomainModel.Customer.Base;
using Mzl.Framework.Base;

namespace Mzl.IBLL.Token
{
    /// <summary>
    /// 更新登录用户的Token
    /// </summary>
    public interface IUpdateUserTokenServiceBll : IBaseServiceBll
    {
        void UpdateUserToken(string token, CustomerInfoModel customerInfo);
    }
}
