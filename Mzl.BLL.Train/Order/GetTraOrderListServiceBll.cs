using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mzl.DomainModel.Train.Order;
using Mzl.EntityModel.Customer.BaseInfo;
using Mzl.EntityModel.Flight;
using Mzl.Framework.Base;
using Mzl.IBLL.Train.Order;
using Mzl.EntityModel.Train.Order;
using Mzl.EntityModel.Train.Server;
using AutoMapper;
using Mzl.IDAL.Train;


namespace Mzl.BLL.Train.Order
{
    internal class GetTraOrderListServiceBll: BaseServiceBll,IGetTraOrderListServiceBll
    {
        private readonly ITraPassengerDal _traPassengerDal;
        private readonly ITraOrderStatusDal _traOrderStatusDal;
        private readonly ITraOrderDetailDal _traOrderDetailDal;

        public GetTraOrderListServiceBll(ITraPassengerDal traPassengerDal, ITraOrderStatusDal traOrderStatusDal,
            ITraOrderDetailDal traOrderDetailDal)
        {
            _traPassengerDal = traPassengerDal;
            _traOrderStatusDal = traOrderStatusDal;
            _traOrderDetailDal = traOrderDetailDal;
        }

        public TraOrderResultListModel GetTraOrderList(TraOrderListQueryModel query)
        {
            #region 查询主体

            var select = from order in base.Context.Set<TraOrderEntity>().AsNoTracking()
                join orderStatus in base.Context.Set<TraOrderStatusEntity>().AsNoTracking() on order.OrderId equals
                    orderStatus.OrderId into os
                from orderStatus in os.DefaultIfEmpty()
                join customer in Context.Set<CustomerInfoEntity>().AsNoTracking() on order.Cid equals customer.Cid into
                    c
                from customer in c.DefaultIfEmpty()
                join traInterFaceOrder in Context.Set<TraInterFaceOrderEntity>().AsNoTracking() on
                    order.OrderId.ToString() equals
                    traInterFaceOrder.OrderId into tf
                from traInterFaceOrder in tf.DefaultIfEmpty()
                select new TraOrderListDataModel()
                {
                    OrderId = order.OrderId,
                    CostCenter = order.CostCenter,
                    ProjectId = order.ProjectId,
                    CreateTime = order.CreateTime,
                    TotalMoney = order.TotalMoney,
                    CorpId = customer.CorpID,
                    Cid = customer.Cid,
                    IsCancle = orderStatus.IsCancle,
                    InterfaceOrderStatus = (traInterFaceOrder == null ? -1 : traInterFaceOrder.Status),
                    InterfaceOrderId = (traInterFaceOrder == null ? -1 : traInterFaceOrder.InterfaceId),
                    OrderType = order.OrderType,
                    NumberIdentity = order.NumberIdentity,
                    OrderRoot = order.OrderRoot ?? 0,
                    ProcessStatus = orderStatus.ProccessStatus
                };
            select = select.Where(n => n.OrderType == query.OrderType && n.IsCancle == 0);
            var nowDate = DateTime.Now.AddMinutes(-20);
            var status =
                Context.Set<TraInterFaceOrderEntity>()
                    .AsNoTracking()
                    .Where(n => n.Status == 2 && n.CreateTime < nowDate)
                    .Select(n => n.InterfaceId);
            if (status.Any())
            {
                select = select.Where(n => !status.Contains(n.InterfaceOrderId));
            }

            #endregion

            #region 查询条件

            if (query.OrderStatus.HasValue)
            {
                if (query.OrderStatus == 4)
                {
                    select = select.Where(n => (n.ProcessStatus & 1) == 1);
                }
                else if (query.OrderStatus == 9)
                {
                    select = select.Where(n => (n.ProcessStatus & 1) == 1);
                }
                else if (query.OrderStatus == -1)
                {
                    select = select.Where(n => (n.ProcessStatus & 1) != 1 && n.InterfaceOrderStatus == -1);
                }
                else
                {
                    select = select.Where(n => n.InterfaceOrderStatus == query.OrderStatus.Value);
                }
            }

            if (!string.IsNullOrEmpty(query.RefundOrderId))
            {
                select = select.Where(n => query.RefundOrderId.Contains(n.OrderRoot.ToString()));
            }

            if (query.OrderId.HasValue) //订单号
            {
                select = select.Where(n => n.OrderId == query.OrderId.Value);
            }
            if (query.OrderBeginTime.HasValue) //订单开始时间
            {
                select = select.Where(n => n.CreateTime >= query.OrderBeginTime.Value);
            }
            if (query.OrderEndTime.HasValue) //订单结束时间
            {
                DateTime dd = query.OrderEndTime.Value.AddDays(1);
                select = select.Where(n => n.CreateTime < dd);
            }
            if (query.TravelBeginTime.HasValue) //行程开始时间
            {
                select =
                    select.Where(
                        n =>
                            Context.Set<TraOrderDetailEntity>()
                                .AsNoTracking()
                                .Where(m => m.StartTime >= query.TravelBeginTime.Value)
                                .Select(m => m.OrderId).Contains(n.OrderId));
            }
            if (query.TravelEndTime.HasValue) //行程结束时间
            {
                DateTime dd = query.TravelEndTime.Value.AddDays(1);
                select = select.Where(n => Context.Set<TraOrderDetailEntity>().AsNoTracking().Where(m => m.EndTime < dd)
                    .Select(m => m.OrderId).Contains(n.OrderId));
            }

            if (!string.IsNullOrEmpty(query.PassengerName)) //乘机人
            {
                var p =
                    Context.Set<TraPassengerEntity>()
                        .AsNoTracking()
                        .Where(k => k.Name.Contains(query.PassengerName))
                        .Select(k => k.OdId);
                select =
                    select.Where(
                        n =>
                            Context.Set<TraOrderDetailEntity>().AsNoTracking().Where(m => p.Contains(m.OdId))
                                .Select(m => m.OrderId)
                                .Contains(n.OrderId));
            }


            if (!string.IsNullOrEmpty(query.CostCenter)) //成本中心
            {
                select = select.Where(n => n.CostCenter.Contains(query.CostCenter));
            }

            if (query.ProjectId.HasValue) //项目名称
            {
                select = select.Where(n => n.ProjectId == query.ProjectId);
            }

            if (query.Cid.HasValue && !string.IsNullOrEmpty(query.UserId) && query.UserId.ToLower() != "administrator")
            {
                select = select.Where(n => n.Cid == query.Cid.Value);
            }
            if (!string.IsNullOrEmpty(query.UserId) && query.UserId.ToLower() == "administrator" &&
                !string.IsNullOrEmpty(query.CorpId))
            {
                select = select.Where(n => n.CorpId.ToUpper() == query.CorpId.ToUpper());
            }

            #endregion

            TraOrderResultListModel result = new TraOrderResultListModel();
            result.TotalCount = select.Count();
            select =
                select.OrderByDescending(n => n.OrderId).Skip(query.PageSize*(query.PageIndex - 1)).Take(query.PageSize);
            result.ListData = select.ToList();//分页结果 
            if (result.ListData == null || result.ListData.Count == 0)
                return result;


            #region 拼装信息

            List<int> orderIdList = new List<int>();
            result.ListData.ForEach(n => { orderIdList.Add(n.OrderId); });

            foreach (var data in result.ListData)
            {
                data.PassengerNameList = new List<string>();
                data.TrainNoList = new List<string>();
                data.StartTimeList = new List<string>();
                data.TravelList = new List<string>();

                List<TraOrderDetailEntity> traOrderDetailEntities =
                    _traOrderDetailDal.Query<TraOrderDetailEntity>(n => n.OrderId == data.OrderId, true).ToList();
                List<int> odIdList = new List<int>();
                traOrderDetailEntities.ForEach(n => { odIdList.Add(n.OdId); });


            }

            #endregion

            return result;
        }
    }
}
