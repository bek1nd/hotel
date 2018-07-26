using Mzl.DomainModel.Token;
using Mzl.Framework.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Mzl.IBLL.Token
{
    /// <summary>
    /// 检查Token信息是否有效
    /// </summary>
    public interface ICheckTokenServiceBll : IBaseServiceBll
    {
        /// <summary>
        /// 检查Token信息
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        TokenResultModel CheckToken(HttpRequestMessage request);
    }
}
