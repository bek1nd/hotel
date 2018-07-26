using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mzl.DomainModel.Token;

namespace Mzl.IBLL.Token
{
    public interface ITokenBll
    {
        /// <summary>
        /// 生成Token，并保存在Redis中
        /// </summary>
        /// <returns></returns>
        string SetToken(TokenModel token);
        /// <summary>
        /// 更新token
        /// </summary>
        /// <param name="token"></param>
        void UpdateToken(TokenModel token);
        /// <summary>
        /// 获取Token
        /// </summary>
        /// <returns></returns>
        TokenModel GetToken(string token);
        /// <summary>
        /// 更新Token有效期
        /// </summary>
        /// <param name="token"></param>
        /// <param name="hours"></param>
        /// <returns></returns>
        bool ExpireToken(string token, int hours);
        /// <summary>
        /// 删除Token
        /// </summary>
        /// <param name="key"></param>
        void DeleteToken(string key);
    }
}
