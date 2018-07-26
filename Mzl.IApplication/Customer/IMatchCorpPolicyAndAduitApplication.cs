using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mzl.Framework.Base;
using Mzl.UIModel.Customer.MatchCorpPolicyAndAduit;

namespace Mzl.IApplication.Customer
{
    public interface IMatchCorpPolicyAndAduitApplication : IBaseApplication
    {
        MatchCorpPolicyAndAduitResponseViewModel Match(MatchCorpPolicyAndAduitRequestViewModel request);
    }
}
