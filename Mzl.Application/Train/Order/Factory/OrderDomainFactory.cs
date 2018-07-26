using Mzl.IApplication.Train.Order.Factory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mzl.Application.Train.Order.Domain;
using Mzl.IApplication.Train.Order.Domain;
using Mzl.IBLL.Train.Order.Factory;
using Mzl.BLL.Train.Order.Factory;
using Mzl.IBLL.Train.Order.BLL;
using Mzl.DomainModel.Train.Order;
using Mzl.IApplication.Customer.Factory;
using Mzl.Application.Customer.Factory;
using Mzl.BLL.Customer.Corp.Factory;
using Mzl.IBLL.Customer.Customer.Factory;
using Mzl.DomainModel.Customer.Base;
using Mzl.IBLL.Customer.Customer.BLL;
using Mzl.BLL.Customer.Customer.Factory;
using Mzl.IBLL.Customer.ProjectName.BLL;
using Mzl.DomainModel.Customer.ProjectName;
using Mzl.IBLL.Customer.ProjectName.Factory;
using Mzl.BLL.Customer.ProjectName.Factory;
using Mzl.BLL.Train.BaseMaintenance.Factory;
using Mzl.IBLL.Train.Server.BLL;
using Mzl.DomainModel.Train.Server;
using Mzl.IBLL.Train.Server.Factory;
using Mzl.BLL.Train.Server.Factory;
using Mzl.DomainModel.Customer.Corp;
using Mzl.DomainModel.Train.BaseMaintenance;
using Mzl.IBLL.Customer.Corp.BLL;
using Mzl.IBLL.Customer.Corp.Factory;
using Mzl.IBLL.Customer.Customer;
using Mzl.IBLL.Train.BaseMaintenance.Bll;
using Mzl.IBLL.Train.BaseMaintenance.Factory;
using Mzl.IBLL.Customer.CorpAduit;
using Mzl.BLL.Customer.CorpAduit;

namespace Mzl.Application.Train.Order.Factory
{
    public class OrderDomainFactory : IOrderDomainFactory
    {
        public IOrderDomain CreateDomainObj()
        {
            return new OrderDomain();
        }

        public IOrderDomain CreateAddOrderDomainObj()
        {
            ITraOrderBLLFactory orderBllFactory = new TraOrderBLLFactory();
            ITraOrderBLL<TraOrderModel> orderBll = orderBllFactory.CreateBllObj();
            ITraOrderStatusBLLFactory orderStatusBllFactory=new TraOrderStatusBLLFactory();
            ITraOrderStatusBLL<TraOrderStatusModel> orderStatusBll = orderStatusBllFactory.CreateBllObj();
            ITraOrderDetailBLLFactory orderDetailBllFactory=new TraOrderDetailBLLFactory();
            ITraOrderDetailBLL<TraOrderDetailModel> orderDetailBll = orderDetailBllFactory.CreateBllObj();
            ITraPassengerBLLFactory passengerBllFactory=new TraPassengerBLLFactory();
            ITraPassengerBLL<TraPassengerModel> passengerBll = passengerBllFactory.CreateBllObj();
            ITraOrderLogBLLFactory traOrderLogBllFactory = new TraOrderLogBLLFactory();
            ITraOrderLogBLL<TraOrderLogModel> traOrderLogBll = traOrderLogBllFactory.CreateBllObj();
            ICustomerBLLFactory factory = new CustomerBLLFactory();
            ICustomerBLL<CustomerInfoModel> customerBll = factory.CreateBllObj();

            ICorporationBLLFactory corporationBllFactory = new CorporationBLLFactory();
            ICorporationBLL<CorporationModel> corporationBll = corporationBllFactory.CreateBllObj();

            return new OrderDomain(orderBll, orderStatusBll, orderDetailBll, passengerBll, traOrderLogBll, customerBll, corporationBll);
        }

        public IOrderDomain CreateOrderListDomainObj()
        {
            ITraOrderListBLLFactory orderListBllFactory = new TraOrderBLLFactory();
            ITraOrderListBLL<TraOrderListDataModel> orderListBll = orderListBllFactory.CreateBllObj();
            ITraOrderStatusBLLFactory orderStatusBllFactory = new TraOrderStatusBLLFactory();
            ITraOrderStatusBLL<TraOrderStatusModel> orderStatusBll = orderStatusBllFactory.CreateBllObj();
            ITraOrderDetailBLLFactory orderDetailBllFactory = new TraOrderDetailBLLFactory();
            ITraOrderDetailBLL<TraOrderDetailModel> orderDetailBll = orderDetailBllFactory.CreateBllObj();
            ITraPassengerBLLFactory passengerBllFactory = new TraPassengerBLLFactory();
            ITraPassengerBLL<TraPassengerModel> passengerBll = passengerBllFactory.CreateBllObj();
            IProjectNameBLLFactory projectNameBllFactory = new ProjectNameBLLFactory();
            IProjectNameBLL<ProjectNameModel> projectNameBll = projectNameBllFactory.CreateBllObj();
            ITraInterFaceOrderServerBLLFactory traInterFaceOrderServerBllFactory =
                new TraInterFaceOrderServerBLLFactory();
            ITraInterFaceOrderServerBLL<TraInterFaceOrderModel> traInterFaceOrderServerBll =
                traInterFaceOrderServerBllFactory.CreateBllObj();
            ITraModOrderBLLFactory traModOrderBllFactory = new TraModOrderBLLFactory();
            ITraModOrderBLL<TraModOrderModel> traModOrderBll = traModOrderBllFactory.CreateBllObj();
            ITraOrderBLLFactory orderBllFactory = new TraOrderBLLFactory();
            ITraOrderBLL<TraOrderModel> orderBll = orderBllFactory.CreateBllObj();

            return new OrderDomain(orderListBll, orderStatusBll, orderDetailBll, passengerBll, projectNameBll,
                traInterFaceOrderServerBll, traModOrderBll, orderBll);
        }

        public IOrderDomain CreateRetOrderListDomainObj()
        {
            ITraOrderListBLLFactory orderListBllFactory = new TraOrderBLLFactory();
            ITraOrderListBLL<TraOrderListDataModel> orderListBll = orderListBllFactory.CreateBllObj();
            ITraOrderStatusBLLFactory orderStatusBllFactory = new TraOrderStatusBLLFactory();
            ITraOrderStatusBLL<TraOrderStatusModel> orderStatusBll = orderStatusBllFactory.CreateBllObj();
            ITraOrderDetailBLLFactory orderDetailBllFactory = new TraOrderDetailBLLFactory();
            ITraOrderDetailBLL<TraOrderDetailModel> orderDetailBll = orderDetailBllFactory.CreateBllObj();
            ITraPassengerBLLFactory passengerBllFactory = new TraPassengerBLLFactory();
            ITraPassengerBLL<TraPassengerModel> passengerBll = passengerBllFactory.CreateBllObj();
            IProjectNameBLLFactory projectNameBllFactory = new ProjectNameBLLFactory();
            IProjectNameBLL<ProjectNameModel> projectNameBll = projectNameBllFactory.CreateBllObj();
            ITraInterFaceOrderServerBLLFactory traInterFaceOrderServerBllFactory =
                new TraInterFaceOrderServerBLLFactory();
            ITraInterFaceOrderServerBLL<TraInterFaceOrderModel> traInterFaceOrderServerBll =
                traInterFaceOrderServerBllFactory.CreateBllObj();
            return new OrderDomain(orderListBll, orderStatusBll, orderDetailBll, passengerBll, projectNameBll,
                traInterFaceOrderServerBll);
        }

        public IOrderDomain CreateOrderInfoDomainObj()
        {
            ICustomerBLLFactory factory = new CustomerBLLFactory();
            ICustomerBLL<CustomerInfoModel> customerBll = factory.CreateBllObj();
            ITraOrderBLLFactory orderBllFactory = new TraOrderBLLFactory();
            ITraOrderBLL<TraOrderModel> orderBll = orderBllFactory.CreateBllObj();
            ITraOrderStatusBLLFactory orderStatusBllFactory = new TraOrderStatusBLLFactory();
            ITraOrderStatusBLL<TraOrderStatusModel> orderStatusBll = orderStatusBllFactory.CreateBllObj();
            ITraOrderDetailBLLFactory orderDetailBllFactory = new TraOrderDetailBLLFactory();
            ITraOrderDetailBLL<TraOrderDetailModel> orderDetailBll = orderDetailBllFactory.CreateBllObj();
            ITraPassengerBLLFactory passengerBllFactory = new TraPassengerBLLFactory();
            ITraPassengerBLL<TraPassengerModel> passengerBll = passengerBllFactory.CreateBllObj();
            IProjectNameBLLFactory projectNameBllFactory = new ProjectNameBLLFactory();
            IProjectNameBLL<ProjectNameModel> projectNameBll = projectNameBllFactory.CreateBllObj();
            ITraInterFaceOrderServerBLLFactory traInterFaceOrderServerBllFactory =
                new TraInterFaceOrderServerBLLFactory();
            ITraInterFaceOrderServerBLL<TraInterFaceOrderModel> traInterFaceOrderServerBll =
                traInterFaceOrderServerBllFactory.CreateBllObj();
            return new OrderDomain(orderBll, orderStatusBll, orderDetailBll, passengerBll, customerBll, projectNameBll, traInterFaceOrderServerBll);
        }

        public IOrderDomain CreateAppOrderInfoDomainObj()
        {
            ICustomerBLLFactory factory = new CustomerBLLFactory();
            ICustomerBLL<CustomerInfoModel> customerBll = factory.CreateBllObj();
            ITraOrderBLLFactory orderBllFactory = new TraOrderBLLFactory();
            ITraOrderBLL<TraOrderModel> orderBll = orderBllFactory.CreateBllObj();
            ITraOrderStatusBLLFactory orderStatusBllFactory = new TraOrderStatusBLLFactory();
            ITraOrderStatusBLL<TraOrderStatusModel> orderStatusBll = orderStatusBllFactory.CreateBllObj();
            ITraOrderDetailBLLFactory orderDetailBllFactory = new TraOrderDetailBLLFactory();
            ITraOrderDetailBLL<TraOrderDetailModel> orderDetailBll = orderDetailBllFactory.CreateBllObj();
            ITraPassengerBLLFactory passengerBllFactory = new TraPassengerBLLFactory();
            ITraPassengerBLL<TraPassengerModel> passengerBll = passengerBllFactory.CreateBllObj();
            IProjectNameBLLFactory projectNameBllFactory = new ProjectNameBLLFactory();
            IProjectNameBLL<ProjectNameModel> projectNameBll = projectNameBllFactory.CreateBllObj();
            ITraInterFaceOrderServerBLLFactory traInterFaceOrderServerBllFactory =
                new TraInterFaceOrderServerBLLFactory();
            ITraInterFaceOrderServerBLL<TraInterFaceOrderModel> traInterFaceOrderServerBll =
                traInterFaceOrderServerBllFactory.CreateBllObj();

            ITraModOrderBLLFactory modOrderBllFactory = new TraModOrderBLLFactory();
            ITraModOrderBLL<TraModOrderModel> traModOrderBll = modOrderBllFactory.CreateBllObj();

            ITraModOrderDetailBLLFactory traModOrderDetailBllFactory = new TraModOrderDetailBLLFactory();
            ITraModOrderDetailBLL<TraModOrderDetailModel> traModOrderDetailBll =
                traModOrderDetailBllFactory.CreateBllObj();
            IGetCorpAduitOrderServiceBll _getCorpAduitOrderServiceBll = new GetCorpAduitOrderServiceBllFactory().CreateObj();

            return new OrderDomain(orderBll, orderStatusBll, orderDetailBll, passengerBll, customerBll, projectNameBll,
                traInterFaceOrderServerBll, traModOrderBll, traModOrderDetailBll, _getCorpAduitOrderServiceBll);
        }

        public IOrderDomain CreateAddRetOrderViewDomainObj()
        {
            ITraOrderBLLFactory orderBllFactory = new TraOrderBLLFactory();
            ITraOrderBLL<TraOrderModel> orderBll = orderBllFactory.CreateBllObj();
            ITraOrderStatusBLLFactory orderStatusBllFactory = new TraOrderStatusBLLFactory();
            ITraOrderStatusBLL<TraOrderStatusModel> orderStatusBll = orderStatusBllFactory.CreateBllObj();
            ITraOrderDetailBLLFactory orderDetailBllFactory = new TraOrderDetailBLLFactory();
            ITraOrderDetailBLL<TraOrderDetailModel> orderDetailBll = orderDetailBllFactory.CreateBllObj();
            ITraPassengerBLLFactory passengerBllFactory = new TraPassengerBLLFactory();
            ITraPassengerBLL<TraPassengerModel> passengerBll = passengerBllFactory.CreateBllObj();
            ITraOrderLogBLLFactory traOrderLogBllFactory = new TraOrderLogBLLFactory();
            ITraOrderLogBLL<TraOrderLogModel> traOrderLogBll = traOrderLogBllFactory.CreateBllObj();
            ITraModOrderBLLFactory traModOrderBllFactory = new TraModOrderBLLFactory();
            ITraModOrderBLL<TraModOrderModel> traModOrderBll = traModOrderBllFactory.CreateBllObj();
            ITraModOrderDetailBLLFactory traModOrderDetailBllFactory = new TraModOrderDetailBLLFactory();
            ITraModOrderDetailBLL<TraModOrderDetailModel> traModOrderDetailBll =
                traModOrderDetailBllFactory.CreateBllObj();

            return new OrderDomain(orderBll, orderStatusBll, orderDetailBll, passengerBll, traOrderLogBll,
                traModOrderBll, traModOrderDetailBll);
        }

        public IOrderDomain CreateAddRetOrderDomainObj()
        {
            ITraOrderBLLFactory orderBllFactory = new TraOrderBLLFactory();
            ITraOrderBLL<TraOrderModel> orderBll = orderBllFactory.CreateBllObj();
            ITraOrderStatusBLLFactory orderStatusBllFactory = new TraOrderStatusBLLFactory();
            ITraOrderStatusBLL<TraOrderStatusModel> orderStatusBll = orderStatusBllFactory.CreateBllObj();
            ITraOrderDetailBLLFactory orderDetailBllFactory = new TraOrderDetailBLLFactory();
            ITraOrderDetailBLL<TraOrderDetailModel> orderDetailBll = orderDetailBllFactory.CreateBllObj();
            ITraPassengerBLLFactory passengerBllFactory = new TraPassengerBLLFactory();
            ITraPassengerBLL<TraPassengerModel> passengerBll = passengerBllFactory.CreateBllObj();
            ITraModOrderBLLFactory traModOrderBllFactory = new TraModOrderBLLFactory();
            ITraModOrderBLL<TraModOrderModel> traModOrderBll = traModOrderBllFactory.CreateBllObj();
            ITraOrderLogBLLFactory traOrderLogBllFactory = new TraOrderLogBLLFactory();
            ITraOrderLogBLL<TraOrderLogModel> traOrderLogBll = traOrderLogBllFactory.CreateBllObj();
            ITraInterFaceOrderServerBLLFactory traInterFaceOrderServerBllFactory=new TraInterFaceOrderServerBLLFactory();
            ITraInterFaceOrderServerBLL<TraInterFaceOrderModel> traInterFaceOrderServerBll =
                traInterFaceOrderServerBllFactory.CreateBllObj();

            ITraModOrderDetailBLLFactory traModOrderDetailBllFactory = new TraModOrderDetailBLLFactory();
            ITraModOrderDetailBLL<TraModOrderDetailModel> traModOrderDetailBll =
                traModOrderDetailBllFactory.CreateBllObj();

            return new OrderDomain(orderBll, orderStatusBll, orderDetailBll, passengerBll, traModOrderBll,
                traOrderLogBll, traInterFaceOrderServerBll, traModOrderDetailBll);
        }

        public IOrderDomain CreateAddModOrderViewDomainObj()
        {
            ITraOrderBLLFactory orderBllFactory = new TraOrderBLLFactory();
            ITraOrderBLL<TraOrderModel> orderBll = orderBllFactory.CreateBllObj();
            ITraOrderStatusBLLFactory orderStatusBllFactory = new TraOrderStatusBLLFactory();
            ITraOrderStatusBLL<TraOrderStatusModel> orderStatusBll = orderStatusBllFactory.CreateBllObj();
            ITraOrderDetailBLLFactory orderDetailBllFactory = new TraOrderDetailBLLFactory();
            ITraOrderDetailBLL<TraOrderDetailModel> orderDetailBll = orderDetailBllFactory.CreateBllObj();
            ITraPassengerBLLFactory passengerBllFactory = new TraPassengerBLLFactory();
            ITraPassengerBLL<TraPassengerModel> passengerBll = passengerBllFactory.CreateBllObj();
            ITraModOrderBLLFactory traModOrderBllFactory = new TraModOrderBLLFactory();
            ITraModOrderBLL<TraModOrderModel> traModOrderBll = traModOrderBllFactory.CreateBllObj();
            ITraModOrderDetailBLLFactory traModOrderDetailBllFactory = new TraModOrderDetailBLLFactory();
            ITraModOrderDetailBLL<TraModOrderDetailModel> traModOrderDetailBll =
                traModOrderDetailBllFactory.CreateBllObj();
            return new OrderDomain(orderBll, orderStatusBll, orderDetailBll, passengerBll, traModOrderBll,
                traModOrderDetailBll);
        }

        public IOrderDomain CreateAddModOrderDomainObj()
        {
            ITraOrderBLLFactory orderBllFactory = new TraOrderBLLFactory();
            ITraOrderBLL<TraOrderModel> orderBll = orderBllFactory.CreateBllObj();
            ITraOrderStatusBLLFactory orderStatusBllFactory = new TraOrderStatusBLLFactory();
            ITraOrderStatusBLL<TraOrderStatusModel> orderStatusBll = orderStatusBllFactory.CreateBllObj();
            ITraOrderDetailBLLFactory orderDetailBllFactory = new TraOrderDetailBLLFactory();
            ITraOrderDetailBLL<TraOrderDetailModel> orderDetailBll = orderDetailBllFactory.CreateBllObj();
            ITraPassengerBLLFactory passengerBllFactory = new TraPassengerBLLFactory();
            ITraPassengerBLL<TraPassengerModel> passengerBll = passengerBllFactory.CreateBllObj();
            ITraModOrderBLLFactory traModOrderBllFactory = new TraModOrderBLLFactory();
            ITraModOrderBLL<TraModOrderModel> traModOrderBll = traModOrderBllFactory.CreateBllObj();
            ITraModOrderDetailBLLFactory traModOrderDetailBllFactory = new TraModOrderDetailBLLFactory();
            ITraModOrderDetailBLL<TraModOrderDetailModel> traModOrderDetailBll =
                traModOrderDetailBllFactory.CreateBllObj();
            ITraInterFaceOrderServerBLLFactory traInterFaceOrderServerBllFactory = new TraInterFaceOrderServerBLLFactory();
            ITraInterFaceOrderServerBLL<TraInterFaceOrderModel> traInterFaceOrderServerBll =
                traInterFaceOrderServerBllFactory.CreateBllObj();

            ITraOrderLogBLLFactory traOrderLogBllFactory = new TraOrderLogBLLFactory();
            ITraOrderLogBLL<TraOrderLogModel> traOrderLogBll = traOrderLogBllFactory.CreateBllObj();

            ICustomerBLLFactory factory = new CustomerBLLFactory();
            ICustomerBLL<CustomerInfoModel> customerBll = factory.CreateBllObj();

            ICorporationBLLFactory corporationBllFactory = new CorporationBLLFactory();
            ICorporationBLL<CorporationModel> corporationBll = corporationBllFactory.CreateBllObj();

            return new OrderDomain(orderBll, orderStatusBll, orderDetailBll, passengerBll, traModOrderBll,
                traModOrderDetailBll, traInterFaceOrderServerBll, traOrderLogBll, corporationBll, customerBll);
        }

        public IOrderDomain CreateUpdateOrderDomainObj()
        {
            ITraOrderBLLFactory orderBllFactory = new TraOrderBLLFactory();
            ITraOrderBLL<TraOrderModel> orderBll = orderBllFactory.CreateBllObj();
            ITraOrderStatusBLLFactory orderStatusBllFactory = new TraOrderStatusBLLFactory();
            ITraOrderStatusBLL<TraOrderStatusModel> orderStatusBll = orderStatusBllFactory.CreateBllObj();
            ITraOrderDetailBLLFactory orderDetailBllFactory = new TraOrderDetailBLLFactory();
            ITraOrderDetailBLL<TraOrderDetailModel> orderDetailBll = orderDetailBllFactory.CreateBllObj();
            ITraPassengerBLLFactory passengerBllFactory = new TraPassengerBLLFactory();
            ITraPassengerBLL<TraPassengerModel> passengerBll = passengerBllFactory.CreateBllObj();
            ITraOrderLogBLLFactory traOrderLogBllFactory = new TraOrderLogBLLFactory();
            ITraOrderLogBLL<TraOrderLogModel> traOrderLogBll = traOrderLogBllFactory.CreateBllObj();
            ITraModOrderBLLFactory traModOrderBllFactory = new TraModOrderBLLFactory();
            ITraModOrderBLL<TraModOrderModel> traModOrderBll = traModOrderBllFactory.CreateBllObj();
            IAddSendAppMessageServiceBll addSendAppMessageServiceBll = CustomerFactory.CreateSendAppMessageObj();

            return new OrderDomain(orderBll, orderStatusBll, orderDetailBll, passengerBll, traOrderLogBll,
                traModOrderBll, addSendAppMessageServiceBll);
        }

        public IOrderDomain CreateModOrderListDomainObj()
        {
            ITraModOrderListBLLFactory orderBllFactory = new TraModOrderBLLFactory();
            ITraOrderListBLL<TraModOrderListDataModel> traModOrderListBll = orderBllFactory.CreateBllObj();

            ITraModOrderDetailBLLFactory traModOrderDetailBllFactory = new TraModOrderDetailBLLFactory();
            ITraModOrderDetailBLL<TraModOrderDetailModel> traModOrderDetailBll =
                traModOrderDetailBllFactory.CreateBllObj();

            ITraPassengerBLLFactory passengerBllFactory = new TraPassengerBLLFactory();
            ITraPassengerBLL<TraPassengerModel> passengerBll = passengerBllFactory.CreateBllObj();

            return new OrderDomain(traModOrderListBll, traModOrderDetailBll, passengerBll);
        }

        public IOrderDomain CreateModOrderInfoDomainObj()
        {
            ITraModOrderBLLFactory orderModBllFactory = new TraModOrderBLLFactory();
            ITraModOrderBLL<TraModOrderModel> traModOrderBll = orderModBllFactory.CreateBllObj();

            ITraModOrderDetailBLLFactory traModOrderDetailBllFactory = new TraModOrderDetailBLLFactory();
            ITraModOrderDetailBLL<TraModOrderDetailModel> traModOrderDetailBll =
                traModOrderDetailBllFactory.CreateBllObj();

            ITraPassengerBLLFactory passengerBllFactory = new TraPassengerBLLFactory();
            ITraPassengerBLL<TraPassengerModel> passengerBll = passengerBllFactory.CreateBllObj();

            ITraOrderBLLFactory orderBllFactory = new TraOrderBLLFactory();
            ITraOrderBLL<TraOrderModel> orderBll = orderBllFactory.CreateBllObj();

            return new OrderDomain(traModOrderBll, traModOrderDetailBll, passengerBll, orderBll);
        }

        public IOrderDomain Create12306AccountDomainObj()
        {
            ITra12306AccountBllFactory tra12306AccountBllFactory = new Tra12306AccountBllFactory();
            ITra12306AccountBll<Tra12306AccountModel> tra12306AccountBll = tra12306AccountBllFactory.CreateBllObj();
            return new OrderDomain(tra12306AccountBll);
        }
    }
}
