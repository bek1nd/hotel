using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mzl.EntityModel.Customer.Corporation.CorpAudit;
using Mzl.Framework.Base;
using Mzl.IBLL.Customer.CorpAduit;
using Mzl.IDAL.Customer.Corporation;

namespace Mzl.BLL.Customer.CorpAduit
{
    internal class CheckAduitOrderServiceBll: BaseServiceBll,ICheckAduitOrderServiceBll
    {
        private readonly ICorpAduitOrderDetailDal _corpAduitOrderDetailDal;
        private readonly ICorpAduitOrderFlowDal _corpAduitOrderFlowDal;
        public CheckAduitOrderServiceBll(ICorpAduitOrderFlowDal corpAduitOrderFlowDal,
          ICorpAduitOrderDetailDal corpAduitOrderDetailDal)
        {
            _corpAduitOrderFlowDal = corpAduitOrderFlowDal;
            _corpAduitOrderDetailDal = corpAduitOrderDetailDal;
        }
        public bool CheckAduitCidHasOrderId(int cid, int orderId)
        {
            List<CorpAduitOrderDetailEntity> corpAduitOrderDetailEntities =
             _corpAduitOrderDetailDal.Query<CorpAduitOrderDetailEntity>(
                 n => n.OrderId == orderId, true).ToList();
            if (corpAduitOrderDetailEntities == null || corpAduitOrderDetailEntities.Count == 0)
            {
                return false;
            }
            List<int> aduitOrderIdList = new List<int>();
            corpAduitOrderDetailEntities.ForEach(n =>
            {
                aduitOrderIdList.Add(n.AduitOrderId);
            });

            int count =
                _corpAduitOrderFlowDal.Query<CorpAduitOrderFlowEntity>(
                    n => aduitOrderIdList.Contains(n.AduitOrderId) && n.FlowCid == cid, true).Count();
            if (count > 0)
                return true;
            return false;
        }
    }
}
