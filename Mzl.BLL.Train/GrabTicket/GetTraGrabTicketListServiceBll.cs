using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mzl.Common.EnumHelper;
using Mzl.Common.EnumHelper.Train;
using Mzl.DomainModel.Train.GrabTicket;
using Mzl.EntityModel.Train;
using Mzl.Framework.Base;
using Mzl.IBLL.Train.GrabTicket;
using Mzl.IDAL.Train;
using AutoMapper;

namespace Mzl.BLL.Train.GrabTicket
{
    internal class GetTraGrabTicketListServiceBll : BaseServiceBll, IGetTraGrabTicketListServiceBll
    {
        private readonly ITraGrabTicketPassengerDal _traGrabTicketPassengerDal;

        public GetTraGrabTicketListServiceBll(ITraGrabTicketPassengerDal traGrabTicketPassengerDal)
        {
            _traGrabTicketPassengerDal = traGrabTicketPassengerDal;
        }

        public TraGrabTicketListModel GetTraGrabTicketList(TraGrabTicketListQueryModel query)
        {
            TraGrabTicketListModel resultModel = new TraGrabTicketListModel();
            var select = from ticket in Context.Set<TraGrabTicketEntity>().AsNoTracking()
                select new TraGrabTicketListDataModel()
                {
                    Cid = ticket.Cid,
                    OrderId = ticket.OrderId,
                    CreateOid = ticket.CreateOid,
                    CreateTime = ticket.CreateTime,
                    GrabBeginTime = ticket.GrabBeginTime,
                    GrabEndTime = ticket.GrabEndTime,
                    StartCodeName = ticket.StartCodeName,
                    EndCodeName = ticket.EndCodeName,
                    StartTime = ticket.StartTime,
                    TrainNo = ticket.TrainNo,
                    SeatType = ticket.SeatType,
                    GrabStatusNow = ticket.GrabStatus,
                    GrabId= ticket.GrabId,
                    SubmitFailedReason= ticket.SubmitFailedReason,
                    GrabFailedReason= ticket.GrabFailedReason
                };

            if (query.Cid.HasValue)
                select = select.Where(n => n.Cid == query.Cid.Value);
            if (query.OrderId.HasValue)
                select = select.Where(n => n.OrderId == query.OrderId.Value);
            if (query.GrabBeginTime.HasValue)
                select = select.Where(n => n.GrabBeginTime >= query.GrabBeginTime);
            if (query.GrabEndTime.HasValue)
            {
                query.GrabEndTime = query.GrabEndTime.Value.AddDays(1);
                select = select.Where(n => n.GrabEndTime < query.GrabEndTime);
            }
            if (query.StartBeginTime.HasValue)
                select = select.Where(n => n.StartTime >= query.StartBeginTime);
            if (query.StartEndTime.HasValue)
            {
                query.StartEndTime= query.StartEndTime.Value.AddDays(1);
                select = select.Where(n => n.StartTime < query.StartEndTime);
            }

            if (query.GrabStatus.HasValue)
                select = select.Where(n => n.GrabStatusNow == query.GrabStatus.ToString());

            if (!string.IsNullOrEmpty(query.CreateOid))
                select = select.Where(n => n.CreateOid == query.CreateOid);
            if (!string.IsNullOrEmpty(query.StartCodeName))
                select = select.Where(n => n.StartCodeName.Contains(query.StartCodeName));
            if (!string.IsNullOrEmpty(query.EndCodeName))
                select = select.Where(n => n.EndCodeName.Contains(query.EndCodeName));
            if (!string.IsNullOrEmpty(query.TrainNo))
                select = select.Where(n => n.TrainNo.Contains(query.TrainNo));
            if (!string.IsNullOrEmpty(query.SeatType))
                select = select.Where(n => n.SeatType.Contains(query.SeatType));

            if (!string.IsNullOrEmpty(query.PassengerName))
            {
                select = select.Where(
                    n =>
                        Context.Set<TraGrabTicketPassengerEntity>()
                            .Where(m => m.PassengerName.Contains(query.PassengerName))
                            .Select(m => m.GrabId).Contains(n.GrabId)
                    );
            }

            resultModel.TotalCount = select.Count();//查询所有结果的数量
            select =
              select.OrderByDescending(n => n.OrderId).Skip(query.PageSize * (query.PageIndex - 1)).Take(query.PageSize);
            resultModel.DataList = select.ToList(); //分页结果  

            List<int> grabIdList = new List<int>();
            resultModel.DataList.ForEach(n =>
            {
                grabIdList.Add(n.GrabId);
            });

            List<TraGrabTicketPassengerEntity> traGrabTicketPassengerEntities =
                _traGrabTicketPassengerDal.Query<TraGrabTicketPassengerEntity>(n => grabIdList.Contains(n.GrabId), true)
                    .ToList();
            List<TraGrabTicketPassengerModel> traGrabTicketPassengerModels =
                Mapper.Map<List<TraGrabTicketPassengerEntity>, List<TraGrabTicketPassengerModel>>(
                    traGrabTicketPassengerEntities);

            foreach (var traGrabTicketListDataModel in resultModel.DataList)
            {
                traGrabTicketListDataModel.PassengerList =
                    traGrabTicketPassengerModels.FindAll(n => n.GrabId == traGrabTicketListDataModel.GrabId);
            }

            return resultModel;
        }
    }
}
