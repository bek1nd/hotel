using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mzl.DomainModel.Customer.CorpAduit;
using Mzl.EntityModel.Customer.Corporation.CorpAudit;
using Mzl.Framework.Base;
using Mzl.IBLL.Customer.Customer;
using Mzl.IDAL.Customer.Corporation;

namespace Mzl.BLL.Customer.Customer
{
    internal class AddCorpAduitProjectRelationServiceBll: BaseServiceBll,IAddCorpAduitProjectRelationServiceBll
    {
        private readonly ICorpAduitConfigProjectDal _corpAduitConfigProjectDal;

        public AddCorpAduitProjectRelationServiceBll(ICorpAduitConfigProjectDal corpAduitConfigProjectDal)
        {
            _corpAduitConfigProjectDal = corpAduitConfigProjectDal;
        }

        public bool AddCorpAduitProjectRelation(CorpAduitConfigProjectModel model)
        {
            List<CorpAduitConfigProjectEntity> corpAduitConfigProjectEntities =
                _corpAduitConfigProjectDal.Query<CorpAduitConfigProjectEntity>(n => n.AduitId == model.AduitId)
                    .ToList();

            bool isClearAll = (model.ProjectIdList.Find(n => n.Value == true) == null);//是否清空所有关系
            if (!isClearAll)
            {
                foreach (var departKeyValue in model.ProjectIdList)
                {
                    var configProject = corpAduitConfigProjectEntities.Find(n => n.ProjectId == departKeyValue.Key);
                    if (configProject == null && departKeyValue.Value)//不存在关系，并且勾选了部门
                    {
                        //新增
                        _corpAduitConfigProjectDal.Insert<CorpAduitConfigProjectEntity>(new CorpAduitConfigProjectEntity()
                        {
                            ProjectId = departKeyValue.Key,
                            AduitId = model.AduitId
                        });
                    }

                    if (configProject != null && !departKeyValue.Value)//存在关系，并且不选项目中心
                    {
                        //删除关系
                        _corpAduitConfigProjectDal.Delete<CorpAduitConfigProjectEntity>(configProject.Id);
                    }

                }
            }
            else
            {
                if (corpAduitConfigProjectEntities.Count > 0)
                {
                    foreach (var entity in corpAduitConfigProjectEntities)
                    {
                        _corpAduitConfigProjectDal.Delete<CorpAduitConfigProjectEntity>(entity.Id);
                    }
                }
            }

            return true;
        }
    }
}
