using Mzl.BLL.Train.Server.BLL;
using Mzl.DAL.Train.Server;
using Mzl.DAL.Train.Server.Factory;
using Mzl.DomainModel.Train.Server;
using Mzl.IBLL.Train.Server;
using Mzl.IBLL.Train.Server.BLL;
using Mzl.IBLL.Train.Server.Factory;
using Mzl.IDAL.Train.Server;
using Mzl.IDAL.Train.Server.Factory;

namespace Mzl.BLL.Train.Server.Factory
{
    public class HoldSeatServerBLLFactory : IHoldSeatServerBLLFactory
    {
        public IHoldSeatServerBLL<TraHoldSeatCallBackLogModel> CreateBllObj()
        {
            IHoldSeatServerDALFactory factory = new HoldSeatServerDALFactory();
            return new HoldSeatServerBLL(factory);
        }

        public IHoldSeatServerBLL<TraHoldSeatCallBackLogModel> CreateSampleBllObj()
        {
            return new HoldSeatServerBLL();
        }
    }
}
