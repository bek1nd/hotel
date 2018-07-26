using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mzl.DomainModel.Common.Insurance;
using Mzl.Framework.Base;
using Mzl.IApplication.Common;
using Mzl.IBLL.Common.Insurance;
using Mzl.UIModel.Common.Insurance;
using AutoMapper;

namespace Mzl.Application.Common
{
    internal class GetInsuranceProductApplication: BaseApplicationService,IGetInsuranceProductApplication
    {
        private readonly IGetInsuranceCompanyServiceBll _getInsuranceCompanyServiceBll;
        public GetInsuranceProductApplication(IGetInsuranceCompanyServiceBll getInsuranceCompanyServiceBll) : base()
        {
            _getInsuranceCompanyServiceBll = getInsuranceCompanyServiceBll;
        }

        public InsuranceProductResponseViewModel GetOnlineInsuranceProductList()
        {
            List<InsuranceCompanyModel> insuranceCompanyModels = _getInsuranceCompanyServiceBll.GetOnlineInsuranceCompany();
            InsuranceProductResponseViewModel viewModel = new InsuranceProductResponseViewModel();

            viewModel.InsuranceProductList =
                Mapper.Map<List<InsuranceCompanyModel>, List<InsuranceCompanyViewModel>>(insuranceCompanyModels);


            return viewModel;
        }
    }
}
