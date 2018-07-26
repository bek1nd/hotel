using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mzl.IBLL.Token.Token
{
    public interface ITokenBLLFactory<out T> where T : class
    {
        T CreateBllObj();
        T CreateSampleBllObj();
    }
}
