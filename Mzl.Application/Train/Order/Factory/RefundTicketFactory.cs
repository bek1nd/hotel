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
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mzl.Application.Train.Order.Factory
{
  public  class RefundTicketFactory : IServerDomainFactory
    {
        public IServerDomain CreateDomainObj()
        {
            //业务(占位)单元工厂，创建业务单元，通过构造注入到Domain中
            IRefundTicketServerBLLFactory factory = new RefundTicketServerBLLFactory();
            IRefundTicketServerBLL<TraRefundTicketCallBackLogModel> holdSeatServer = factory.CreateBllObj();


            ITraInterFaceOrderServerBLLFactory factory2 = new TraInterFaceOrderServerBLLFactory();
            ITraInterFaceOrderServerBLL<TraInterFaceOrderModel> interFaceOrderServerBll = factory2.CreateBllObj();
            ITraOrderOperateServerBLLFactory factory3 = new TraOrderOperateServerBLLFactory();
            ITraOrderOperateServerBLL<TraOrderOperateModel> orderOperateServerBll = factory3.CreateBllObj();

            ITraOrderBLLFactory traOrderBllFactory = new TraOrderBLLFactory();
            ITraOrderBLL<TraOrderModel> orderBll = traOrderBllFactory.CreateBllObj();

            IServerDomain domain = new ServerDomain(holdSeatServer, interFaceOrderServerBll, orderOperateServerBll,
                orderBll);
            return domain;
        }
    }
}
