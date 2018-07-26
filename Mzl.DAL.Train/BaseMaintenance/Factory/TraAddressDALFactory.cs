using Mzl.DAL.Train.BaseMaintenance.DAL;
using Mzl.IDAL.Train.BaseMaintenance.DAL;
using Mzl.IDAL.Train.BaseMaintenance.Factory;

namespace Mzl.DAL.Train.BaseMaintenance.Factory
{
    public class TraAddressDALFactory: ITraAddressDALFactory
    {
        public ITraAddressDAL CreateSampleDalObj()
        {
            return new TraAddressDAL();
        }
    }
}
