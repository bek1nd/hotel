using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mzl.DomainModel.Customer.CorpAduit;
using Mzl.DomainModel.Customer.CorpPolicy;
using Mzl.EntityModel.Customer.BaseInfo;
using Mzl.EntityModel.Customer.Corporation.CorpAudit;
using Mzl.EntityModel.Customer.Corporation.CorpPolicy;
using Mzl.Framework.Base;
using Mzl.IBLL.Customer.CorpAduit;
using Mzl.IDAL.Customer.Corporation;
using Mzl.IDAL.Customer.Customer;

namespace Mzl.BLL.Customer.CorpAduit
{
    internal class GetCorpAduitCustomerServiceBll : BaseServiceBll, IGetCorpAduitCustomerServiceBll
    {
        private readonly ICorpAduitConfigDepartmentDal _corpAduitConfigDepartmentDal;
        private readonly ICustomerDal _customerDal;
        private readonly ICorpAduitConfigCustomerDal _corpAduitConfigCustomerDal;

        public GetCorpAduitCustomerServiceBll(ICorpAduitConfigDepartmentDal corpAduitConfigDepartmentDal,
            ICorpAduitConfigCustomerDal corpAduitConfigCustomerDal, ICustomerDal customerDal)
        {
            _corpAduitConfigDepartmentDal = corpAduitConfigDepartmentDal;
            _corpAduitConfigCustomerDal = corpAduitConfigCustomerDal;
            _customerDal = customerDal;
        }

        public List<CorpAduitCustomerModel> GetCorpAduitCustomer(string corpId, int aduitId)
        {

            List<CorpAduitCustomerModel> corpAduitCustomerModels = new List<CorpAduitCustomerModel>();

            //根据审批规则Id从部门关联表中获取对应的部门Id
            List<CorpAduitConfigDepartmentEntity> configDepartmentEntities =
                _corpAduitConfigDepartmentDal.Query<CorpAduitConfigDepartmentEntity>(n => n.AduitId == aduitId, true)
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


            //根据审批规则Id获取对应的客户id信息
            List<CorpAduitConfigCustomerEntity> corpAduitConfigCustomerEntities =
                _corpAduitConfigCustomerDal.Query<CorpAduitConfigCustomerEntity>(
                    n => n.AduitId == aduitId, true).ToList();
            //排除已经删除的规则
            List<CorpAduitConfigCustomerEntity> corpAduitConfigCustomerEntities2 =
                (from c in base.Context.Set<CorpAduitConfigCustomerEntity>()
                    join a in Context.Set<CorpAduitConfigEntity>() on c.AduitId equals a.ConfigId
                    where a.IsDel == 0 && c.AduitId != aduitId
                    select c).ToList();


            foreach (var customerInfoEntity in customerInfoEntities)
            {
                if (corpAduitConfigCustomerEntities2.Find(n => n.Cid == customerInfoEntity.Cid) != null)
                {
                    continue;
                }

                CorpAduitConfigCustomerEntity configCustomerEntity =
                    corpAduitConfigCustomerEntities.Find(n => n.Cid == customerInfoEntity.Cid);

                corpAduitCustomerModels.Add(new CorpAduitCustomerModel()
                {
                    Cid = customerInfoEntity.Cid,
                    CustomerName = customerInfoEntity.RealName,
                    DepartmentName = customerInfoEntity.DepartmentName,
                    IsHasAduit = (configCustomerEntity != null)
                });
            }
            corpAduitCustomerModels = corpAduitCustomerModels.OrderBy(n => n.DepartmentName).ToList();
            return corpAduitCustomerModels;
        }
    }
}
