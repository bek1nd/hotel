using Mzl.IBLL.Train.Server.Factory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mzl.DomainModel.Train.Server;
using Mzl.IBLL.Train.Server.BLL;
using Mzl.BLL.Train.Server.BLL;
using Mzl.DAL.Train.Server.Factory;
using Mzl.IDAL.Train.Server.Factory;

namespace Mzl.BLL.Train.Server.Factory
{
    public class ModHoldSeatServerBLLFactory : IModHoldSeatServerBLLFactory
    {
        public IModHoldSeatServerBLL<TraModHoldSeatCallBackLogModel> CreateBllObj()
        {
            IModHoldSeatServerDALFactory factory = new ModHoldSeatServerDALFactory();
            return new ModHoldSeatServerBLL(factory);
        }

        public IModHoldSeatServerBLL<TraModHoldSeatCallBackLogModel> CreateSampleBllObj()
        {
            return new ModHoldSeatServerBLL();
        }
    }
}
