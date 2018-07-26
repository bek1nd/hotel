using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mzl.Framework.Base;

namespace Mzl.IBLL.Token
{
    public interface IDeleteTokenServiceBll: IBaseServiceBll
    {
        void DeleteToken(string token);
    }
}
