using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mzl.DomainModel.Train.Order;
using Mzl.IBLL.Train.Order.BLL;
using Mzl.IBLL.Train.Order.Factory;
using Mzl.IDAL.Train.Order.Factory;
using Mzl.DAL.Train.Order.Factory;
using Mzl.BLL.Train.Order.BLL;

namespace Mzl.BLL.Train.Order.Factory
{
    public class TraOrderLogBLLFactory : ITraOrderLogBLLFactory
    {
        public ITraOrderLogBLL<TraOrderLogModel> CreateBllObj()
        {
            ITraOrderLogDALFactory traOrderLogDalFactory = new TraOrderLogDALFactory();
            return new TraOrderLogBLL(traOrderLogDalFactory.CreateSampleDalObj());
        }

        public ITraOrderLogBLL<TraOrderLogModel> CreateSampleBllObj()
        {
            throw new NotImplementedException();
        }
    }
}
