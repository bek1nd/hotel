using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mzl.DomainModel.Customer.Base;
using Mzl.Framework.Base;

namespace Mzl.IBLL.Common.CheckAccount
{
    public interface ICheckCorpAccountPowerServiceBll : IBaseServiceBll
    {
        bool CheckAccountPower(CustomerModel customer, string url);
    }
}
