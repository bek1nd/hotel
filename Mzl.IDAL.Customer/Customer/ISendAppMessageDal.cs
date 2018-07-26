using System.Collections.Generic;
using Mzl.Framework.Base;

namespace Mzl.IDAL.Customer.Customer
{
    public interface ISendAppMessageDal : IBaseDal
    {
        List<T> GetAuditUrgeMessage<T>() where T : class;
    }
}
