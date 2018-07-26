using Mzl.DomainModel.Train.Order;
using Mzl.IBLL.Train.Order.BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mzl.Common.Factory;

namespace Mzl.IBLL.Train.Order.Factory
{
    public interface ITraOrderLogBLLFactory : IBaseBLLFactory<ITraOrderLogBLL<TraOrderLogModel>>
    {
    }
}
