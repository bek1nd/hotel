using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mzl.Common.EnumHelper;
using Mzl.Common.EnumHelper.CorpAduit;
using Mzl.DomainModel.Common.AuditOrder;
using Mzl.DomainModel.Customer.Base;
using Mzl.Framework.Base;
using Mzl.IBLL.Customer.CorpAduit;
using Mzl.IDAL.Customer.Corporation;
using Mzl.EntityModel.Customer.Corporation.CorpAudit;

namespace Mzl.BLL.Customer.CorpAduit
{
    internal class GetCorpAduitOrderListServiceBll: BaseServiceBll,IGetCorpAduitOrderListServiceBll
    {
        private readonly ICorpAduitOrderDal _corpAduitOrderDal;
        private readonly ICorpAduitOrderDetailDal _corpAduitOrderDetailDal;
        private readonly ICorpAduitOrderFlowDal _corpAduitOrderFlowDal;
        private readonly ICorpAduitOrderLogDal _corpAduitOrderLogDal;

        public GetCorpAduitOrderListServiceBll(ICorpAduitOrderDal corpAduitOrderDal,
            ICorpAduitOrderFlowDal corpAduitOrderFlowDal, ICorpAduitOrderLogDal corpAduitOrderLogDal,
            ICorpAduitOrderDetailDal corpAduitOrderDetailDal)
        {
            _corpAduitOrderDal = corpAduitOrderDal;
            _corpAduitOrderFlowDal = corpAduitOrderFlowDal;
            _corpAduitOrderLogDal = corpAduitOrderLogDal;
            _corpAduitOrderDetailDal = corpAduitOrderDetailDal;
        }


        /// <summary>
        /// 获取待审批信息
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        public AuditOrderListModel GetWaitCorpAduitOrderList(AuditOrderListQueryModel query)
        {
            AuditOrderListModel resultModel = new AuditOrderListModel();

            #region 分页查询
            var select = from aduitOrder in Context.Set<CorpAduitOrderEntity>().AsNoTracking()
                         join
                             flow in Context.Set<CorpAduitOrderFlowEntity>().AsNoTracking()
                             on new { AduitOrderId = aduitOrder.AduitOrderId, CurrentFlow = aduitOrder.CurrentFlow } equals
                             new { AduitOrderId = flow.AduitOrderId, CurrentFlow = flow.Flow }
                             into a
                         from flow in a.DefaultIfEmpty()
                         where aduitOrder.CurrentFlow > 0 && flow.FlowCid == query.AuditCid && !flow.DealResult.HasValue
                         && aduitOrder.Status != 7&& aduitOrder.Status != 6 && (aduitOrder.IsDel ?? 0) ==0
                         select new AuditOrderListDataModel()
                         {
                             Id = aduitOrder.AduitOrderId,
                             AuditStatusInt = aduitOrder.Status,
                             CurrentAuditCid = flow.FlowCid,
                             CreateTime = aduitOrder.CreateTime,
                             CurrentFlow= aduitOrder.CurrentFlow
                         };

            if (query.AllowShowDataBeginTime.HasValue)
            {
                select = select.Where(n => n.CreateTime > query.AllowShowDataBeginTime.Value);
            }

            resultModel.TotalCount = select.Count();//查询所有结果的数量
            select =
                select.OrderByDescending(n => n.CreateTime).Skip(query.PageSize * (query.PageIndex - 1)).Take(query.PageSize);
            resultModel.DataList = select.ToList();//分页结果  
            if (resultModel.DataList == null || resultModel.DataList.Count == 0)
                return resultModel;

            #endregion

            List<int> aduitOrderIdList = new List<int>();
            resultModel.DataList.ForEach(n =>
            {
                aduitOrderIdList.Add(n.Id);
            });

            List<CorpAduitOrderDetailEntity> corpAduitOrderDetailEntities =
                _corpAduitOrderDetailDal.Query<CorpAduitOrderDetailEntity>(
                    n => aduitOrderIdList.Contains(n.AduitOrderId),
                    true).ToList();

            List<AuditOrderDetailModel> auditOrderDetailModels = new List<AuditOrderDetailModel>();
            foreach (var detail in corpAduitOrderDetailEntities)
            {
                AuditOrderDetailModel model = new AuditOrderDetailModel()
                {
                    OrderId = detail.OrderId,
                    Id = detail.AduitOrderId,
                    OrderType = detail.OrderType.ValueToEnum<OrderSourceTypeEnum>()
                };
                auditOrderDetailModels.Add(model);
            }

            foreach (var aduitOrder in resultModel.DataList)
            {
                aduitOrder.DetailList = auditOrderDetailModels.FindAll(n => n.Id == aduitOrder.Id);
            }

            return resultModel;
        }
        /// <summary>
        /// 获取已通过的审批信息
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        public AuditOrderListModel GetPassCorpAduitOrderList(AuditOrderListQueryModel query)
        {
            AuditOrderListModel resultModel = new AuditOrderListModel();
            #region 分页查询
            var select = from log in Context.Set<CorpAduitOrderLogEntity>().AsNoTracking()
                         join
                             aduitOrder in Context.Set<CorpAduitOrderEntity>().AsNoTracking()
                             on log.AduitOrderId equals aduitOrder.AduitOrderId
                             into a
                         from aduitOrder in a.DefaultIfEmpty()
                         where log.AduitFlow > 0 && log.DealCid == query.AuditCid && log.DealResult==1
                          && (aduitOrder.IsDel ?? 0) == 0
                         select new AuditOrderListDataModel()
                         {
                             Id = aduitOrder.AduitOrderId,
                             AuditStatusInt = aduitOrder.Status,
                             CreateTime = log.LogTime,
                             CurrentFlow = aduitOrder.CurrentFlow
                         };
            if (query.AllowShowDataBeginTime.HasValue)
            {
                select = select.Where(n => n.CreateTime > query.AllowShowDataBeginTime.Value);
            }
            resultModel.TotalCount = select.Count();//查询所有结果的数量
            select =
                select.OrderByDescending(n => n.CreateTime).Skip(query.PageSize * (query.PageIndex - 1)).Take(query.PageSize);
            resultModel.DataList = select.ToList();//分页结果  
            if (resultModel.DataList == null || resultModel.DataList.Count == 0)
                return resultModel;

            #endregion

            List<int> aduitOrderIdList = new List<int>();
            resultModel.DataList.ForEach(n =>
            {
                aduitOrderIdList.Add(n.Id);
            });

            List<CorpAduitOrderDetailEntity> corpAduitOrderDetailEntities =
                _corpAduitOrderDetailDal.Query<CorpAduitOrderDetailEntity>(
                    n => aduitOrderIdList.Contains(n.AduitOrderId),
                    true).ToList();

            List<AuditOrderDetailModel> auditOrderDetailModels = new List<AuditOrderDetailModel>();
            foreach (var detail in corpAduitOrderDetailEntities)
            {
                AuditOrderDetailModel model = new AuditOrderDetailModel()
                {
                    OrderId = detail.OrderId,
                    Id = detail.AduitOrderId,
                    OrderType = detail.OrderType.ValueToEnum<OrderSourceTypeEnum>()
                };
                auditOrderDetailModels.Add(model);
            }

            foreach (var aduitOrder in resultModel.DataList)
            {
                aduitOrder.DetailList = auditOrderDetailModels.FindAll(n => n.Id == aduitOrder.Id);
            }
            return resultModel;
        }

        /// <summary>
        /// 获取已拒绝的审批信息
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        public AuditOrderListModel GetNoPassCorpAduitOrderList(AuditOrderListQueryModel query)
        {
            AuditOrderListModel resultModel = new AuditOrderListModel();
            #region 分页查询
            var select = from log in Context.Set<CorpAduitOrderLogEntity>().AsNoTracking()
                         join
                             aduitOrder in Context.Set<CorpAduitOrderEntity>().AsNoTracking()
                             on log.AduitOrderId equals aduitOrder.AduitOrderId
                             into a
                         from aduitOrder in a.DefaultIfEmpty()
                         where log.AduitFlow > 0 && log.DealCid == query.AuditCid && log.DealResult == 2
                          && (aduitOrder.IsDel ?? 0) == 0
                         select new AuditOrderListDataModel()
                         {
                             Id = aduitOrder.AduitOrderId,
                             AuditStatusInt = aduitOrder.Status,
                             CreateTime = log.LogTime,
                             CurrentFlow = aduitOrder.CurrentFlow
                         };
            if (query.AllowShowDataBeginTime.HasValue)
            {
                select = select.Where(n => n.CreateTime > query.AllowShowDataBeginTime.Value);
            }
            resultModel.TotalCount = select.Count();//查询所有结果的数量
            select =
                select.OrderByDescending(n => n.CreateTime).Skip(query.PageSize * (query.PageIndex - 1)).Take(query.PageSize);
            resultModel.DataList = select.ToList();//分页结果  
            if (resultModel.DataList == null || resultModel.DataList.Count == 0)
                return resultModel;

            #endregion

            List<int> aduitOrderIdList = new List<int>();
            resultModel.DataList.ForEach(n =>
            {
                aduitOrderIdList.Add(n.Id);
            });

            List<CorpAduitOrderDetailEntity> corpAduitOrderDetailEntities =
                _corpAduitOrderDetailDal.Query<CorpAduitOrderDetailEntity>(
                    n => aduitOrderIdList.Contains(n.AduitOrderId),
                    true).ToList();

            List<AuditOrderDetailModel> auditOrderDetailModels = new List<AuditOrderDetailModel>();
            foreach (var detail in corpAduitOrderDetailEntities)
            {
                AuditOrderDetailModel model = new AuditOrderDetailModel()
                {
                    OrderId = detail.OrderId,
                    Id = detail.AduitOrderId,
                    OrderType = detail.OrderType.ValueToEnum<OrderSourceTypeEnum>()
                };
                auditOrderDetailModels.Add(model);
            }

            foreach (var aduitOrder in resultModel.DataList)
            {
                aduitOrder.DetailList = auditOrderDetailModels.FindAll(n => n.Id == aduitOrder.Id);
            }
            return resultModel;
        }
    }
}
