using Mzl.IApplication.Customer.Factory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mzl.IApplication.Customer.Domain;
using Mzl.IBLL.Customer.CostCenter.Factory;
using Mzl.BLL.Customer.CostCenter.Factory;
using Mzl.IBLL.Customer.CostCenter.BLL;
using Mzl.DomainModel.Customer.CostCenter;
using Mzl.Application.Customer.Domain;
using Mzl.BLL.Customer.Corp.Factory;
using Mzl.BLL.Customer.Customer.Factory;
using Mzl.IBLL.Customer.ProjectName.Factory;
using Mzl.BLL.Customer.ProjectName.Factory;
using Mzl.BLL.Customer.ServiceFee.Factory;
using Mzl.DomainModel.Customer.Base;
using Mzl.DomainModel.Customer.Corp;
using Mzl.DomainModel.Customer.ProjectName;
using Mzl.DomainModel.Customer.ServiceFee;
using Mzl.IBLL.Customer.ProjectName.BLL;
using Mzl.IBLL.Customer.ServiceFee.BLL;
using Mzl.IBLL.Customer.Corp.BLL;
using Mzl.IBLL.Customer.Corp.Factory;
using Mzl.IBLL.Customer.Customer.BLL;
using Mzl.IBLL.Customer.Customer.Factory;
using Mzl.IBLL.Customer.ServiceFee.Factory;

namespace Mzl.Application.Customer.Factory
{
    public class CorporationDomainFactory : ICorporationDomainFactory
    {
        public ICorporationDomain CreateDomainCostCenterObj()
        {
            ICostCenterBLLFactory factory = new CostCenterBLLFactory();
            ICostCenterBLL<CostCenterModel> costCenterBll = factory.CreateBllObj();
            return new CorporationDomain(costCenterBll);
        }

        public ICorporationDomain CreateDomainObj()
        {
            ICorporationBLLFactory corporationBllFactory = new CorporationBLLFactory();
            ICorporationBLL<CorporationModel> corporationBll = corporationBllFactory.CreateBllObj();
            return new CorporationDomain(corporationBll);
        }

        public ICorporationDomain CreateDomainProjectNameObj()
        {
            IProjectNameBLLFactory factory = new ProjectNameBLLFactory();
            IProjectNameBLL<ProjectNameModel> projectNameBll = factory.CreateBllObj();
            return new CorporationDomain(projectNameBll);
        }
        public ICorporationDomain CreateDomainProjectNameAndCostCenterObj()
        {
            IProjectNameBLLFactory projectNameBllFactory = new ProjectNameBLLFactory();
            IProjectNameBLL<ProjectNameModel> projectNameBll = projectNameBllFactory.CreateBllObj();
            ICostCenterBLLFactory consCostCenterBllFactory = new CostCenterBLLFactory();
            ICostCenterBLL<CostCenterModel> costCenterBll = consCostCenterBllFactory.CreateBllObj();
            return new CorporationDomain(projectNameBll, costCenterBll);
        }

        public ICorporationDomain CreateComfireOrderViewObj()
        {
            IProjectNameBLLFactory projectNameBllFactory = new ProjectNameBLLFactory();
            IProjectNameBLL<ProjectNameModel> projectNameBll = projectNameBllFactory.CreateBllObj();
            ICostCenterBLLFactory consCostCenterBllFactory = new CostCenterBLLFactory();
            ICostCenterBLL<CostCenterModel> costCenterBll = consCostCenterBllFactory.CreateBllObj();

            IServiceFeeConfigBLLFactory serviceFeeConfigBllFactory = new ServiceFeeConfigBLLFactory();
            IServiceFeeConfigBLL<ServiceFeeConfigModel> serviceFeeConfigBll = serviceFeeConfigBllFactory.CreateBllObj();
            IServiceFeeConfigDetailsBLLFactory serviceFeeConfigDetailsBllFactory=new ServiceFeeConfigDetailsBLLFactory();
            IServiceFeeConfigDetailsBLL<ServiceFeeConfigDetailsModel> serviceFeeConfigDetailsBll =
                serviceFeeConfigDetailsBllFactory.CreateBllObj();
            ICorporationBLLFactory corporationBllFactory=new CorporationBLLFactory();
            ICorporationBLL<CorporationModel> corporationBll = corporationBllFactory.CreateBllObj();

            ICustomerBLLFactory customerBllFactory = new CustomerBLLFactory();
            ICustomerBLL<CustomerInfoModel> customerBll = customerBllFactory.CreateBllObj();

            return new CorporationDomain(serviceFeeConfigBll, serviceFeeConfigDetailsBll, corporationBll, projectNameBll,
                costCenterBll, customerBll);
        }

    }
}
