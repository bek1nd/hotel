using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Mzl.DomainModel.Train.Order;
using Mzl.Framework.Base;
using Mzl.IBLL.Train.Order;
using Mzl.IDAL.Train;
using Mzl.Common.EnumHelper;
using Mzl.EntityModel.Train.BaseMaintenance;
using Mzl.EntityModel.Train.Order;

namespace Mzl.BLL.Train.Order
{
    internal class AddTraOrderBll : BaseBll, IAddTraOrderBll
    {
        private readonly ITraOrderDal _traOrderDal;
        private readonly ITraOrderStatusDal _traOrderStatusDal;
        private readonly ITraOrderDetailDal _traOrderDetailDal;
        private readonly ITraPassengerDal _traPassengerDal;
        private readonly ITraOrderLogDal _traOrderLogDal;
        private readonly ITraAddressDal _traAddressDal;

        public AddTraOrderBll(ITraOrderDal traOrderDal, ITraOrderStatusDal traOrderStatusDal,
            ITraOrderDetailDal traOrderDetailDal, ITraPassengerDal traPassengerDal,
             ITraOrderLogDal traOrderLogDal, ITraAddressDal traAddressDal)
        {
            _traOrderDal = traOrderDal;
            _traOrderDetailDal = traOrderDetailDal;
            _traPassengerDal = traPassengerDal;
            _traOrderStatusDal = traOrderStatusDal;
            _traOrderLogDal = traOrderLogDal;
            _traAddressDal = traAddressDal;
        }


        public int AddTraOrder(TraAddOrderModel newOrder)
        {
            newOrder.Order.TrainPlace = "代售点";
            newOrder.Order.OrderRoot = 0;
            newOrder.Order.CreateTime = DateTime.Now;
            if (newOrder.Order.PayAmount == 0)
                newOrder.Order.PayAmount = newOrder.Order.TotalMoney;
            newOrder.Order.OpeartorId = newOrder.Order.CreateOid;

            newOrder.Order.OrderSource = newOrder.OrderSource;

            if (newOrder.AddOrderType==1)//手动
            {
                newOrder.Order.OrderType = 0;
            }
            else
            {
                newOrder.Order.OrderType = 1;
            }

            if (newOrder.Customer != null && !string.IsNullOrEmpty(newOrder.Customer.Category) &&
                newOrder.Customer.Category.ToUpper() == "D")
            {
                newOrder.Order.BalanceType = 1;
                newOrder.Order.TravelType = 0;
            }
            else
            {
                newOrder.Order.BalanceType = 0;
                newOrder.Order.TravelType = 1;
            }

            //如果存在项目名称
            if (newOrder.ProjectName != null && newOrder.ProjectName.ProjectId > 0)
            {
                newOrder.Order.ProjectId = newOrder.ProjectName.ProjectId;
            }

            if (newOrder.CostCenter != null && newOrder.CostCenter.Cid > 0)
            {
                newOrder.Order.CostCenter = newOrder.CostCenter.Depart;
            }
            if (string.IsNullOrEmpty(newOrder.Order.CostCenter))
                newOrder.Order.CostCenter = "";

            if (newOrder.AddOrderType == 0)
            {
                newOrder.Order.OrderFrom = TraOrderFromEnum.Interface.ToString();
            }
            else
            {
                newOrder.Order.OrderFrom = TraOrderFromEnum.Hand.ToString();
            }

            if (newOrder.Order.OrderSource == "O")
                newOrder.Order.IsOnline = "F";
            else
            {
                newOrder.Order.IsOnline = "T";
            }

            TraOrderEntity orderEntity = Mapper.Map<TraOrderModel, TraOrderEntity>(newOrder.Order);

            orderEntity.CorpPolicy = string.Empty;
            orderEntity.ChoiceReason = string.Empty;

            foreach (var traOrderDetailModel in newOrder.OrderDetailList)
            {
                if (!string.IsNullOrEmpty(traOrderDetailModel.CorpPolicy))
                    orderEntity.CorpPolicy += "|" + traOrderDetailModel.CorpPolicy;
                if (!string.IsNullOrEmpty(traOrderDetailModel.ChoiceReason))
                    orderEntity.ChoiceReason += "|" + traOrderDetailModel.ChoiceReason;
            }


            orderEntity = _traOrderDal.Insert(orderEntity);


            if (newOrder.OrderStatus == null)
                newOrder.OrderStatus = new TraOrderStatusModel();
            newOrder.OrderStatus.OrderId = orderEntity.OrderId;
            if (newOrder.Order.CreateOid != "sys" && (newOrder.OrderStatus.ProccessStatus & 64) != 64)
            {
                newOrder.OrderStatus.ProccessStatus = newOrder.OrderStatus.ProccessStatus + 64;
            }
            TraOrderStatusEntity  orderStatusEntity= Mapper.Map<TraOrderStatusModel, TraOrderStatusEntity>(newOrder.OrderStatus);
            orderStatusEntity =_traOrderStatusDal.Insert(orderStatusEntity);

            foreach (var detail in newOrder.OrderDetailList)
            {

                detail.OrderId = orderEntity.OrderId;
                detail.TicketNum = detail.PassengerList.Count;

         

                detail.TotalPrice = detail.PassengerList.Sum(n => (n.FacePrice ?? 0)) +
                                    detail.PassengerList.Sum(n => (n.ServiceFee ?? 0));//乘客面价+乘客服务费

                detail.ServiceFee = (detail.PassengerList?[0].ServiceFee ?? 0);

                var childPerson = detail.PassengerList.Find(n => n.AgeType == AgeTypeEnum.E);//儿童
                var person = detail.PassengerList.Find(n => n.AgeType == AgeTypeEnum.C);//成人

                detail.FacePrice= (person?.FacePrice ?? 0);
                detail.TrainChdSalePrice = (childPerson?.FacePrice ?? 0);
                detail.PlaceGrade = detail.PassengerList?[0].PlaceGrade;

                detail.PlaceType = GetPlaceType(detail.PlaceGrade);
                detail.TrainNoRemark = string.IsNullOrEmpty(detail.TrainNoRemark) ? "" : detail.TrainNoRemark;
                detail.TrainNoStatus = string.IsNullOrEmpty(detail.TrainNoStatus) ? "" : detail.TrainNoStatus;
                detail.OnTrainTimeTemp = detail.StartTime;
                detail.OnTrainTime = detail.StartTime;

                TraAddressEntity startAddressEntity =
                    _traAddressDal.Query<TraAddressEntity>(n => n.Addr_Name == detail.StartName).FirstOrDefault();
                if (startAddressEntity == null)
                {
                    startAddressEntity = new TraAddressEntity();
                    startAddressEntity.Addr_Name = detail.StartName;
                    startAddressEntity.Addr_Type = 0;
                    startAddressEntity.Addr_S = detail.StartCode;
                    startAddressEntity = _traAddressDal.Insert<TraAddressEntity>(startAddressEntity);
                }
                detail.StartNameId = startAddressEntity.Aid;


                TraAddressEntity endAddressEntity =
                    _traAddressDal.Query<TraAddressEntity>(n => n.Addr_Name == detail.EndName)
                        .FirstOrDefault();
                if(endAddressEntity==null)
                {
                    endAddressEntity = new TraAddressEntity();
                    endAddressEntity.Addr_Name = detail.EndName;
                    endAddressEntity.Addr_Type = 0;
                    endAddressEntity.Addr_S = detail.EndCode;
                    endAddressEntity = _traAddressDal.Insert<TraAddressEntity>(endAddressEntity);
                }

                detail.EndNameId = endAddressEntity.Aid;


                TraOrderDetailEntity traOrderDetailEntity = Mapper.Map<TraOrderDetailModel, TraOrderDetailEntity>(detail);
                traOrderDetailEntity = _traOrderDetailDal.Insert(traOrderDetailEntity);
                foreach (var p in detail.PassengerList)
                {
                    p.OdId = traOrderDetailEntity.OdId;
                    TraPassengerEntity  traPassengerEntity= Mapper.Map<TraPassengerModel, TraPassengerEntity>(p);
                    traPassengerEntity.Name = traPassengerEntity.Name.Replace("/", " ");
                    _traPassengerDal.Insert(traPassengerEntity);
                }
            }
            string logContent = newOrder.Log?.LogContent;
            if (string.IsNullOrEmpty(logContent))
                logContent =
                    $"{(newOrder.Order.IsOnline == "T" ? "线上" : "线下")}添加火车订单";
            _traOrderLogDal.Insert<TraOrderLogEntity>(new TraOrderLogEntity()
            {
                OrderId = orderEntity.OrderId,
                CreateOid= orderEntity.CreateOid,
                CreateTime=DateTime.Now,
                LogType= "OI",
                LogContent= logContent
            });

            return orderEntity.OrderId;
        }


        private string GetPlaceType(string placeGrade)
        {
            if (string.IsNullOrEmpty(placeGrade))
                return string.Empty;
            if (placeGrade.Contains("座"))
                return "座位";
            if (placeGrade.Contains("铺"))
                return "卧铺";
            return string.Empty;
        }
    }
}
