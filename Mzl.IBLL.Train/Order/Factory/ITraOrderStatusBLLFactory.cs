using Mzl.Common.Factory;
using Mzl.DomainModel.Train.Order;
using Mzl.IBLL.Train.Order.BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mzl.IBLL.Train.Order.Factory
{
    public interface ITraOrderStatusBLLFactory : IBaseBLLFactory<ITraOrderStatusBLL<TraOrderStatusModel>>
    {
    }
}
