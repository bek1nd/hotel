using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mzl.DomainModel.Enum;
using Mzl.DomainModel.Token;
using Mzl.IBLL.Token;
using Mzl.DomainModel.Customer.Base;

namespace Mzl.BLL.Token
{
    public class UpdateUserTokenServiceBll : IUpdateUserTokenServiceBll
    {
        private readonly ITokenBll _tokenBll;

        public UpdateUserTokenServiceBll(ITokenBll tokenBll)
        {
            _tokenBll = tokenBll;
        }

        public void UpdateUserToken(string token, CustomerInfoModel customerInfo)
        {
            TokenModel tt = new TokenModel
            {
                Token = token,
                Value = new TokenValueModel
                {
                    UserId = customerInfo.UserId,
                    Status = TokenResultEnum.Allow,
                    Cid = customerInfo.Cid
                }
            };
            _tokenBll.UpdateToken(tt);
        }
    }
}
