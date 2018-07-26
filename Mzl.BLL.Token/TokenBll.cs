using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mzl.DomainModel.Token;
using Mzl.IBLL.Token;
using Newtonsoft.Json;
using Mzl.Redis.Token;

namespace Mzl.BLL.Token
{
    public class TokenBll : ITokenBll
    {
        /// <summary>
        /// 生成Token，并保存在Redis中
        /// </summary>
        /// <returns></returns>
        public string SetToken(TokenModel token)
        {
            var key = Guid.NewGuid().ToString().Replace("-", "");
            token.Token = key;
            //保存在Redis中，默认有效期为半小时
            Set(token, TimeSpan.FromHours(0.5));
            return key;
        }

        /// <summary>
        ///  更新token
        /// </summary>
        public void UpdateToken(TokenModel token)
        {
            Set(token, TimeSpan.FromHours(24));
        }

        /// <summary>
        /// 获取token
        /// </summary>
        /// <param name="token"></param>
        /// <returns></returns>
        public TokenModel GetToken(string token)
        {
            return Get(token);
        }

        /// <summary>
        /// 更新Token有效期
        /// </summary>
        /// <param name="token"></param>
        /// <param name="hours"></param>
        /// <returns></returns>
        public bool ExpireToken(string token, int hours)
        {
            Expire(token, hours);
            return true;
        }

        /// <summary>
        /// 删除Token
        /// </summary>
        /// <param name="key"></param>
        public void DeleteToken(string key)
        {
            Delete(key);
        }

        #region 私有方法

        private void Set(TokenModel t, TimeSpan validFor)
        {
            string value = JsonConvert.SerializeObject(t.Value);
            TokenRedisFactory.Set(t.Token, value, validFor);
        }

        private void Expire(string token, int hours)
        {
            TokenRedisFactory.Expire(token, hours);
        }

        private void Delete(string token)
        {
            TokenRedisFactory.Delete(token);
        }

        private TokenModel Get(string token)
        {
            string valueStr = TokenRedisFactory.Get(token);
            if (string.IsNullOrEmpty(valueStr))
                return null;
            TokenValueModel valueModel = JsonConvert.DeserializeObject<TokenValueModel>(valueStr);
            return new TokenModel() {Token = token, Value = valueModel};
        }

        #endregion
    }
}
