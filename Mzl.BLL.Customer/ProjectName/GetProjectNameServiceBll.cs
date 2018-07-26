using Mzl.Framework.Base;
using Mzl.IBLL.Customer.ProjectName;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mzl.DomainModel.Customer.ProjectName;
using Mzl.IDAL.Customer.Corporation;
using Mzl.EntityModel.Customer.Corporation.Project;
using AutoMapper;
using Mzl.IDAL.Customer.Customer;
using Mzl.EntityModel.Customer.BaseInfo;
using Mzl.EntityModel.Customer.Corporation.CorpAudit;
using Mzl.EntityModel.Customer.Corporation.CorpPolicy;

namespace Mzl.BLL.Customer.ProjectName
{
    public class GetProjectNameServiceBll: BaseServiceBll, IGetProjectNameServiceBll
    {
        private readonly IProjectNameDal _projectNameDal;
        private readonly ICustomerDal _customerDal;
        private readonly ICorpPolicyConfigProjectDal _corpPolicyConfigProjectDal;
        private readonly ICorpAduitConfigProjectDal _corpAduitConfigProjectDal;

        public GetProjectNameServiceBll(IProjectNameDal projectNameDal,
            ICorpPolicyConfigProjectDal corpPolicyConfigProjectDal, ICorpAduitConfigProjectDal corpAduitConfigProjectDal, ICustomerDal customerDal)
        {
            _projectNameDal = projectNameDal;
            _corpPolicyConfigProjectDal = corpPolicyConfigProjectDal;
            _corpAduitConfigProjectDal = corpAduitConfigProjectDal;
            _customerDal = customerDal;
        }

        public List<ProjectNameModel> GetProjectName(string corpId)
        {
            return GetProjectNameByCorpId(corpId);
        }

        public List<ProjectNameModel> GetProjectNameByNotDelete(string corpId)
        {
            return GetProjectName(corpId)?.FindAll(n => n.IsDelete == "F");
        }

        public List<ProjectNameModel> GetProjectName(int cid)
        {
            CustomerInfoEntity  customerInfoEntity= _customerDal.Find<CustomerInfoEntity>(cid);
            if (string.IsNullOrEmpty(customerInfoEntity.CorpID))
                return null;
            return GetProjectNameByCorpId(customerInfoEntity.CorpID);
        }

        public List<ProjectNameModel> GetProjectNameByNotDelete(int cid)
        {
            return GetProjectName(cid)?.FindAll(n => n.IsDelete == "F");
        }

        public List<ProjectNameModel> GetCorpPolicyProjectByCorpId(string corpId, int? policyId, int? aduitId)
        {
            List<ProjectNameModel> projectNameModels = GetProjectNameByCorpId(corpId, "F");
            List<int> projectIdList = new List<int>();
            foreach (var projectNameModel in projectNameModels)
            {
                projectIdList.Add(projectNameModel.ProjectId);
            }

            List<CorpPolicyConfigProjectEntity> corpPolicyConfigProjectEntities = null;
            if (policyId.HasValue)
            {
                corpPolicyConfigProjectEntities = _corpPolicyConfigProjectDal.Query<CorpPolicyConfigProjectEntity>(
                    n => projectIdList.Contains(n.ProjectId) && n.PolicyId == policyId.Value, true).ToList();
            }

            List<CorpAduitConfigProjectEntity> corpAduitConfigProjectEntities = null;
            if (aduitId.HasValue)
            {
                corpAduitConfigProjectEntities = _corpAduitConfigProjectDal.Query<CorpAduitConfigProjectEntity>(
                    n => projectIdList.Contains(n.ProjectId) && n.AduitId == aduitId.Value, true).ToList();
            }


            foreach (var projectNameModel in projectNameModels)
            {
                CorpPolicyConfigProjectEntity corpPolicyConfigProjectEntity =
                    corpPolicyConfigProjectEntities?.Find(n => n.ProjectId == projectNameModel.ProjectId);
                if (corpPolicyConfigProjectEntity != null)
                {
                    projectNameModel.IsHasPolicy = true;
                }

                CorpAduitConfigProjectEntity corpAduitConfigDepartmentEntity =
                    corpAduitConfigProjectEntities?.Find(n => n.ProjectId == projectNameModel.ProjectId);
                if (corpAduitConfigDepartmentEntity != null)
                {
                    projectNameModel.IsHasAduit = true;
                }
            }

            return projectNameModels;
        }

        private List<ProjectNameModel> GetProjectNameByCorpId(string corpId,string isDel="")
        {
            IQueryable<ProjectNameEntity> queryable =
                _projectNameDal.Query<ProjectNameEntity>(n => n.CorpId.ToLower() == corpId.ToLower());
            if (!string.IsNullOrEmpty(isDel))
                queryable = queryable.Where(n => n.IsDelete == isDel);

            List<ProjectNameEntity> projectNameEntities = queryable.ToList();
            return Mapper.Map<List<ProjectNameEntity>, List<ProjectNameModel>>(projectNameEntities);
        }
    }
}
