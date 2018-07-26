using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Mzl.DomainModel.Train.Order;
using Mzl.EntityModel.Train.Order;
using Mzl.Framework.Base;
using Mzl.IBLL.Train.Order;
using Mzl.IDAL.Train;

namespace Mzl.BLL.Train.Order
{
    internal class GetTraOrderBll: BaseBll,IGetTraOrderBll
    {
        private readonly ITraOrderDal _traOrderDal;
        private readonly ITraOrderStatusDal _traOrderStatusDal;
        private readonly ITraOrderDetailDal _traOrderDetailDal;
        private readonly ITraPassengerDal _traPassengerDal;
        private readonly ITraOrderLogDal _traOrderLogDal;
        private readonly ITraAddressDal _traAddressDal;
        public GetTraOrderBll(ITraOrderDal traOrderDal, ITraOrderStatusDal traOrderStatusDal,
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
        public TraOrderInfoModel GetTraOrderByOrderId(int orderId)
        {
            TraOrderEntity traOrderEntity= _traOrderDal.Find<TraOrderEntity>(orderId);
            if (traOrderEntity == null)
                return null;
            TraOrderModel traOrderModel = Mapper.Map<TraOrderEntity, TraOrderModel>(traOrderEntity);

            TraOrderStatusEntity traOrderStatusEntity =
                _traOrderStatusDal.Query<TraOrderStatusEntity>(n => n.OrderId == orderId, true).FirstOrDefault();
            TraOrderStatusModel  traOrderStatusModel= Mapper.Map<TraOrderStatusEntity, TraOrderStatusModel>(traOrderStatusEntity);

            List<TraOrderDetailEntity> traOrderDetailEntities =
                _traOrderDetailDal.Query<TraOrderDetailEntity>(n => n.OrderId == orderId, true).ToList();
            List<TraOrderDetailModel> traOrderDetailModels =
                Mapper.Map<List<TraOrderDetailEntity>, List<TraOrderDetailModel>>(traOrderDetailEntities);
            List<int> odIdList = new List<int>();
            traOrderDetailModels.ForEach(n => odIdList.Add(n.OdId));

            List<TraPassengerEntity> traPassengerEntities =
                _traPassengerDal.Query<TraPassengerEntity>(n => odIdList.Contains(n.OdId), true).ToList();
            List<TraPassengerModel> traPassengerModels =
                Mapper.Map<List<TraPassengerEntity>, List<TraPassengerModel>>(traPassengerEntities);
            foreach (var detail in traOrderDetailModels)
            {
                detail.PassengerList = new List<TraPassengerModel>();
                var passengerModel = traPassengerModels.FindAll(n => n.OdId == detail.OdId);
                detail.PassengerList.AddRange(passengerModel);
            }

            TraOrderInfoModel orderInfoModel = new TraOrderInfoModel();
            orderInfoModel.Order = traOrderModel;
            orderInfoModel.OrderStatus = traOrderStatusModel;
            orderInfoModel.OrderDetailList = traOrderDetailModels;
            return orderInfoModel;
        }
    }
}
