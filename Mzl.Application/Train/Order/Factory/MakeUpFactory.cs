using Mzl.IApplication.Train.Order.Factory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mzl.BLL.Train.Server.Factory;
using Mzl.DomainModel.Train.Server;
using Mzl.IApplication.Train.Order.Domain;
using Mzl.IBLL.Train.Server.BLL;
using Mzl.IBLL.Train.Server.Factory;
using Mzl.Application.Train.Order.Domain;
using Mzl.BLL.Train.Order.Factory;
using Mzl.DomainModel.Train.Order;
using Mzl.IBLL.Train.Order.BLL;
using Mzl.IBLL.Train.Order.Factory;

namespace Mzl.Application.Train.Order.Factory
{
    public class MakeUpFactory : IServerDomainFactory
    {
        public virtual IServerDomain CreateDomainObj()
        {
            ITraInterFaceOrderServerBLLFactory traInterFaceOrderServerBllFactory = new TraInterFaceOrderServerBLLFactory();
            ITraInterFaceOrderServerBLL<TraInterFaceOrderModel> interFaceOrderServerBll =
                traInterFaceOrderServerBllFactory.CreateBllObj();
            ITraOrderOperateServerBLLFactory traOrderOperateServerBllFactory = new TraOrderOperateServerBLLFactory();
            ITraOrderOperateServerBLL<TraOrderOperateModel> orderOperate = traOrderOperateServerBllFactory.CreateBllObj();

            ITraModOrderBLLFactory traModOrderBllFactory = new TraModOrderBLLFactory();
            ITraModOrderBLL<TraModOrderModel> traModOrderBll = traModOrderBllFactory.CreateBllObj();
            ITraOrderBLLFactory orderBllFactory = new TraOrderBLLFactory();
            ITraOrderBLL<TraOrderModel> orderBll = orderBllFactory.CreateBllObj();

            return new ServerDomain(interFaceOrderServerBll, orderOperate, traModOrderBll, orderBll);
        }
    }
}
