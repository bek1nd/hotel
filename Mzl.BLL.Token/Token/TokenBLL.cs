using Mzl.DomainModel.Token;
using Mzl.IBLL.Token.Token;
using Mzl.Redis.Token;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mzl.BLL.Token.Token
{
    public class TokenBLL : ITokenBLL<TokenModel>
    {
        public void Expire(string token, int hours)
        {
            TokenRedisFactory.Expire(token, hours);
        }

        public void Delete(string token)
        {
            TokenRedisFactory.Delete(token);
        }

        public TokenModel Get(string token)
        {
            string valueStr = TokenRedisFactory.Get(token);
            if (string.IsNullOrEmpty(valueStr))
                return null;
            TokenValueModel valueModel = JsonConvert.DeserializeObject<TokenValueModel>(valueStr);
            return new TokenModel() {Token = token, Value = valueModel};
        }

        public void Set(TokenModel t, TimeSpan validFor)
        {
            string value = JsonConvert.SerializeObject(t.Value);
            TokenRedisFactory.Set(t.Token, value, validFor);
        }

      
    }
}
