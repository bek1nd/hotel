using System;
using Mzl.DAL.Train.Server.DAL;
using Mzl.IDAL.Train.Server.DAL;
using Mzl.IDAL.Train.Server.Factory;

namespace Mzl.DAL.Train.Server.Factory
{
    public class HoldSeatServerDALFactory : IHoldSeatServerDALFactory
    {
        public IHoldSeatServerDAL CreateSampleDalObj()
        {
            return new HoldSeatServerDAL();
        }

    }
}
