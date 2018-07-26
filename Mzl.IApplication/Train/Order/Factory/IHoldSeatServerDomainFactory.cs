using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mzl.IApplication.Train.Order.Domain;

namespace Mzl.IApplication.Train.Order.Factory
{
    public interface IHoldSeatServerDomainFactory : IServerDomainFactory
    {
        IServerDomain CreateQueryTraInterFaceOrderStatusObj();
    }
}
