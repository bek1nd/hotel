using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mzl.DomainModel.Customer.CorpDepartment;
using Mzl.EntityModel.Customer.Corporation.CorpAudit;
using Mzl.EntityModel.Customer.Corporation.CorpPolicy;
using Mzl.Framework.Base;
using Mzl.IBLL.Customer.CorpDepartment;
using Mzl.IDAL.Customer.Corporation;

namespace Mzl.BLL.Customer.CorpDepartment
{
    public class GetCorpPolicyDepartmentServiceBll : BaseServiceBll,IGetCorpPolicyDepartmentServiceBll
    {
        private readonly IGetCorpDepartmentBll _getCorpDepartmentBll;
        private readonly ICorpPolicyConfigDepartmentDal _corpPolicyConfigDepartmentDal;
        private readonly ICorpAduitConfigDepartmentDal _corpAduitConfigDepartmentDal;

        public GetCorpPolicyDepartmentServiceBll(IGetCorpDepartmentBll getCorpDepartmentBll,
            ICorpPolicyConfigDepartmentDal corpPolicyConfigDepartmentDal, ICorpAduitConfigDepartmentDal corpAduitConfigDepartmentDal)
        {
            _getCorpDepartmentBll = getCorpDepartmentBll;
            _corpPolicyConfigDepartmentDal = corpPolicyConfigDepartmentDal;
            _corpAduitConfigDepartmentDal = corpAduitConfigDepartmentDal;
        }

        public List<CorpDepartmentModel> GetCorpPolicyDepartmentByCorpId(string corpId,int? policyId,int? aduitId)
        {
            List<CorpDepartmentModel> departmentModels = _getCorpDepartmentBll.GetCorpDepartmentByCorpId(corpId);
            List<int> departIdList = new List<int>();
            foreach (var corpDepartmentModel in departmentModels)
            {
                departIdList.Add(corpDepartmentModel.Id);
            }
            List<CorpPolicyConfigDepartmentEntity> policyDepartmentEntities = null;
            if (policyId.HasValue)
            {
                policyDepartmentEntities = _corpPolicyConfigDepartmentDal.Query<CorpPolicyConfigDepartmentEntity>(
                    n => departIdList.Contains(n.DepartmentId) && n.PolicyId == policyId.Value, true).ToList();
            }

            List<CorpAduitConfigDepartmentEntity> aduitConfigDepartmentEntities = null;
            if (aduitId.HasValue)
            {
                aduitConfigDepartmentEntities = _corpAduitConfigDepartmentDal.Query<CorpAduitConfigDepartmentEntity>(
                    n => departIdList.Contains(n.DepartmentId) && n.AduitId == aduitId.Value, true).ToList();
            }


            foreach (var corpDepartmentModel in departmentModels)
            {
                CorpPolicyConfigDepartmentEntity corpPolicyConfigDepartmentEntity =
                    policyDepartmentEntities?.Find(n => n.DepartmentId == corpDepartmentModel.Id);
                if (corpPolicyConfigDepartmentEntity!=null)
                {
                    corpDepartmentModel.IsHasPolicy = true;
                }

                CorpAduitConfigDepartmentEntity corpAduitConfigDepartmentEntity =
                    aduitConfigDepartmentEntities?.Find(n => n.DepartmentId == corpDepartmentModel.Id);
                if (corpAduitConfigDepartmentEntity != null)
                {
                    corpDepartmentModel.IsHasAduit = true;
                }
            }
            return departmentModels;
        }
    }
}
