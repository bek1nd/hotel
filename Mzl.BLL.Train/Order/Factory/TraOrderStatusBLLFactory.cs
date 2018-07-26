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

namespace Mzl.BLL.Train.Order.Factory
{
    public class TraOrderStatusBLLFactory : ITraOrderStatusBLLFactory
    {
        public ITraOrderStatusBLL<TraOrderStatusModel> CreateBllObj()
        {
            ITraOrderStatusDALFactory factory = new TraOrderStatusDALFactory();
            return new TraOrderStatusBLL(factory.CreateSampleDalObj());
        }

        public ITraOrderStatusBLL<TraOrderStatusModel> CreateSampleBllObj()
        {
            throw new NotImplementedException();
        }
    }
}
