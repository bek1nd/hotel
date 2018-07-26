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
    internal class AddCorpAduitCustomerRelationServiceBll : BaseServiceBll, IAddCorpAduitCustomerRelationServiceBll
    {
        private readonly ICorpAduitConfigCustomerDal _corpAduitConfigCustomerDal;

        public AddCorpAduitCustomerRelationServiceBll(ICorpAduitConfigCustomerDal corpAduitConfigCustomerDal)
        {
            _corpAduitConfigCustomerDal = corpAduitConfigCustomerDal;
        }


        public bool AddCorpAduitCustomerRelation(CorpAduitConfigCustomerModel model)
        {
            //1.先清空所有关系
            List<CorpAduitConfigCustomerEntity> corpAduitConfigCustomerEntities =
                _corpAduitConfigCustomerDal.Query<CorpAduitConfigCustomerEntity>(n => n.AduitId == model.AduitId)
                    .ToList();
            if (corpAduitConfigCustomerEntities.Count > 0)
            {
                foreach (var entity in corpAduitConfigCustomerEntities)
                {
                    _corpAduitConfigCustomerDal.Delete<CorpAduitConfigCustomerEntity>(entity.Id);
                }
            }

            //2.在插入关联信息
            if (model.CidList != null && model.CidList.Count > 0)
            {
                foreach (int cid in model.CidList)
                {
                    _corpAduitConfigCustomerDal.Insert<CorpAduitConfigCustomerEntity>(new CorpAduitConfigCustomerEntity()
                    {
                        Cid = cid,
                        AduitId = model.AduitId
                    });
                }
            }

            return true;
        }
    }
}
