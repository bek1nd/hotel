using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mzl.IBLL.Token;

namespace Mzl.BLL.Token
{
    public class DeleteTokenServiceBll: IDeleteTokenServiceBll
    {
        private readonly ITokenBll _tokenBll;
        public DeleteTokenServiceBll(ITokenBll tokenBll)
        {
            _tokenBll = tokenBll;
        }

        public void DeleteToken(string token)
        {
            _tokenBll.DeleteToken(token);
        }
    }
}
