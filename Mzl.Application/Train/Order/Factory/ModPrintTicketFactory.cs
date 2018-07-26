using Mzl.Application.Train.Order.Domain;
using Mzl.BLL.Train.Server.Factory;
using Mzl.DomainModel.Train.Server;
using Mzl.IApplication.Train.Order.Domain;
using Mzl.IApplication.Train.Order.Factory;
using Mzl.IBLL.Train.Server.BLL;
using Mzl.IBLL.Train.Server.Factory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mzl.BLL.Train.Order.Factory;
using Mzl.DomainModel.Train.Order;
using Mzl.IBLL.Train.Order.BLL;
using Mzl.IBLL.Train.Order.Factory;

namespace Mzl.Application.Train.Order.Factory
{
   public class ModPrintTicketFactory : IServerDomainFactory
    {


        public IServerDomain CreateDomainObj()
        {
            //业务(占位)单元工厂，创建业务单元，通过构造注入到Domain中
            IModPrintTicketServerBLLFactory factory = new ModPrintTicketServerBLLFactory();
            IModPrintTicketServerBLL<TraModPrintTicketCallBackLogModel> modPrintTicketServer = factory.CreateBllObj();

            ITraInterFaceOrderServerBLLFactory traInterFaceOrderServerBllFactory = new TraInterFaceOrderServerBLLFactory();
            ITraInterFaceOrderServerBLL<TraInterFaceOrderModel> interFaceOrderServerBll =
                traInterFaceOrderServerBllFactory.CreateBllObj();

            ITraOrderOperateServerBLLFactory traOrderOperateServerBllFactory = new TraOrderOperateServerBLLFactory();
            ITraOrderOperateServerBLL<TraOrderOperateModel> orderOperateServerBll =
                traOrderOperateServerBllFactory.CreateBllObj();

            ITraOrderBLLFactory orderBllFactory = new TraOrderBLLFactory();
            ITraOrderBLL<TraOrderModel> orderBll = orderBllFactory.CreateBllObj();

            IServerDomain domain = new ServerDomain(modPrintTicketServer, interFaceOrderServerBll, orderOperateServerBll, orderBll);
            return domain;
        }
    }
}
