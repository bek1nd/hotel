using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Mzl.DomainModel.Customer.CorpDepartment;
using Mzl.DomainModel.Customer.ProjectName;
using Mzl.Framework.Base;
using Mzl.IApplication.Customer;
using Mzl.IBLL.Customer.ProjectName;
using Mzl.UIModel.Customer.CorpPolicy;

namespace Mzl.Application.Customer
{
    internal class GetCorpPolicyProjectApplication : BaseApplicationService,IGetCorpPolicyProjectApplication
    {
        private readonly IGetProjectNameServiceBll _getProjectNameServiceBll;

        public GetCorpPolicyProjectApplication(IGetProjectNameServiceBll getProjectNameServiceBll)
        {
            _getProjectNameServiceBll = getProjectNameServiceBll;
        }

        public GetCorpPolicyProjectResponseViewModel GetCorpPolicyProjectByCorpId(
            GetCorpPolicyProjectRequestViewModel request)
        {
            List<ProjectNameModel> projectNameModels =
                _getProjectNameServiceBll.GetCorpPolicyProjectByCorpId(request.CorpId, request.PolicyId, request.AduitId);

            GetCorpPolicyProjectResponseViewModel viewModel = new GetCorpPolicyProjectResponseViewModel();
            viewModel.ProjectList =
                Mapper.Map<List<ProjectNameModel>, List<CorpPolicyProjectViewModel>>(projectNameModels);
            return viewModel;
        }
    }
}
