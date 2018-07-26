using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mzl.DomainModel.Token;
using Mzl.IBLL.Token.Token;

namespace Mzl.BLL.Token.Token
{
    public class TokenBLLFactory : ITokenBLLFactory<ITokenBLL<TokenModel>>
    {
        public ITokenBLL<TokenModel> CreateBllObj()
        {
            throw new NotImplementedException();
        }

        public ITokenBLL<TokenModel> CreateSampleBllObj()
        {
            return new TokenBLL();
        }
    }
}
