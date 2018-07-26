using System.Collections.Generic;
using AutoMapper;
using Mzl.DomainModel.Customer.CorpDepartment;
using Mzl.Framework.Base;
using Mzl.IApplication.Customer;
using Mzl.IBLL.Customer.CorpDepartment;
using Mzl.UIModel.Customer.Corporation;
using Mzl.UIModel.Customer.CorpPolicy;

namespace Mzl.Application.Customer
{
    /// <summary>
    /// 获取差旅公司部门信息
    /// </summary>
    public class GetCorpPolicyDepartmentApplication : BaseApplicationService, IGetCorpPolicyDepartmentApplication
    {
        private readonly IGetCorpPolicyDepartmentServiceBll _getCorpPolicyDepartmentServiceBll;

        public GetCorpPolicyDepartmentApplication(IGetCorpPolicyDepartmentServiceBll getCorpPolicyDepartmentServiceBll)
        {
            _getCorpPolicyDepartmentServiceBll = getCorpPolicyDepartmentServiceBll;
        }

        public GetCorpDepartmentResponseViewModel GetCorpPolicyDepartmentByCorpId(GetCorpDepartmentRequestViewModel request)
        {
            List<CorpDepartmentModel> corpDepartmentModels =
                _getCorpPolicyDepartmentServiceBll.GetCorpPolicyDepartmentByCorpId(request.CorpId, request.PolicyId, request.AduitId);

            GetCorpDepartmentResponseViewModel viewModel = new GetCorpDepartmentResponseViewModel();
            viewModel.DepartmentList =
                Mapper.Map<List<CorpDepartmentModel>, List<CorpPolicyDepartmentViewModel>>(corpDepartmentModels);
            return viewModel;
        }
    }
}
