using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Mzl.DomainModel.Customer.Base;
using Mzl.DomainModel.Customer.CorpAduit;
using Mzl.EntityModel.Customer.Corporation.CorpAudit;
using Mzl.Framework.Base;
using Mzl.IBLL.Customer.CorpAduit;
using Mzl.IBLL.Customer.Customer;
using Mzl.IDAL.Customer.Corporation;

namespace Mzl.BLL.Customer.CorpAduit
{
    internal class GetCorpAduitOrderServiceBll : BaseServiceBll, IGetCorpAduitOrderServiceBll
    {
        private readonly ICorpAduitOrderDal _corpAduitOrderDal;
        private readonly ICorpAduitOrderDetailDal _corpAduitOrderDetailDal;
        private readonly ICorpAduitOrderFlowDal _corpAduitOrderFlowDal;
        private readonly ICorpAduitOrderLogDal _corpAduitOrderLogDal;
        private readonly IGetCustomerBll _getCustomerBll;

        public GetCorpAduitOrderServiceBll(ICorpAduitOrderDal corpAduitOrderDal,
           ICorpAduitOrderFlowDal corpAduitOrderFlowDal, ICorpAduitOrderLogDal corpAduitOrderLogDal,
           ICorpAduitOrderDetailDal corpAduitOrderDetailDal, IGetCustomerBll getCustomerBll)
        {
            _corpAduitOrderDal = corpAduitOrderDal;
            _corpAduitOrderFlowDal = corpAduitOrderFlowDal;
            _corpAduitOrderLogDal = corpAduitOrderLogDal;
            _corpAduitOrderDetailDal = corpAduitOrderDetailDal;
            _getCustomerBll = getCustomerBll;
        }


        public CorpAduitOrderInfoModel GetAduitOrderInfoById(int aduitOrderId)
        {
            CorpAduitOrderEntity corpAduitOrderEntity = _corpAduitOrderDal.Find<CorpAduitOrderEntity>(aduitOrderId);

            CorpAduitOrderInfoModel corpAduitOrderInfoModel =
                Mapper.Map<CorpAduitOrderEntity, CorpAduitOrderInfoModel>(corpAduitOrderEntity);

            //审批单与订单关联信息
            List<CorpAduitOrderDetailEntity> corpAduitOrderDetailEntities =
                _corpAduitOrderDetailDal.Query<CorpAduitOrderDetailEntity>(
                    n => n.AduitOrderId == corpAduitOrderEntity.AduitOrderId, true).ToList();
            corpAduitOrderInfoModel.OrderDetailList =
                Mapper.Map<List<CorpAduitOrderDetailEntity>, List<CorpAduitOrderDetailModel>>(
                    corpAduitOrderDetailEntities);
            //审批环节信息
            List<CorpAduitOrderFlowEntity> corpAduitOrderFlowEntities =
                _corpAduitOrderFlowDal.Query<CorpAduitOrderFlowEntity>(
                    n => n.AduitOrderId == corpAduitOrderEntity.AduitOrderId, true).ToList();
            corpAduitOrderInfoModel.FlowList=
                  Mapper.Map<List<CorpAduitOrderFlowEntity>, List<CorpAduitOrderFlowModel>>(
                    corpAduitOrderFlowEntities);
            //审批日志信息
            List<CorpAduitOrderLogEntity> corpAduitOrderLogEntities =
                _corpAduitOrderLogDal.Query<CorpAduitOrderLogEntity>(
                    n => n.AduitOrderId == corpAduitOrderEntity.AduitOrderId, true).ToList();
            corpAduitOrderInfoModel.LogList=
                    Mapper.Map<List<CorpAduitOrderLogEntity>, List<CorpAduitOrderLogModel>>(
                    corpAduitOrderLogEntities);

            List<CustomerModel> customerModels =
                _getCustomerBll.GetCustomerByCidList(corpAduitOrderInfoModel.AduitCidList);

            if (corpAduitOrderInfoModel.FlowList != null && corpAduitOrderInfoModel.FlowList.Count > 0)
            {
                corpAduitOrderInfoModel.FlowList.ForEach(n =>
                {
                    n.FlowCustomerName = customerModels?.Find(x => x.Cid == n.FlowCid)?.RealName;
                });
            }
            

            if (corpAduitOrderInfoModel.LogList != null && corpAduitOrderInfoModel.LogList.Count > 0)
            {
                corpAduitOrderInfoModel.LogList.ForEach(n =>
                {
                    if (n.DealCid.HasValue)
                        n.DealCustomerName = customerModels?.Find(x => x.Cid == n.DealCid.Value)?.RealName;
                });
            }

            return corpAduitOrderInfoModel;
        }

        public List<CorpAduitOrderInfoModel> GetAduitOrderInfoByOrderId(int orderId)
        {
            List<CorpAduitOrderDetailEntity> corpAduitOrderDetailEntities =
               _corpAduitOrderDetailDal.Query<CorpAduitOrderDetailEntity>(
                   n => n.OrderId == orderId, true).ToList();
            if (corpAduitOrderDetailEntities == null || corpAduitOrderDetailEntities.Count == 0)
            {
                return null;
            }
            List<int> aduitOrderIdList = new List<int>();
            corpAduitOrderDetailEntities.ForEach(n =>
            {
                aduitOrderIdList.Add(n.AduitOrderId);
            });

            List<CorpAduitOrderInfoModel> list = new List<CorpAduitOrderInfoModel>();
            foreach (var aduitOrderId in aduitOrderIdList)
            {
                list.Add(GetAduitOrderInfoById(aduitOrderId));
            }
            return list;
        }

        public List<CorpAduitOrderInfoModel> GetAduitOrderInfoByOrderIds(List<int> orderIdList)
        {
            List<CorpAduitOrderDetailEntity> corpAduitOrderDetailEntities =
                _corpAduitOrderDetailDal.Query<CorpAduitOrderDetailEntity>(
                    n => orderIdList.Contains(n.OrderId), true).ToList();
            if (corpAduitOrderDetailEntities == null || corpAduitOrderDetailEntities.Count == 0)
            {
                return null;
            }
            List<int> aduitOrderIdList = new List<int>();
            corpAduitOrderDetailEntities.ForEach(n =>
            {
                aduitOrderIdList.Add(n.AduitOrderId);
            });

            List<CorpAduitOrderInfoModel> list = new List<CorpAduitOrderInfoModel>();
            foreach (var aduitOrderId in aduitOrderIdList)
            {
                list.Add(GetAduitOrderInfoById(aduitOrderId));
            }
            return list;
        }
    }
}
