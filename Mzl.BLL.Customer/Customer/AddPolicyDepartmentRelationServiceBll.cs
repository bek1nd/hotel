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
    public class AddPolicyDepartmentRelationServiceBll : BaseServiceBll, IAddPolicyDepartmentRelationServiceBll
    {
        private readonly ICorpPolicyConfigDepartmentDal _corpPolicyConfigDepartmentDal;
        private readonly ICorpPolicyConfigCustomerDal _corpPolicyConfigCustomerDal;

        public AddPolicyDepartmentRelationServiceBll(ICorpPolicyConfigDepartmentDal corpPolicyConfigDepartmentDal,
            ICorpPolicyConfigCustomerDal corpPolicyConfigCustomerDal)
        {
            _corpPolicyConfigDepartmentDal = corpPolicyConfigDepartmentDal;
            _corpPolicyConfigCustomerDal = corpPolicyConfigCustomerDal;
        }

        public bool AddPolicyDepartmentRelation(CorpPolicyConfigDepartmentModel model)
        {
            List<CorpPolicyConfigDepartmentEntity> configDepartmentEntities =
                  _corpPolicyConfigDepartmentDal.Query<CorpPolicyConfigDepartmentEntity>(
                      n => n.PolicyId == model.PolicyId, true)
                      .ToList();//根据政策id获取与部门的关系信息

            bool isClearAll = (model.DepartmentIdList.Find(n => n.Value == true) == null);//是否清空所有关系
            if (!isClearAll)
            {
                foreach (var departKeyValue in model.DepartmentIdList)
                {
                    var configDepartment = configDepartmentEntities.Find(n => n.DepartmentId == departKeyValue.Key);

                    if (configDepartment == null&& departKeyValue.Value)//不存在关系，并且勾选了部门
                    {
                        //新增
                        _corpPolicyConfigDepartmentDal.Insert<CorpPolicyConfigDepartmentEntity>(new CorpPolicyConfigDepartmentEntity()
                        {
                            DepartmentId = departKeyValue.Key,
                            PolicyId = model.PolicyId
                        });
                    }

                    if (configDepartment!=null&& !departKeyValue.Value)//存在关系，并且不选部门
                    {
                        //删除部门关系
                        _corpPolicyConfigDepartmentDal.Delete<CorpPolicyConfigDepartmentEntity>(configDepartment.Id);
                        //删除员工关系
                        List<CorpPolicyConfigCustomerEntity> corpPolicyConfigCustomerEntities =
                            _corpPolicyConfigCustomerDal.Query<CorpPolicyConfigCustomerEntity>(
                                n => n.PolicyId == model.PolicyId, true).ToList();
                        if (corpPolicyConfigCustomerEntities.Count > 0)
                        {
                            foreach (var entity in corpPolicyConfigCustomerEntities)
                            {
                                _corpPolicyConfigCustomerDal.Delete<CorpPolicyConfigCustomerEntity>(entity.Id);
                            }
                        }

                    }
                }
            }
            else
            {
                //清空所有关系
                if (configDepartmentEntities.Count > 0)
                {
                    foreach (var entity in configDepartmentEntities)
                    {
                        _corpPolicyConfigDepartmentDal.Delete<CorpPolicyConfigDepartmentEntity>(entity.Id);
                    }
                }

                //在清空与员工的关系
                List<CorpPolicyConfigCustomerEntity> corpPolicyConfigCustomerEntities =
                    _corpPolicyConfigCustomerDal.Query<CorpPolicyConfigCustomerEntity>(
                        n => n.PolicyId == model.PolicyId, true).ToList();
                if (corpPolicyConfigCustomerEntities.Count > 0)
                {
                    foreach (var entity in corpPolicyConfigCustomerEntities)
                    {
                        _corpPolicyConfigCustomerDal.Delete<CorpPolicyConfigCustomerEntity>(entity.Id);
                    }
                }
            }
          

            return true;
        }
    }
}
