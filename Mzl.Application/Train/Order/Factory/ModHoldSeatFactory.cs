using Mzl.IApplication.Train.Order.Factory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mzl.IApplication.Train.Order.Domain;
using Mzl.DomainModel.Train.Server;
using Mzl.IBLL.Train.Server.BLL;
using Mzl.IBLL.Train.Server.Factory;
using Mzl.Application.Train.Order.Domain;
using Mzl.BLL.Train.Server.Factory;
using Mzl.IBLL.Train.Order.BLL;
using Mzl.DomainModel.Train.Order;
using Mzl.IBLL.Train.Order.Factory;
using Mzl.BLL.Train.Order.Factory;

namespace Mzl.Application.Train.Order.Factory
{
    public class ModHoldSeatFactory : IServerDomainFactory
    {
        public IServerDomain CreateDomainObj()
        {
            //业务(占位)单元工厂，创建业务单元，通过构造注入到Domain中
            IModHoldSeatServerBLLFactory factory = new ModHoldSeatServerBLLFactory();
            IModHoldSeatServerBLL<TraModHoldSeatCallBackLogModel> holdSeatServer = factory.CreateBllObj();

            ITraModOrderBLLFactory traModOrderBllFactory = new TraModOrderBLLFactory();
            ITraModOrderBLL<TraModOrderModel> traModOrderBll = traModOrderBllFactory.CreateBllObj();

            ITraInterFaceOrderServerBLLFactory traInterFaceOrderServerBllFactory=new TraInterFaceOrderServerBLLFactory();
            ITraInterFaceOrderServerBLL<TraInterFaceOrderModel> interFaceOrderServerBll =
                traInterFaceOrderServerBllFactory.CreateBllObj();

            ITraOrderOperateServerBLLFactory traOrderOperateServerBllFactory = new TraOrderOperateServerBLLFactory();
            ITraOrderOperateServerBLL<TraOrderOperateModel> orderOperateServerBll =
                traOrderOperateServerBllFactory.CreateBllObj();

            IRequestCancelServerBLLFactory requestCancelServerBllFactory = new RequestCancelServerBLLFactory();
            IRequestCancelServerBLL<TraRequestCancelResponseModel> requestCancelServer =
                requestCancelServerBllFactory.CreateSampleBllObj();

            IServerDomain domain = new ServerDomain(holdSeatServer, traModOrderBll, interFaceOrderServerBll,
                orderOperateServerBll, requestCancelServer);
            return domain;
        }
    }
}
