using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mzl.DomainModel.Customer.Base;
using Mzl.DomainModel.Customer.CorpPolicy;
using Mzl.EntityModel.Customer.BaseInfo;
using Mzl.EntityModel.Customer.Corporation.CorpPolicy;
using Mzl.Framework.Base;
using Mzl.IBLL.Customer.Customer;
using Mzl.IDAL.Customer.Corporation;
using Mzl.IDAL.Customer.Customer;

namespace Mzl.BLL.Customer.Customer
{
    public class GetCorpPolicyCustomerServiceBll : BaseServiceBll, IGetCorpPolicyCustomerServiceBll
    {
        private readonly ICorpPolicyConfigDepartmentDal _corpPolicyConfigDepartmentDal;
        private readonly ICustomerDal _customerDal;
        private readonly ICorpPolicyConfigCustomerDal _corpPolicyConfigCustomerDal;

        public GetCorpPolicyCustomerServiceBll(ICorpPolicyConfigDepartmentDal corpPolicyConfigDepartmentDal,
            ICustomerDal customerDal, ICorpPolicyConfigCustomerDal corpPolicyConfigCustomerDal)
        {
            _corpPolicyConfigDepartmentDal = corpPolicyConfigDepartmentDal;
            _customerDal = customerDal;
            _corpPolicyConfigCustomerDal = corpPolicyConfigCustomerDal;
        }

        public List<CorpPolicyCustomerModel> GetCorpPolicyCustomer(string corpId, int policyId)
        {
            List<CorpPolicyCustomerModel> corpPolicyCustomerModels = new List<CorpPolicyCustomerModel>();

            //根据政策Id从部门关联表中获取对应的部门Id
            List<CorpPolicyConfigDepartmentEntity> configDepartmentEntities =
                _corpPolicyConfigDepartmentDal.Query<CorpPolicyConfigDepartmentEntity>(n => n.PolicyId == policyId, true)
                    .ToList();

            List<int> departIdList = new List<int>();
            configDepartmentEntities.ForEach(n => departIdList.Add(n.DepartmentId));

            //根据部门id获取客户id
            List<CustomerInfoEntity> customerInfoEntities =
                _customerDal.Query<CustomerInfoEntity>(
                    n =>
                        !string.IsNullOrEmpty(n.CorpID) && n.CorpID.ToUpper() == corpId.ToUpper() &&
                        departIdList.Contains(n.CorpDepartID ?? 0) && !string.IsNullOrEmpty(n.IsDel) &&
                        n.IsDel.ToUpper() == "F" && n.IsLock.ToUpper() == "F", true)
                    .ToList();


            //根据政策Id获取对应的客户id信息
            List<CorpPolicyConfigCustomerEntity> corpPolicyConfigCustomerEntities =
                _corpPolicyConfigCustomerDal.Query<CorpPolicyConfigCustomerEntity>(
                    n => n.PolicyId == policyId, true).ToList();

            //根据政策id获取非对应的客户信息
            List<CorpPolicyConfigCustomerEntity> corpPolicyConfigCustomerEntities2 =
                (from c in base.Context.Set<CorpPolicyConfigCustomerEntity>()
                    join a in Context.Set<CorpPolicyConfigEntity>() on c.PolicyId equals a.PolicyId
                    where a.IsDel == "F" && c.PolicyId != policyId
                    select c).ToList();


            foreach (var customerInfoEntity in customerInfoEntities)
            {
                if (corpPolicyConfigCustomerEntities2.Find(n=>n.Cid== customerInfoEntity.Cid)!=null)
                {
                    continue;
                }

                CorpPolicyConfigCustomerEntity configCustomerEntity =
                    corpPolicyConfigCustomerEntities.Find(n => n.Cid == customerInfoEntity.Cid);

                corpPolicyCustomerModels.Add(new CorpPolicyCustomerModel()
                {
                    Cid = customerInfoEntity.Cid,
                    CustomerName = customerInfoEntity.RealName,
                    DepartmentName = customerInfoEntity.DepartmentName,
                    IsHasPolicy = (configCustomerEntity != null)
                });
            }
            corpPolicyCustomerModels = corpPolicyCustomerModels.OrderBy(n => n.DepartmentName).ToList();
            return corpPolicyCustomerModels;
        }
    }
}
