using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Mzl.EntityModel.Customer.Corporation.CorpAudit;
using Mzl.Framework.Base;
using Mzl.IBLL.Customer.CorpAduit;
using Mzl.IDAL.Customer.Corporation;

namespace Mzl.BLL.Customer.CorpAduit
{
    internal class CopyAduitOrderServiceBll: BaseServiceBll,ICopyAduitOrderServiceBll
    {
        private readonly ICorpAduitOrderDal _corpAduitOrderDal;
        private readonly ICorpAduitOrderDetailDal _corpAduitOrderDetailDal;
        private readonly ICorpAduitOrderFlowDal _corpAduitOrderFlowDal;
        private readonly ICorpAduitOrderLogDal _corpAduitOrderLogDal;
        public CopyAduitOrderServiceBll(ICorpAduitOrderDal corpAduitOrderDal,
          ICorpAduitOrderFlowDal corpAduitOrderFlowDal, ICorpAduitOrderLogDal corpAduitOrderLogDal,
          ICorpAduitOrderDetailDal corpAduitOrderDetailDal)
        {
            _corpAduitOrderDal = corpAduitOrderDal;
            _corpAduitOrderFlowDal = corpAduitOrderFlowDal;
            _corpAduitOrderLogDal = corpAduitOrderLogDal;
            _corpAduitOrderDetailDal = corpAduitOrderDetailDal;
        }
        public int Copy(int copyFromOrderId, int newOrderId)
        {
            CorpAduitOrderDetailEntity copyAduitOrderDetailEntity =
                _corpAduitOrderDetailDal.Query<CorpAduitOrderDetailEntity>(
                    n => n.OrderId == copyFromOrderId, true).FirstOrDefault();

            if (copyAduitOrderDetailEntity != null)
            {
                #region 获取原始审批单
                CorpAduitOrderEntity copyCorpAduitOrderEntity =
                            _corpAduitOrderDal.Find<CorpAduitOrderEntity>(copyAduitOrderDetailEntity.AduitOrderId);

                List<CorpAduitOrderDetailEntity> copyCorpAduitOrderDetailEntities =
                    _corpAduitOrderDetailDal.Query<CorpAduitOrderDetailEntity>(
                        n => n.AduitOrderId == copyCorpAduitOrderEntity.AduitOrderId, true).ToList();

                List<CorpAduitOrderFlowEntity> copyCorpAduitOrderFlowEntities =
                    _corpAduitOrderFlowDal.Query<CorpAduitOrderFlowEntity>(
                        n => n.AduitOrderId == copyCorpAduitOrderEntity.AduitOrderId, true).ToList();

                List<CorpAduitOrderLogEntity> copyCorpAduitOrderLogEntities =
                    _corpAduitOrderLogDal.Query<CorpAduitOrderLogEntity>(
                        n => n.AduitOrderId == copyCorpAduitOrderEntity.AduitOrderId, true).ToList();
                #endregion

                #region 复制原始审批单
                CorpAduitOrderEntity corpAduitOrderEntity =
                           Mapper.Map<CorpAduitOrderEntity, CorpAduitOrderEntity>(copyCorpAduitOrderEntity);
                corpAduitOrderEntity = _corpAduitOrderDal.Insert(corpAduitOrderEntity);

                List<CorpAduitOrderDetailEntity> corpAduitOrderDetailEntities =
                    Mapper.Map<List<CorpAduitOrderDetailEntity>, List<CorpAduitOrderDetailEntity>>(
                        copyCorpAduitOrderDetailEntities);
                foreach (var corpAduitOrderDetailEntity in corpAduitOrderDetailEntities)
                {
                    corpAduitOrderDetailEntity.AduitOrderId = corpAduitOrderEntity.AduitOrderId;
                    corpAduitOrderDetailEntity.OrderId = newOrderId;
                    _corpAduitOrderDetailDal.Insert(corpAduitOrderDetailEntity);
                }

                List<CorpAduitOrderFlowEntity> corpAduitOrderFlowEntities =
                    Mapper.Map<List<CorpAduitOrderFlowEntity>, List<CorpAduitOrderFlowEntity>>(
                        copyCorpAduitOrderFlowEntities);
                foreach (var corpAduitOrderFlowEntity in corpAduitOrderFlowEntities)
                {
                    corpAduitOrderFlowEntity.AduitOrderId = corpAduitOrderEntity.AduitOrderId;
                    _corpAduitOrderFlowDal.Insert(corpAduitOrderFlowEntity);
                }

                List<CorpAduitOrderLogEntity> corpAduitOrderLogEntities =
                  Mapper.Map<List<CorpAduitOrderLogEntity>, List<CorpAduitOrderLogEntity>>(
                      copyCorpAduitOrderLogEntities);
                foreach (var corpAduitOrderLogEntity in corpAduitOrderLogEntities)
                {
                    corpAduitOrderLogEntity.AduitOrderId = corpAduitOrderEntity.AduitOrderId;
                    _corpAduitOrderLogDal.Insert(corpAduitOrderLogEntity);
                } 
                #endregion

                return corpAduitOrderEntity.AduitOrderId;
            }

            return 0;
        }

       
    }
}
