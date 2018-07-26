using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mzl.Common.EnumHelper;
using Mzl.DomainModel.Train.Order.OrderDetail;
using Mzl.EntityModel.Train.Order;
using Mzl.Framework.Base;
using Mzl.IBLL.Train.Order;
using Mzl.IDAL.Train;

namespace Mzl.BLL.Train.Order
{
    internal class GetTraOrderDetailServiceBll : BaseServiceBll, IGetTraOrderDetailServiceBll
    {
        private readonly ITraOrderDal _traOrderDal;
        private readonly ITraOrderStatusDal _traOrderStatusDal;
        private readonly ITraOrderDetailDal _traOrderDetailDal;
        private readonly ITraPassengerDal _traPassengerDal;
        private readonly ITraModOrderDal _traModOrderDal;
        private readonly ITraModOrderDetailDal _traModOrderDetailDal;

        public GetTraOrderDetailServiceBll(ITraOrderDal traOrderDal, ITraOrderStatusDal traOrderStatusDal,
            ITraOrderDetailDal traOrderDetailDal, ITraPassengerDal traPassengerDal,
            ITraModOrderDal traModOrderDal, ITraModOrderDetailDal traModOrderDetailDal)
        {
            _traOrderDal = traOrderDal;
            _traOrderDetailDal = traOrderDetailDal;
            _traPassengerDal = traPassengerDal;
            _traOrderStatusDal = traOrderStatusDal;
            _traModOrderDal = traModOrderDal;
            _traModOrderDetailDal = traModOrderDetailDal;
        }

        public GetTraOrderDetailInfoModel GetTraOrderDetailFromAppByOrderId(GetTraOrderDetailInfoQueryModel query)
        {
            int orderId = query.OrderId;
            GetTraOrderDetailInfoModel resultModel = new GetTraOrderDetailInfoModel();
            TraOrderEntity traOrderEntity =
                _traOrderDal.Query<TraOrderEntity>(n => n.OrderId == orderId && n.OrderType == 0, true).FirstOrDefault();
            if (traOrderEntity == null)
                return null;

            if (!query.IsFromAduitQuery)//不是来自审批人查询
            {
                if (!string.IsNullOrEmpty(query.Customer?.UserID) && query.Customer.UserID.ToLower() != "administrator"
                    && query.Customer.Cid != traOrderEntity.Cid)
                    return null;
            }

            if (!string.IsNullOrEmpty(query.Customer?.UserID) && query.Customer.UserID.ToLower() == "administrator")
            {
                if ((query.CidList != null && !query.CidList.Contains(traOrderEntity.Cid)) || query.CidList == null)
                    return null;
            }

            #region 正单信息

            resultModel.OrderId = traOrderEntity.OrderId;
            resultModel.TraOrder = new GetTraOrderModel()
            {
                OrderId = traOrderEntity.OrderId,
                OrderAmount = traOrderEntity.TotalMoney,
                TravelList = new List<GetTraOrderTravelModel>(),
                IsAllowMod = false,
                IsAllowRet = false,
                CreateTime = traOrderEntity.CreateTime
            };
            List<TraOrderDetailEntity> traOrderDetailEntities =
                _traOrderDetailDal.Query<TraOrderDetailEntity>(n => n.OrderId == orderId, true).ToList();

            foreach (var traOrderDetailEntity in traOrderDetailEntities)
            {
                #region 行程

                resultModel.OrderId12306 = traOrderDetailEntity.OrderId12306;
                GetTraOrderTravelModel travel = new GetTraOrderTravelModel()
                {
                    OdId = traOrderDetailEntity.OdId,
                    StartName = traOrderDetailEntity.StartName,
                    EndName = traOrderDetailEntity.EndName,
                    StartTime = traOrderDetailEntity.StartTime,
                    EndTime = traOrderDetailEntity.EndTime ?? traOrderDetailEntity.StartTime,
                    TrainNo = traOrderDetailEntity.TrainNo,
                    StartCode = traOrderDetailEntity.StartCode,
                    EndCode = traOrderDetailEntity.EndCode,
                    CorpPolicy = traOrderDetailEntity.CorpPolicy,
                    ChoiceReason = traOrderDetailEntity.ChoiceReason,
                    PassengerList = new List<GetTraOrderPassengerModel>()
                };

                #endregion

                List<TraPassengerEntity> traPassengerEntities =
                    _traPassengerDal.Query<TraPassengerEntity>(n => n.OdId == traOrderDetailEntity.OdId, true).ToList();

                #region 乘客信息

                foreach (var traPassengerEntity in traPassengerEntities)
                {
                    GetTraOrderPassengerModel p = new GetTraOrderPassengerModel()
                    {
                        Pid = traPassengerEntity.Pid,
                        Name = traPassengerEntity.Name,
                        CardNo = traPassengerEntity.CardNo,
                        CardNoType = traPassengerEntity.CardNoType?.ValueToEnum<CardTypeEnum>(),
                        Mobile = traPassengerEntity.Mobile,
                        PlaceCar = traPassengerEntity.PlaceCar,
                        PlaceSeatNo = traPassengerEntity.PlaceSeatNo,
                        PlaceGrade = traPassengerEntity.PlaceGrade,
                        ServiceFee = traPassengerEntity.ServiceFee,
                        FacePrice = traPassengerEntity.FacePrice,
                        AgeType = traPassengerEntity.AgeType.NameToEnum<AgeTypeEnum>()
                    };

                    //判断当前客户是否已经改签
                    /*
                     * 正单客户
                     * 如果已经没有改签就退票了 显示已退票
                     * 如果有改签，就显示已改签
                     * **/
                    List<TraModOrderDetailEntity> traModOrderDetailEntities =
                        (from n in base.Context.Set<TraModOrderDetailEntity>()
                            join mo in base.Context.Set<TraModOrderEntity>().AsNoTracking() on n.CorderId equals
                                mo.CorderId into o
                            from mo in o.DefaultIfEmpty()
                            where
                                n.Pid == p.Pid.ToString() && mo.OrderStatus != "C" && mo.OrderStatus != "N" &&
                                mo.OrderId == orderId
                            select n).ToList();

                    if (traModOrderDetailEntities != null && traModOrderDetailEntities.Count > 0)
                    {
                        #region 判断当前是否是改签中还是已改签

                        TraModOrderEntity traModOrderEntity =
                            _traModOrderDal.Find<TraModOrderEntity>(traModOrderDetailEntities[0].CorderId??0);
                        if (traModOrderEntity != null && traModOrderEntity.CorderId > 0 &&
                            !string.IsNullOrEmpty(traModOrderEntity.OrderStatus) && traModOrderEntity.OrderStatus.ToUpper() != "C")
                        {
                            if (!string.IsNullOrEmpty(traModOrderEntity.ProcessStatus) &&
                                traModOrderEntity.ProcessStatus.ToUpper().Contains("H"))
                            {
                                p.PassengerStatus = "已改签";
                            }
                            else
                            {
                                p.PassengerStatus = "改签中";
                            }
                            p.TravelRemark = traModOrderEntity.TravelRemark;
                        }

                        #endregion
                    }
                    else
                    {
                        #region 判断是否存在退票，存在的话是已退票还是退票中
                        //根据订单查询对应的退票单信息(去除改签对应生成的)

                        TraPassengerEntity refundTraPassengerEntity = (from pp in base.Context.Set<TraPassengerEntity>()
                            join detail in base.Context.Set<TraOrderDetailEntity>().AsNoTracking() on pp.OdId equals
                                detail.OdId into d
                            from detail in d.DefaultIfEmpty()
                            join status in base.Context.Set<TraOrderStatusEntity>().AsNoTracking() on detail.OrderId
                                equals status.OrderId into s
                            from status in s.DefaultIfEmpty()
                            join order in base.Context.Set<TraOrderEntity>().AsNoTracking() on detail.OrderId equals
                                order.OrderId into o
                            from order in o.DefaultIfEmpty()
                            where
                                pp.Name == p.Name && pp.CardNo == p.CardNo && pp.Pid != p.Pid && status.IsCancle == 0 &&
                                order.OrderRoot == orderId && !order.CorderId.HasValue
                            select pp).FirstOrDefault();


                        if (refundTraPassengerEntity != null)
                        {
                            //找行程
                            TraOrderDetailEntity refunTraOrderDetailEntity =
                                _traOrderDetailDal.Find<TraOrderDetailEntity>(refundTraPassengerEntity.OdId);
                            TraOrderStatusEntity traOrderStatusEntity = _traOrderStatusDal.Query<TraOrderStatusEntity>(
                                n => n.OrderId == refunTraOrderDetailEntity.OrderId).FirstOrDefault();
                            TraOrderEntity traRefundOrderEntity =
                                _traOrderDal.Find<TraOrderEntity>(refunTraOrderDetailEntity.OrderId);
                            if (traOrderStatusEntity != null)
                            {
                                if (traOrderStatusEntity.Status4 == 1)
                                {
                                    p.PassengerStatus = "已退票";
                                }
                                else
                                {
                                    p.PassengerStatus = "退票中";
                                }

                                p.TravelRemark = traRefundOrderEntity.Remark;
                            }
                        }

                        #endregion
                    }
                    travel.PassengerList.Add(p);

                    if (string.IsNullOrEmpty(p.PassengerStatus))//只要有一个状态是空的，就允许退票和改签
                    {
                        resultModel.TraOrder.IsAllowMod = true;
                        resultModel.TraOrder.IsAllowRet = true;
                    }
                }

                #endregion

                resultModel.TraOrder.TravelList.Add(travel);
            }

            #endregion

            #region 改签信息

            List<TraModOrderEntity> traModOrderEntities =
                _traModOrderDal.Query<TraModOrderEntity>(
                    n =>
                        n.OrderId == orderId && !string.IsNullOrEmpty(n.ProcessStatus) &&
                        n.ProcessStatus.ToUpper().Contains("H") && !string.IsNullOrEmpty(n.OrderStatus) &&
                        n.OrderStatus.ToUpper() != "C" && n.OrderStatus.ToUpper() != "N", true)
                    .ToList();

            if (traModOrderEntities != null && traModOrderEntities.Count > 0)
            {
                resultModel.TraModOrderList = new List<GetTraModOrderModel>();
                foreach (var traModOrderEntity in traModOrderEntities)
                {
                    #region 改签订单
                    GetTraModOrderModel traModOrderModel = new GetTraModOrderModel()
                    {
                        CorderId = traModOrderEntity.CorderId,
                        TravelList = new List<GetTraOrderTravelModel>(),
                        IsAllowRet = false
                    };

                    #endregion

                    List<TraModOrderDetailEntity> traModOrderDetailEntities =
                        _traModOrderDetailDal.Query<TraModOrderDetailEntity>(
                            n => n.CorderId == traModOrderModel.CorderId,
                            true).ToList();

                    if (traModOrderDetailEntities != null && traModOrderDetailEntities.Count > 0)
                    {
                        #region 改签行程信息

                        GetTraOrderTravelModel travel = new GetTraOrderTravelModel()
                        {
                            OdId = traModOrderDetailEntities[0].TravelId,
                            StartName = traModOrderDetailEntities[0].AddrName,
                            EndName = traModOrderDetailEntities[0].EndName,
                            StartTime = traModOrderDetailEntities[0].SendTime ?? Convert.ToDateTime("2000-01-01"),
                            EndTime = traModOrderDetailEntities[0].EndTime ?? Convert.ToDateTime("2000-01-01"),
                            TrainNo = traModOrderDetailEntities[0].TrainNo,
                            StartCode = traModOrderDetailEntities[0].StartCode,
                            EndCode = traModOrderDetailEntities[0].EndCode,
                            PassengerList = new List<GetTraOrderPassengerModel>()
                        };

                        #endregion

                        #region 改签乘客信息

                        foreach (var traModOrderDetailEntity in traModOrderDetailEntities)
                        {
                            int pid = Convert.ToInt32(traModOrderDetailEntity.Pid);
                            TraPassengerEntity traPassengerEntity = _traPassengerDal.Find<TraPassengerEntity>(pid);
                            GetTraOrderPassengerModel p = new GetTraOrderPassengerModel()
                            {
                                Pid = pid,
                                Name = traPassengerEntity.Name,
                                CardNo = traPassengerEntity.CardNo,
                                CardNoType = traPassengerEntity.CardNoType?.ValueToEnum<CardTypeEnum>(),
                                Mobile = traPassengerEntity.Mobile,
                                PlaceCar = traModOrderDetailEntity.PlaceCar,
                                PlaceSeatNo = traModOrderDetailEntity.PlaceSeatNo,
                                PlaceGrade = traModOrderDetailEntity.PlaceGrade,
                                FacePrice = traModOrderDetailEntity.TrainMoney,
                                AgeType = traPassengerEntity.AgeType.NameToEnum<AgeTypeEnum>(),
                                TravelRemark = traModOrderEntity.TravelRemark
                            };
                            #region 判断当前乘客是否退票

                            TraPassengerEntity refundTraPassengerEntity =
                                (from pp in base.Context.Set<TraPassengerEntity>()
                                    join detail in base.Context.Set<TraOrderDetailEntity>().AsNoTracking() on pp.OdId
                                        equals
                                        detail.OdId into d
                                    from detail in d.DefaultIfEmpty()
                                    join status in base.Context.Set<TraOrderStatusEntity>().AsNoTracking() on
                                        detail.OrderId
                                        equals status.OrderId into s
                                    from status in s.DefaultIfEmpty()
                                    join order in base.Context.Set<TraOrderEntity>().AsNoTracking() on detail.OrderId
                                        equals
                                        order.OrderId into o
                                    from order in o.DefaultIfEmpty()
                                    where
                                        pp.Name == p.Name && pp.CardNo == p.CardNo && pp.Pid != p.Pid &&
                                        status.IsCancle == 0 && order.OrderRoot == orderId && !order.CorderId.HasValue
                                 select pp).FirstOrDefault();

                            if (refundTraPassengerEntity != null)
                            {
                                //找行程
                                TraOrderDetailEntity refunTraOrderDetailEntity =
                                    _traOrderDetailDal.Find<TraOrderDetailEntity>(refundTraPassengerEntity.OdId);
                                TraOrderStatusEntity traOrderStatusEntity =
                                    _traOrderStatusDal.Query<TraOrderStatusEntity>(
                                        n => n.OrderId == refunTraOrderDetailEntity.OrderId).FirstOrDefault();
                                TraOrderEntity traRefundOrderEntity =
                                    _traOrderDal.Find<TraOrderEntity>(refunTraOrderDetailEntity.OrderId);
                                if (traOrderStatusEntity != null)
                                {
                                    if (traOrderStatusEntity.Status4 == 1)
                                    {
                                        p.PassengerStatus = "已退票";
                                    }
                                    else
                                    {
                                        p.PassengerStatus = "退票中";
                                    }
                                    p.TravelRemark = traRefundOrderEntity.Remark;
                                }
                            }
                            #endregion

                            travel.PassengerList.Add(p);
                            if (string.IsNullOrEmpty(p.PassengerStatus))//只要有一个状态是空的，就允许退票
                            {
                                traModOrderModel.IsAllowRet = true;
                            }
                        }
                        #endregion
                        traModOrderModel.TravelList.Add(travel);
                      
                    }

                    resultModel.TraModOrderList.Add(traModOrderModel);
                }
            }
            #endregion

            #region 计算金额

            resultModel.TotalOrderAmount = traOrderEntity.TotalMoney;

            //获取当前订单对应的退票单信息（除去改签生成的对应）
            List<TraOrderEntity> refundOrderEntities = (from o in base.Context.Set<TraOrderEntity>()
                join status in base.Context.Set<TraOrderStatusEntity>().AsNoTracking() on o.OrderId
                    equals status.OrderId into s
                from status in s.DefaultIfEmpty()
                where o.OrderRoot == orderId && !o.CorderId.HasValue && o.OrderType == 2
                      && status.Status4 == 1 && status.IsCancle == 0
                select o).ToList();

            if (refundOrderEntities != null && refundOrderEntities.Count > 0)
            {
                resultModel.RefundAmount = resultModel.RefundAmount + refundOrderEntities.Sum(n => n.TotalMoney);
            }

            /*判断当前改签是 低改高 还是高改低
             * 低改高 算入改签差价
             * 高改低 算入退款金额
             * **/
            if (traModOrderEntities != null && traModOrderEntities.Count > 0)
            {
                foreach (var traModOrderEntity in traModOrderEntities)
                {
                    TraOrderEntity modRefTraOrderEntity =
                        _traOrderDal.Query<TraOrderEntity>(
                            n => n.OrderRoot == orderId && n.CorderId.HasValue && n.OrderType == 2,
                            true).FirstOrDefault();//改签对应的退票信息
                    if (modRefTraOrderEntity != null)
                    {
                        decimal money = (traModOrderEntity.PayAmount ?? 0) + modRefTraOrderEntity.TotalMoney; //  modRefTraOrderEntity.TotalMoney为负数
                        //低改高 收钱 
                        if (money >= 0)
                        {
                            resultModel.TotalModAmount = resultModel.TotalModAmount + money;
                        }
                        else
                        {
                            //高改低 退钱
                            resultModel.RefundAmount = resultModel.RefundAmount + money;
                        }
                    }
                }
            }
            #endregion

            TraOrderStatusEntity orderStatus = _traOrderStatusDal.Query<TraOrderStatusEntity>(n => n.OrderId == orderId, true).FirstOrDefault();
            resultModel.ShowOnlineOrderId = (traOrderEntity.CopyType == "X" && traOrderEntity.CopyFromOrderId.HasValue &&
                                             orderStatus != null &&
                                             (orderStatus.ProccessStatus & 1) == 1 &&
                                             orderStatus.IsCancle != 1)
                ? traOrderEntity.CopyFromOrderId.Value
                : traOrderEntity.OrderId;


            return resultModel;
        }
    }
}
