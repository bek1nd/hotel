using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using AutoMapper;
using Mzl.DomainModel.Customer.Base;
using Mzl.DomainModel.Customer.Corp;
using Mzl.DomainModel.Customer.CorpDepartment;
using Mzl.DomainModel.Customer.CorpPolicy;
using Mzl.EntityModel.Customer.BaseInfo;
using Mzl.EntityModel.Customer.Corporation.Corp;
using Mzl.EntityModel.Customer.Corporation.CorpPolicy;
using Mzl.EntityModel.Customer.Corporation.Department;
using Mzl.Framework.Base;
using Mzl.IBLL.Customer.Customer;
using Mzl.IBLL.Customer.Customer.BLL;
using Mzl.IDAL.Customer.Corporation;
using Mzl.IDAL.Customer.Customer;

namespace Mzl.BLL.Customer.Customer
{
    public class GetCustomerCorpPolicyServiceBll : BaseServiceBll, IGetCustomerCorpPolicyServiceBll
    {
        private readonly ICustomerDal _customerDal;
        private readonly ICorporationDal _corporationDal;
        private readonly ICorpDepartmentDal _corpDepartmentDal;
        private readonly ICorpPolicyDetailConfigDal _corpPolicyDetailConfigDal;
        private readonly IChoiceReasonDal _choiceReasonDal;

        public GetCustomerCorpPolicyServiceBll(ICustomerDal customerDal,
            ICorporationDal corporationDal, ICorpDepartmentDal corpDepartmentDal, 
            ICorpPolicyDetailConfigDal corpPolicyDetailConfigDal, IChoiceReasonDal choiceReasonDal)
        {
            _customerDal = customerDal;
            _corporationDal = corporationDal;
            _corpDepartmentDal = corpDepartmentDal;
            _corpPolicyDetailConfigDal = corpPolicyDetailConfigDal;
            _choiceReasonDal = choiceReasonDal;
        }

        public CorpPolicyDetailConfigModel GetCorpPolicy(int cid)
        {
            CorpPolicyDetailConfigModel policyModel = null;
            //1.获取客户信息
            CustomerInfoEntity customerInfoEntity = _customerDal.Find<CustomerInfoEntity>(cid);
            if (!customerInfoEntity.CorpDepartID.HasValue)
                return null;
            List<CorporationEntity> corporationModels = _corporationDal.Query<CorporationEntity>(n => n.CorpId == customerInfoEntity.CorpID,true).ToList();
            if(corporationModels==null|| corporationModels.Count==0)
                return null;


            //2.获取部门信息
            CorpDepartmentEntity corpDepartmentEntity =
                _corpDepartmentDal.Find<CorpDepartmentEntity>(customerInfoEntity.CorpDepartID.Value);
           
            if (!corpDepartmentEntity.PolicyId.HasValue)
                return null;
            //3.获取部门上的差旅政策信息
            List<CorpPolicyDetailConfigEntity> corpPolicyDetailConfigEntities =
                _corpPolicyDetailConfigDal.Query<CorpPolicyDetailConfigEntity>(
                    n => n.PolicyId == corpDepartmentEntity.PolicyId.Value, true).ToList();

            policyModel = CorpPolicyConvertFactory.Convert(corpPolicyDetailConfigEntities);
            policyModel.CorpDepartmentModel = Mapper.Map<CorpDepartmentEntity, CorpDepartmentModel>(corpDepartmentEntity); 
            policyModel.CorpModel = Mapper.Map<CorporationEntity, CorporationModel>(corporationModels[0]); 
            policyModel.CustomerInfoModel = Mapper.Map<CustomerInfoEntity, CustomerInfoModel>(customerInfoEntity);

            List<ChoiceReasonEntity> choiceReasonEntities = null;
            if (!string.IsNullOrEmpty(corpDepartmentEntity.CorpId))
                choiceReasonEntities =
                    _choiceReasonDal.Query<ChoiceReasonEntity>(
                        n => n.IsDel != "T" && n.CorpID == corpDepartmentEntity.CorpId,true).ToList();
            if (choiceReasonEntities != null)
            {
                policyModel.PolicyReason = choiceReasonEntities.Select(n => n.Reason).ToList();
                policyModel.PolicyReasonList = (from n in choiceReasonEntities
                    select new ChoiceReasonModel()
                    {
                        Id = n.ID,
                        Reason = n.Reason
                    }).ToList();
            }
            return policyModel;
        }

        public CorpPolicyDetailConfigModel GetCorpPolicyById(int policyId,string corpId,string policyType)
        {
            if (string.IsNullOrEmpty(corpId))
                return null;
            if(policyId==0)
                return null;

            List<CorpPolicyDetailConfigEntity> corpPolicyDetailConfigEntities =
                _corpPolicyDetailConfigDal.Query<CorpPolicyDetailConfigEntity>(
                    n => n.PolicyId == policyId, true).ToList();
            CorpPolicyDetailConfigModel policyModel  = CorpPolicyConvertFactory.Convert(corpPolicyDetailConfigEntities);

            List<ChoiceReasonEntity> choiceReasonEntities =
                _choiceReasonDal.Query<ChoiceReasonEntity>(
                    n => n.IsDel != "T" && n.CorpID == corpId && n.PolicyType == policyType, true)
                    .ToList();

            if (choiceReasonEntities != null && choiceReasonEntities.Count > 0)
            {
                policyModel.PolicyReason = choiceReasonEntities.Select(n => n.Reason).ToList();
                policyModel.PolicyReasonList = (from n in choiceReasonEntities
                    select new ChoiceReasonModel()
                    {
                        Id = n.ID,
                        Reason = n.Reason,
                        PolicyType = n.PolicyType
                    }).ToList();
            }

            return policyModel;
        }

        public List<ChoiceReasonModel> GetCorpReasonByCorpId(string corpId)
        {
            if (string.IsNullOrEmpty(corpId))
                return null;
            List<ChoiceReasonModel> resultList = new List<ChoiceReasonModel>();
            List<ChoiceReasonEntity> choiceReasonEntities =
              _choiceReasonDal.Query<ChoiceReasonEntity>(
                  n => n.IsDel != "T" && n.CorpID == corpId, true).ToList();
            if (choiceReasonEntities != null && choiceReasonEntities.Count > 0)
            {
                resultList = (from n in choiceReasonEntities
                    select new ChoiceReasonModel()
                    {
                        Id = n.ID,
                        Reason = n.Reason,
                        PolicyType = n.PolicyType
                    }).ToList();
            }

            return resultList;
        }

        
    }
}
