using Mzl.IApplication.Token.Factory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mzl.IApplication.Token.Domain;
using Mzl.Application.Token.Domain;
using Mzl.IBLL.Token.Token;
using Mzl.DomainModel.Token;
using Mzl.BLL.Token.Token;

namespace Mzl.Application.Token.Factory
{
    public class TokenDomainFactory : ITokenDomainFactory
    {
        public ITokenDomain CreateDomainObj()
        {
            ITokenBLLFactory<ITokenBLL<TokenModel>> factory = new TokenBLLFactory();
            ITokenBLL<TokenModel> tokenBll = factory.CreateSampleBllObj();
            ITokenDomain domain = new TokenDomain(tokenBll);
            return domain;
        }
    }
}
