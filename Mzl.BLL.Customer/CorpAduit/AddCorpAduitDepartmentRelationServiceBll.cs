using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mzl.DomainModel.Customer.CorpAduit;
using Mzl.EntityModel.Customer.Corporation.CorpAudit;
using Mzl.EntityModel.Customer.Corporation.CorpPolicy;
using Mzl.Framework.Base;
using Mzl.IBLL.Customer.CorpAduit;
using Mzl.IDAL.Customer.Corporation;

namespace Mzl.BLL.Customer.CorpAduit
{
    internal class AddCorpAduitDepartmentRelationServiceBll : BaseServiceBll, IAddCorpAduitDepartmentRelationServiceBll
    {
        private readonly ICorpAduitConfigDepartmentDal _corpAduitConfigDepartmentDal;
        private readonly ICorpAduitConfigCustomerDal _corpAduitConfigCustomerDal;

        public AddCorpAduitDepartmentRelationServiceBll(ICorpAduitConfigDepartmentDal corpAduitConfigDepartmentDal, ICorpAduitConfigCustomerDal corpAduitConfigCustomerDal)
        {
            _corpAduitConfigDepartmentDal = corpAduitConfigDepartmentDal;
            _corpAduitConfigCustomerDal = corpAduitConfigCustomerDal;
        }

        public bool AddCorpAduitDepartmentRelation(CorpAduitConfigDepartmentModel model)
        {
            List<CorpAduitConfigDepartmentEntity> configDepartmentEntities =
                _corpAduitConfigDepartmentDal.Query<CorpAduitConfigDepartmentEntity>(n => n.AduitId == model.AduitId)
                    .ToList();
            bool isClearAll = (model.DepartmentIdList.Find(n => n.Value == true) == null);//是否清空所有关系
            if (!isClearAll)
            {

                foreach (var departKeyValue in model.DepartmentIdList)
                {
                    var configDepartment = configDepartmentEntities.Find(n => n.DepartmentId == departKeyValue.Key);

                    if (configDepartment == null && departKeyValue.Value)//不存在关系，并且勾选了部门
                    {
                        //新增
                        _corpAduitConfigDepartmentDal.Insert<CorpAduitConfigDepartmentEntity>(new CorpAduitConfigDepartmentEntity()
                        {
                            DepartmentId = departKeyValue.Key,
                            AduitId = model.AduitId
                        });
                    }

                    if (configDepartment != null && !departKeyValue.Value)//存在关系，并且不选部门
                    {
                        //删除部门关系
                        _corpAduitConfigDepartmentDal.Delete<CorpAduitConfigDepartmentEntity>(configDepartment.Id);
                        //删除员工关系
                        List<CorpAduitConfigCustomerEntity> corpAduitConfigCustomerEntities =
                            _corpAduitConfigDepartmentDal.Query<CorpAduitConfigCustomerEntity>(
                                n => n.AduitId == model.AduitId, true).ToList();
                        if (corpAduitConfigCustomerEntities.Count > 0)
                        {
                            foreach (var entity in corpAduitConfigCustomerEntities)
                            {
                                _corpAduitConfigCustomerDal.Delete<CorpAduitConfigCustomerEntity>(entity.Id);
                            }
                        }

                    }
                }

            }
            else
            {
                if (configDepartmentEntities.Count > 0)
                {
                    foreach (var entity in configDepartmentEntities)
                    {
                        _corpAduitConfigDepartmentDal.Delete<CorpAduitConfigDepartmentEntity>(entity.Id);
                    }
                }

                //在清空与员工的关系
                List<CorpAduitConfigCustomerEntity> corpAduitConfigCustomerEntities =
                    _corpAduitConfigCustomerDal.Query<CorpAduitConfigCustomerEntity>(
                        n => n.AduitId == model.AduitId, true).ToList();
                if (corpAduitConfigCustomerEntities.Count > 0)
                {
                    foreach (var entity in corpAduitConfigCustomerEntities)
                    {
                        _corpAduitConfigCustomerDal.Delete<CorpAduitConfigCustomerEntity>(entity.Id);
                    }
                }
            }

            return true;
        }
    }
}
