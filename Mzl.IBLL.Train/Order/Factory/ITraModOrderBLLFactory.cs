using Mzl.Common.Factory;
using Mzl.DomainModel.Train.Order;
using Mzl.IBLL.Train.Order.BLL;

namespace Mzl.IBLL.Train.Order.Factory
{
    public interface ITraModOrderBLLFactory : IBaseBLLFactory<ITraModOrderBLL<TraModOrderModel>>
    {
    }
}
