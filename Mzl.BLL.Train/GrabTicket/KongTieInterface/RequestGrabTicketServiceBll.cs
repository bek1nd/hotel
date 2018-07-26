using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mzl.DomainModel.Train.GrabTicket.KongTieInterface;
using Mzl.IBLL.Train.GrabTicket.KongTieInterface;
using Mzl.DomainModel.Train.GrabTicket;

namespace Mzl.BLL.Train.GrabTicket.KongTieInterface
{
    public class RequestGrabTicketServiceBll: IRequestGrabTicketServiceBll
    {
        private readonly IRequestGrabTicketBll _requestGrabTicketBll;

        public RequestGrabTicketServiceBll(IRequestGrabTicketBll requestGrabTicketBll)
        {
            _requestGrabTicketBll = requestGrabTicketBll;
        }

        public GrabTicketResponseModel RequestGrabTicketInterface(AddTraGrabTicketModel addTraGrabTicketModel)
        {
            #region 组装请求接口对象
            GrabTicketRequestModel grabTicketRequestModel = new GrabTicketRequestModel();
            grabTicketRequestModel.qorderid = addTraGrabTicketModel.OrderId.ToString();
            grabTicketRequestModel.qorder_start_time = addTraGrabTicketModel.GrabBeginTime.ToString("yyyy-MM-dd HH:mm");
            grabTicketRequestModel.qorder_end_time = addTraGrabTicketModel.GrabEndTime.ToString("yyyy-MM-dd HH:mm");
            grabTicketRequestModel.from_station_code = addTraGrabTicketModel.StartCode;
            grabTicketRequestModel.from_station_name = addTraGrabTicketModel.StartCodeName;
            grabTicketRequestModel.to_station_code = addTraGrabTicketModel.EndCode;
            grabTicketRequestModel.to_station_name = addTraGrabTicketModel.EndCodeName;
            grabTicketRequestModel.start_date = addTraGrabTicketModel.StartTime.ToString("yyyyMMdd");
            grabTicketRequestModel.train_codes = addTraGrabTicketModel.TrainNo;
            grabTicketRequestModel.train_type = addTraGrabTicketModel.TrainType;
            grabTicketRequestModel.seat_type = addTraGrabTicketModel.SeatType;
            grabTicketRequestModel.hasseat = addTraGrabTicketModel.IsNeedNoSeatTicket;

            grabTicketRequestModel.passengers = new List<GrabTicketPassengerRequestModel>();
            for (var i = 0; i < addTraGrabTicketModel.PassengerList.Count; i++)
            {
                GrabTicketPassengerRequestModel p = new GrabTicketPassengerRequestModel();
                p.passengerid = i + 1;
                p.passengersename = addTraGrabTicketModel.PassengerList[i].PassengerName;
                p.passportseno = addTraGrabTicketModel.PassengerList[i].CardNo;
                p.passporttypeseid = addTraGrabTicketModel.PassengerList[i].KongTieCardType;
                p.piaotype = addTraGrabTicketModel.PassengerList[i].KongTieTicketType;
                grabTicketRequestModel.passengers.Add(p);
            }
            #endregion

            return _requestGrabTicketBll.RunGrabTicketInterface(grabTicketRequestModel);
        }
    }
}
