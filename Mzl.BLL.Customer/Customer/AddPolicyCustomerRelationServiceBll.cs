using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mzl.DomainModel.Customer.CorpPolicy;
using Mzl.EntityModel.Customer.Corporation.CorpPolicy;
using Mzl.Framework.Base;
using Mzl.IBLL.Customer.Customer;
using Mzl.IDAL.Customer.Corporation;

namespace Mzl.BLL.Customer.Customer
{
    public class AddPolicyCustomerRelationServiceBll : BaseServiceBll, IAddPolicyCustomerRelationServiceBll
    {
        private readonly ICorpPolicyConfigCustomerDal _corpPolicyConfigCustomerDal;

        public AddPolicyCustomerRelationServiceBll(ICorpPolicyConfigCustomerDal corpPolicyConfigCustomerDal)
        {
            _corpPolicyConfigCustomerDal = corpPolicyConfigCustomerDal;
        }

        public bool AddPolicyCustomerRelation(CorpPolicyConfigCustomerModel model)
        {
            //1.先清空所有关系
            List<CorpPolicyConfigCustomerEntity> corpPolicyConfigCustomerEntities =
                _corpPolicyConfigCustomerDal.Query<CorpPolicyConfigCustomerEntity>(n => n.PolicyId == model.PolicyId)
                    .ToList();
            if (corpPolicyConfigCustomerEntities.Count > 0)
            {
                foreach (var corpPolicyConfigCustomerEntity in corpPolicyConfigCustomerEntities)
                {
                    _corpPolicyConfigCustomerDal.Delete<CorpPolicyConfigCustomerEntity>(corpPolicyConfigCustomerEntity.Id);
                }
            }

            //2.在插入关联信息
            if (model.CidList != null && model.CidList.Count > 0)
            {
                foreach (int cid in model.CidList)
                {
                    _corpPolicyConfigCustomerDal.Insert<CorpPolicyConfigCustomerEntity>(new CorpPolicyConfigCustomerEntity()
                    {
                        Cid = cid,
                        PolicyId = model.PolicyId
                    });
                }
            }


            return true;
        }
    }
}
