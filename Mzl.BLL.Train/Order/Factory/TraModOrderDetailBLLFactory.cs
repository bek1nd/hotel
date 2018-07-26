using Mzl.IBLL.Train.Order.Factory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mzl.DomainModel.Train.Order;
using Mzl.IBLL.Train.Order.BLL;
using Mzl.BLL.Train.Order.BLL;
using Mzl.IDAL.Train.Order.Factory;
using Mzl.DAL.Train.Order.Factory;

namespace Mzl.BLL.Train.Order.Factory
{
    public class TraModOrderDetailBLLFactory : ITraModOrderDetailBLLFactory
    {
        public ITraModOrderDetailBLL<TraModOrderDetailModel> CreateBllObj()
        {
            ITraModOrderDetailDALFactory factory = new TraModOrderDetailDALFactory();
            return new TraModOrderDetailBLL(factory.CreateSampleDalObj());
        }

        public ITraModOrderDetailBLL<TraModOrderDetailModel> CreateSampleBllObj()
        {
            throw new NotImplementedException();
        }
    }
}
