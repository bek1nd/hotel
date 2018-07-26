using Mzl.Application.Train.Order.Domain;
using Mzl.BLL.Train.Order.Factory;
using Mzl.BLL.Train.Server.Factory;
using Mzl.DomainModel.Train.Order;
using Mzl.DomainModel.Train.Server;
using Mzl.IApplication.Train.Order.Domain;
using Mzl.IApplication.Train.Order.Factory;
using Mzl.IBLL.Train.Order.BLL;
using Mzl.IBLL.Train.Order.Factory;
using Mzl.IBLL.Train.Server.BLL;
using Mzl.IBLL.Train.Server.Factory;

namespace Mzl.Application.Train.Order.Factory
{
    /// <summary>
    /// 占位工厂
    /// </summary>
    public class HoldSeatFactory : IHoldSeatServerDomainFactory
    {
        public IServerDomain CreateDomainObj()
        {
            //业务(占位)单元工厂，创建业务单元，通过构造注入到Domain中
            IHoldSeatServerBLLFactory holdSeatServerBllFactory = new HoldSeatServerBLLFactory();
            IHoldSeatServerBLL<TraHoldSeatCallBackLogModel> holdSeatServer = holdSeatServerBllFactory.CreateBllObj();


            ITraInterFaceOrderServerBLLFactory traInterFaceOrderServerBllFactory = new TraInterFaceOrderServerBLLFactory();
            ITraInterFaceOrderServerBLL<TraInterFaceOrderModel> interFaceOrder = traInterFaceOrderServerBllFactory.CreateBllObj();


            ITraOrderOperateServerBLLFactory traOrderOperateServerBllFactory = new TraOrderOperateServerBLLFactory();
            ITraOrderOperateServerBLL<TraOrderOperateModel> orderOperate = traOrderOperateServerBllFactory.CreateBllObj();


            IServerDomain domain = new ServerDomain(holdSeatServer, interFaceOrder, orderOperate);

            return domain;
        }


        public IServerDomain CreateQueryTraInterFaceOrderStatusObj()
        {
            ITraInterFaceOrderServerBLLFactory traInterFaceOrderServerBllFactory = new TraInterFaceOrderServerBLLFactory();
            ITraInterFaceOrderServerBLL<TraInterFaceOrderModel> interFaceOrder = traInterFaceOrderServerBllFactory.CreateBllObj();
            IServerDomain domain = new ServerDomain(interFaceOrder);
            return domain;
        }


    }
}
