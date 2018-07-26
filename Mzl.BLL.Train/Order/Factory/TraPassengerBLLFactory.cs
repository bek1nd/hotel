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
    public class TraPassengerBLLFactory : ITraPassengerBLLFactory
    {
        public ITraPassengerBLL<TraPassengerModel> CreateBllObj()
        {
            ITraPassengerDALFactory dal = new TraPassengerDALFactory();
            return new TraPassengerBLL(dal.CreateSampleDalObj());
        }

        public ITraPassengerBLL<TraPassengerModel> CreateGetPassengerByOrderIdBllObj()
        {
            ITraPassengerDALFactory dal = new TraPassengerDALFactory();
            ITraOrderDetailDALFactory traOrderDetailDalFactory= new TraOrderDetailDALFactory();
            return new TraPassengerBLL(dal.CreateSampleDalObj(), traOrderDetailDalFactory.CreateSampleDalObj());
        }

        public ITraPassengerBLL<TraPassengerModel> CreateSampleBllObj()
        {
            throw new NotImplementedException();
        }
    }
}
