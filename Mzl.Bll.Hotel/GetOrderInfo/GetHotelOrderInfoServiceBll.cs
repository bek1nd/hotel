using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Mzl.DomainModel.Hotel.Order;
using Mzl.IBll.Hotel.GetOrderInfo;
using Mzl.IDAL.Hotel;
using Mzl.EntityModel.Hotel;

namespace Mzl.Bll.Hotel.GetOrderInfo
{
    internal class GetHotelOrderInfoServiceBll : IGetHotelOrderInfoServiceBll
    {
        private readonly IHolOrderDal _holOrderDal;
        private readonly IHolOrderDetailDal _holOrderDetail;
        public GetHotelOrderInfoServiceBll(IHolOrderDal holOrderDal, IHolOrderDetailDal holOrderDetail)
        {
            _holOrderDal = holOrderDal;
            _holOrderDetail = holOrderDetail;
        }

        public HotelOrderInfoModel GetHotelOrderInfoByOrderId(int orderId)
        {
            HolOrderEntity holOrderEntity = _holOrderDal.Find<HolOrderEntity>(orderId);
            if (holOrderEntity==null)
            {
                throw new Exception("查无此订单");
            }
            List<HolOrderDetailEntity> holOrderDetailEntities =
                _holOrderDetail.Query<HolOrderDetailEntity>(n => n.OrderId == orderId, true).ToList();

            HotelOrderInfoModel hotelOrderInfoModel = Mapper.Map<HolOrderEntity, HotelOrderInfoModel>(holOrderEntity);
            hotelOrderInfoModel.HotelOrderDetailList =
                Mapper.Map<List<HolOrderDetailEntity>, List<HotelOrderDetailModel>>(holOrderDetailEntities);


            return hotelOrderInfoModel;
        }
    }
}
