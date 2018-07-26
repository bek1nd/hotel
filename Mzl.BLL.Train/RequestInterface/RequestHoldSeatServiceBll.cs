using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mzl.Common.ConfigHelper;
using Mzl.Common.EnumHelper;
using Mzl.DomainModel.Enum;
using Mzl.DomainModel.Train.Order;
using Mzl.DomainModel.Train.Server;
using Mzl.EntityModel.Train.Server;
using Mzl.Framework.Base;
using Mzl.IBLL.Train.RequestInterface;
using Mzl.IDAL.Train;

namespace Mzl.BLL.Train.RequestInterface
{
    internal class RequestHoldSeatServiceBll : BaseServiceBll, IRequestHoldSeatServiceBll
    {
        private readonly IRequestHoldSeatBll _requestHoldSeatBll;
        private readonly ITraInterFaceOrderDal _traInterFaceOrderDal;
        private readonly ITraOrderOperateDal _traOrderOperateDal;

        public RequestHoldSeatServiceBll(IRequestHoldSeatBll requestHoldSeatBll
            , ITraInterFaceOrderDal traInterFaceOrderDal
            , ITraOrderOperateDal traOrderOperateDal)
        {
            _requestHoldSeatBll = requestHoldSeatBll;
            _traInterFaceOrderDal = traInterFaceOrderDal;
            _traOrderOperateDal = traOrderOperateDal;
        }

        public TraOrderSubmitResponseModel RequestHoldSeat(TraAddOrderModel addModel)
        {
            TraOrderSubmitResponseModel responseModel = null;
            string isServer = AppSettingsHelper.GetAppSettings(AppSettingsEnum.IsServer);
            if (isServer == "T")
            {
                //请求接口
                #region 封装接口请求参数
                TraOrderSubmitModel model = new TraOrderSubmitModel()
                {
                    orderid = addModel.Order.OrderId.ToString(),
                    checi = addModel.OrderDetailList[0].TrainNo,
                    from_station_code = addModel.OrderDetailList[0].StartCode,
                    from_station_name = addModel.OrderDetailList[0].StartName,
                    to_station_code = addModel.OrderDetailList[0].EndCode,
                    to_station_name = addModel.OrderDetailList[0].EndName,
                    train_date = addModel.OrderDetailList[0].StartTime.ToString("yyyy-MM-dd"),
                    passengers = new List<TraOrderSubmitPassengerModel>(),
                    LoginUserName = "",
                    LoginUserPassword = "",
                    is_accept_standing = addModel.IsAcceptStanding,
                    is_choose_seats = addModel.IsChooseSeats,
                    choose_seats = addModel.ChooseSeats
                };


                model.passengers = new List<TraOrderSubmitPassengerModel>();
                foreach (var p in addModel.OrderDetailList[0].PassengerList)
                {
                    TraOrderSubmitPassengerModel pp = new TraOrderSubmitPassengerModel();
                    pp.passengersename = p.Name.Replace("/", " ");
                    pp.passportseno = p.CardNo;
                    pp.passporttypeseidname = p.CardNoType.ToDescription();
                    if (p.CardNoType == CardTypeEnum.Certificate)
                    {
                        pp.passporttypeseid = "1";
                    }
                    else if (p.CardNoType == CardTypeEnum.HongKongAndMacaoPass)
                    {
                        pp.passporttypeseid = "C";
                    }
                    else if (p.CardNoType == CardTypeEnum.Passport)
                    {
                        pp.passporttypeseid = "B";
                    }
                    else if (p.CardNoType == CardTypeEnum.TaiwanEntryPermit || p.CardNoType == CardTypeEnum.MTP)
                    {
                        pp.passporttypeseid = "G";
                        pp.passporttypeseidname = "台湾通行证";
                    }
                    //pp.passporttypeseid = ((int) p.CardNoType).ToString();
                    pp.piaotype = "1";
                    pp.ticket_no = "";
                    pp.piaotypename = "成人票";
                    if (addModel.OrderDetailList[0].PlaceGrade != "无座")
                    {
                        pp.zwcode = TrainTypeEnum.GetTypeCodeByName(addModel.OrderDetailList[0].PlaceGrade);
                        pp.zwname = addModel.OrderDetailList[0].PlaceGrade;
                    }
                    else
                    {
                        //如果当前是无座则根据当前车次选择最低座位
                        List<string> cTypeList = new List<string>() {"G","C","D"};
                        if (!string.IsNullOrEmpty(model.checi) && model.checi.Length > 0
                            && cTypeList.Contains(model.checi.Substring(0, 1).ToUpper()))
                        {
                            pp.zwcode = TrainTypeEnum.GetTypeCodeByName("二等座");
                            pp.zwname = "二等座";
                        }
                        else
                        {
                            pp.zwcode = TrainTypeEnum.GetTypeCodeByName("硬座");
                            pp.zwname = "硬座";
                        }
                    }
                    pp.cxin = "";
                    pp.price = addModel.OrderDetailList[0].FacePrice.ToString("0.00");
                    model.passengers.Add(pp);
                }
                #endregion
                responseModel = _requestHoldSeatBll.RequestHoldSeatInterface(model);
            }
            else
            {
                responseModel = new TraOrderSubmitResponseModel()
                {
                    success=true, orderid = "Test"+DateTime.Now.ToString("yyyyMMddHHmmssfff")
                };
            }
            #region 请求成功后操作
            if (responseModel.success)//请求占位成功
            {
                int count =
                    _traInterFaceOrderDal.Query<TraInterFaceOrderEntity>(a => a.Transactionid == responseModel.orderid,
                        true).Count();
                if (count == 0)//如果没有当前接口的订单号，则插入该条信息
                {
                    TraInterFaceOrderEntity traInterFaceOrderEntity = new TraInterFaceOrderEntity
                    {
                        CreateTime = DateTime.Now,
                        OrderId = addModel.Order.OrderId.ToString(),
                        Status = (int)OrderTypeEnum.ApplyHoldSeat,
                        Transactionid = responseModel.orderid
                    };
                    traInterFaceOrderEntity =
                        _traInterFaceOrderDal.Insert<TraInterFaceOrderEntity>(traInterFaceOrderEntity);

                    _traOrderOperateDal.Insert<TraOrderOperateEntity>(new TraOrderOperateEntity()
                    {
                        AfterOperateStatus = (int)OrderTypeEnum.MakingTicket,
                        InterfaceId = traInterFaceOrderEntity.InterfaceId,
                        Operate = (int)OrderTypeEnum.ApplyHoldSeat,
                        OperateTime = traInterFaceOrderEntity.CreateTime
                    });

                }

            } 
            #endregion

            return responseModel;
        }
    }
}
