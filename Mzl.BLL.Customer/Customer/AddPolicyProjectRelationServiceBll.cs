using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mzl.DomainModel.Customer.CorpPolicy;
using Mzl.EntityModel.Customer.Corporation.CorpPolicy;
using Mzl.IBLL.Customer.Customer;
using Mzl.IDAL.Customer.Corporation;

namespace Mzl.BLL.Customer.Customer
{
    internal class AddPolicyProjectRelationServiceBll : IAddPolicyProjectRelationServiceBll
    {
        private readonly ICorpPolicyConfigProjectDal _corpPolicyConfigProjectDal;

        public AddPolicyProjectRelationServiceBll(ICorpPolicyConfigProjectDal corpPolicyConfigProjectDal)
        {
            _corpPolicyConfigProjectDal = corpPolicyConfigProjectDal;
        }

        public bool AddPolicyProjectRelation(CorpPolicyConfigProjectModel model)
        {
            List<CorpPolicyConfigProjectEntity> corpPolicyConfigProjectEntities =
                _corpPolicyConfigProjectDal.Query<CorpPolicyConfigProjectEntity>(
                    n => n.PolicyId == model.PolicyId, true)
                    .ToList();//根据政策id获取与项目成本中心的关系信息

            bool isClearAll = (model.ProjectIdList.Find(n => n.Value == true) == null);//是否清空所有关系
            if (!isClearAll)
            {
                foreach (var departKeyValue in model.ProjectIdList)
                {
                    var configProject = corpPolicyConfigProjectEntities.Find(n => n.ProjectId == departKeyValue.Key);
                    if (configProject == null && departKeyValue.Value)//不存在关系，并且勾选了部门
                    {
                        //新增
                        _corpPolicyConfigProjectDal.Insert(new CorpPolicyConfigProjectEntity()
                        {
                            ProjectId = departKeyValue.Key,
                            PolicyId = model.PolicyId
                        });
                    }

                    if (configProject != null && !departKeyValue.Value)//存在关系，并且不选部门
                    {
                        //删除部门关系
                        _corpPolicyConfigProjectDal.Delete<CorpPolicyConfigProjectEntity>(configProject.Id);
                    }

                }
            }
            else
            {
                if (corpPolicyConfigProjectEntities.Count > 0)
                {
                    //清空对应的关系
                    foreach (var entity in corpPolicyConfigProjectEntities)
                    {
                        _corpPolicyConfigProjectDal.Delete<CorpPolicyConfigProjectEntity>(entity.Id);
                    }
                }
            }

            return true;
        }
    }
}
