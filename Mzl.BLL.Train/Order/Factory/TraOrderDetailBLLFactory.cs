using Mzl.IBLL.Train.Order.Factory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mzl.DomainModel.Train.Order;
using Mzl.IBLL.Train.Order.BLL;
using Mzl.IDAL.Train.Order.Factory;
using Mzl.DAL.Train.Order.Factory;
using Mzl.BLL.Train.Order.BLL;
using Mzl.DAL.Train.BaseMaintenance.Factory;
using Mzl.IDAL.Train.BaseMaintenance.Factory;

namespace Mzl.BLL.Train.Order.Factory
{
    public class TraOrderDetailBLLFactory : ITraOrderDetailBLLFactory
    {
        public ITraOrderDetailBLL<TraOrderDetailModel> CreateBllObj()
        {
            ITraOrderDetailDALFactory factory = new TraOrderDetailDALFactory();
            ITraAddressDALFactory traAddressDalFactory = new TraAddressDALFactory();
            return new TraOrderDetailBLL(factory.CreateSampleDalObj(), traAddressDalFactory.CreateSampleDalObj());
        }

        public ITraOrderDetailBLL<TraOrderDetailModel> CreateSampleBllObj()
        {
            throw new NotImplementedException();
        }
    }
}
