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
using Mzl.Common.Factory;

namespace Mzl.BLL.Train.Order.Factory
{
    public class TraOrderBLLFactory : ITraOrderBLLFactory, ITraOrderListBLLFactory
    {
        public ITraOrderBLL<TraOrderModel> CreateBllObj()
        {
            ITraOrderDALFactory dal = new TraOrderDALFactory();
            return new TraOrderBLL(dal.CreateSampleDalObj());
        }

        ITraOrderListBLL<TraOrderListDataModel> IBaseBLLFactory<ITraOrderListBLL<TraOrderListDataModel>>.CreateSampleBllObj()
        {
            throw new NotImplementedException();
        }

        ITraOrderListBLL<TraOrderListDataModel> IBaseBLLFactory<ITraOrderListBLL<TraOrderListDataModel>>.CreateBllObj()
        {
            ITraOrderListDALFactory dal = new TraOrderListDALFactory();
            return new TraOrderBLL(dal.CreateSampleDalObj());
        }

        public ITraOrderBLL<TraOrderModel> CreateSampleBllObj()
        {
            throw new NotImplementedException();
        }
    }
}
