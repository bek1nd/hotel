using Mzl.DomainModel.Events;
using Mzl.DomainModel.Token;
using System.Net.Http;

namespace Mzl.IApplication.Token.Domain
{
    public interface ITokenDomain
    {
        /// <summary>
        /// 检查Token
        /// </summary>
        /// <returns></returns>
        TokenResultModel CheckToken(HttpRequestMessage request);
        /// <summary>
        /// 更新登录用户的Token，并将Token状态设置为1
        /// </summary>
        /// <param name="o"></param>
        /// <param name="e"></param>
        void UpdateUserToken(object o, TokenEventArgs e);
        /// <summary>
        /// 删除Token
        /// </summary>
        /// <param name="key"></param>
        void DeleteToken(string key);
    }
}
