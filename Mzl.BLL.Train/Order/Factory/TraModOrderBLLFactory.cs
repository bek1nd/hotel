using Mzl.IBLL.Train.Order.Factory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mzl.DomainModel.Train.Order;
using Mzl.IBLL.Train.Order.BLL;
using Mzl.BLL.Train.Order.BLL;
using Mzl.Common.Factory;
using Mzl.IDAL.Train.Order.Factory;
using Mzl.DAL.Train.Order.Factory;
using Mzl.IDAL.Train.Server.Factory;
using Mzl.DAL.Train.Server.Factory;

namespace Mzl.BLL.Train.Order.Factory
{
    public class TraModOrderBLLFactory: ITraModOrderBLLFactory, ITraModOrderListBLLFactory
    {
        public ITraModOrderBLL<TraModOrderModel> CreateBllObj()
        {
            ITraModOrderDALFactory factory = new TraModOrderDALFactory();
            return new TraModOrderBLL(factory.CreateSampleDalObj());
        }

        ITraOrderListBLL<TraModOrderListDataModel> IBaseBLLFactory<ITraOrderListBLL<TraModOrderListDataModel>>.CreateSampleBllObj()
        {
            throw new NotImplementedException();
        }

        public ITraModOrderBLL<TraModOrderModel> GetModOrderListBllObj()
        {
            ITraModOrderDALFactory factory = new TraModOrderDALFactory();
            return new TraModOrderBLL(factory.CreateSampleDalObj());
        }

        ITraOrderListBLL<TraModOrderListDataModel> IBaseBLLFactory<ITraOrderListBLL<TraModOrderListDataModel>>.CreateBllObj()
        {
            ITraModOrderDALFactory factory = new TraModOrderDALFactory();
            return new TraModOrderBLL(factory.CreateSampleDalObj());
        }

        public ITraModOrderBLL<TraModOrderModel> CreateSampleBllObj()
        {
            throw new NotImplementedException();
        }
    }
}
