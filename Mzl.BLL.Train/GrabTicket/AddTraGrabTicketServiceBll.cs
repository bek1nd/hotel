using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Mzl.Common.EnumHelper;
using Mzl.Common.EnumHelper.Train;
using Mzl.DomainModel.Train.GrabTicket;
using Mzl.DomainModel.Train.Order;
using Mzl.Framework.Base;
using Mzl.IBLL.Train.GrabTicket;
using Mzl.IDAL.Train;
using Mzl.EntityModel.Train;
using Mzl.IBLL.Train.Order;
using Mzl.DomainModel.Customer.ContactInfo;
using Mzl.DomainModel.Events;

namespace Mzl.BLL.Train.GrabTicket
{
    internal class AddTraGrabTicketServiceBll : BaseServiceBll, IAddTraGrabTicketServiceBll
    {
        private readonly ITraGrabTicketDal _traGrabTicketDal;
        private readonly ITraGrabTicketPassengerDal _traGrabTicketPassengerDal;
        private readonly IAddTraOrderBll _addTraOrderBll;
        /// <summary>
        /// 添加联系人事件
        /// </summary>
        public event EventHandler<CommonEventArgs<List<ContactInfoModel>>> AddContactEvent;

        public AddTraGrabTicketServiceBll(ITraGrabTicketDal traGrabTicketDal, ITraGrabTicketPassengerDal traGrabTicketPassengerDal
            , IAddTraOrderBll addTraOrderBll)
        {
            _traGrabTicketDal = traGrabTicketDal;
            _traGrabTicketPassengerDal = traGrabTicketPassengerDal;
            _addTraOrderBll = addTraOrderBll;
        }
        /// <summary>
        /// 添加抢票信息
        /// </summary>
        /// <param name="addTraGrabTicketModel"></param>
        /// <returns></returns>
        public int AddTraGrabTicket(AddTraGrabTicketModel addTraGrabTicketModel)
        {
            #region 预生成一张抢票订单
            TraAddOrderModel traAddOrderModel = new TraAddOrderModel();
            traAddOrderModel.OrderSource = addTraGrabTicketModel.OrderSource;
            traAddOrderModel.Order = new TraOrderModel();
            traAddOrderModel.Order.Cid = addTraGrabTicketModel.Cid ?? 0;
            traAddOrderModel.Order.OrderType = 1;
            traAddOrderModel.Order.PayType = PayTypeEnum.Cas;
            traAddOrderModel.Order.SendType = addTraGrabTicketModel.SendType;
            traAddOrderModel.Order.CName = addTraGrabTicketModel.CName;
            traAddOrderModel.Order.CMobile = addTraGrabTicketModel.CMobile;
            traAddOrderModel.Order.CEmail = addTraGrabTicketModel.CEmail;
            traAddOrderModel.Order.CPhone = addTraGrabTicketModel.CPhone;
            traAddOrderModel.Order.CFax = addTraGrabTicketModel.CFax;
            traAddOrderModel.Order.SendAddress = addTraGrabTicketModel.SendAddress;
            traAddOrderModel.Order.OrderFrom = TraOrderFromEnum.Interface.ToString();
            traAddOrderModel.Order.CreateOid = addTraGrabTicketModel.CreateOid;
            traAddOrderModel.Order.IsGrabTicketOrder = true;
            traAddOrderModel.Order.IsOnline = "F";
            if (!string.IsNullOrEmpty(traAddOrderModel.Customer?.CorpID))
            {
                traAddOrderModel.Order.BalanceType = 1;
                traAddOrderModel.Order.TravelType = 0;
            }

            traAddOrderModel.Order.SendTime = addTraGrabTicketModel.SendTime;
            traAddOrderModel.Order.LastSendTime= addTraGrabTicketModel.LastSendTime;

            if (addTraGrabTicketModel.ProjectId.HasValue)
                traAddOrderModel.Order.ProjectId = addTraGrabTicketModel.ProjectId.Value;

            if (!string.IsNullOrEmpty(addTraGrabTicketModel.Depart))
                traAddOrderModel.Order.CostCenter = addTraGrabTicketModel.Depart;
            else
            {
                traAddOrderModel.Order.CostCenter = "";
            }

            traAddOrderModel.OrderStatus = new TraOrderStatusModel();

            traAddOrderModel.OrderDetailList = new List<TraOrderDetailModel>();
            TraOrderDetailModel traOrderDetailModel = new TraOrderDetailModel()
            {
                StartName = addTraGrabTicketModel.StartCodeName,
                StartNameCode = addTraGrabTicketModel.StartCode,
                EndName = addTraGrabTicketModel.EndCodeName,
                EndNameCode = addTraGrabTicketModel.EndCode,
                StartTime = addTraGrabTicketModel.StartTime,
                OnTrainTime = addTraGrabTicketModel.StartTime,
                EndTime = addTraGrabTicketModel.StartTime,
                TrainNo = "抢票",
                TicketNum = addTraGrabTicketModel.PassengerList.Count,
                ServiceFee = addTraGrabTicketModel.ServiceFee,
                FacePrice = 0,
                TotalPrice = 0,
                StartCode = addTraGrabTicketModel.StartCode,
                EndCode = addTraGrabTicketModel.EndCode,
                PlaceType="抢票",
                PlaceGrade= "抢票",
                PassengerList = new List<TraPassengerModel>()
            };

            List<ContactInfoModel> contactList = new List<ContactInfoModel>();
            foreach (TraGrabTicketPassengerModel traGrabTicketPassengerModel in addTraGrabTicketModel.PassengerList)
            {
                TraPassengerModel passengerModel = new TraPassengerModel()
                {
                    Name = traGrabTicketPassengerModel.PassengerName,
                    CardNo = traGrabTicketPassengerModel.CardNo,
                    CardNoType = traGrabTicketPassengerModel.CardType,
                    Mobile = traGrabTicketPassengerModel.Mobile,
                    AgeType = traGrabTicketPassengerModel.TicketType,
                    ServiceFee = addTraGrabTicketModel.ServiceFee,
                    ContactId= traGrabTicketPassengerModel.ContactId,
                    FacePrice = 0
                };
                traOrderDetailModel.PassengerList.Add(passengerModel);

                contactList.Add(new ContactInfoModel()
                {
                    ContactId = passengerModel.ContactId,
                    CardNo = passengerModel.CardNo,
                    CardNoType = (int)passengerModel.CardNoType,
                    CName = passengerModel.Name,
                    Mobile = passengerModel.Mobile,
                    Cid = traAddOrderModel.Order.Cid,
                    LastUpdateTime = DateTime.Now,
                    IsDel = "F",
                    IsPassenger = "F",
                    UpdateOid = traAddOrderModel.Order.CreateOid,
                    DelTime = DateTime.Now
                });

            }


            traAddOrderModel.OrderDetailList.Add(traOrderDetailModel);


            traAddOrderModel.Customer = addTraGrabTicketModel.Customer;

            addTraGrabTicketModel.OrderId = _addTraOrderBll.AddTraOrder(traAddOrderModel);

            //通知联系人对象，新增联系人
            AddContactEvent?.Invoke(this, new CommonEventArgs<List<ContactInfoModel>>(contactList));

            #endregion


            #region 添加抢票信息记录
            addTraGrabTicketModel.CreateTime = DateTime.Now;
            addTraGrabTicketModel.GrabStatus = TrainGrabStatusEnum.W;
            addTraGrabTicketModel.OrderId = addTraGrabTicketModel.OrderId;
            addTraGrabTicketModel.GrabBeginTime = DateTime.Now;//任务开始时间默认当前时间，满足空铁接口要求
            TraGrabTicketEntity traGrabTicketEntity =
                Mapper.Map<AddTraGrabTicketModel, TraGrabTicketEntity>(addTraGrabTicketModel);

            List<TraGrabTicketPassengerEntity> traGrabTicketPassengerEntities =
                Mapper.Map<List<TraGrabTicketPassengerModel>, List<TraGrabTicketPassengerEntity>>(
                    addTraGrabTicketModel.PassengerList);

            traGrabTicketEntity = _traGrabTicketDal.Insert(traGrabTicketEntity);

            foreach (var traGrabTicketPassengerEntity in traGrabTicketPassengerEntities)
            {
                traGrabTicketPassengerEntity.GrabId = traGrabTicketEntity.GrabId;
                _traGrabTicketPassengerDal.Insert(traGrabTicketPassengerEntity);
            } 
            #endregion


            return traGrabTicketEntity.GrabId;
        }
    }
}
