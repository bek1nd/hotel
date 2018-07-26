using Mzl.EntityModel.Hotel.Elong;
using Mzl.Common.EnumHelper.ElongEnum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mzl.Proxy.Hotel.Elong.Order
{
    /// <summary>
    /// 第三方接口订单相关
    /// </summary>
    public class OrderProxy : IOrderProxy
    {
        /// <summary>
        /// 创建订单
        /// </summary>
        /// <param name="condition"></param>
        /// <returns></returns>
        public OrderCreateResponse OrderCreate(OrderCreateCondition condition)
        {
            OrderCreateResponse response = new OrderCreateResponse();
            try
            {
                var result = HotelApiAccess.Query<OrderCreateCondition, OrderCreateResponse>(condition, "hotel.order.create");

                if (result.Code == "0")
                {
                    response = result.Result;
                }
                else
                {
                    throw new Exception("接口请求失败:" + result.Code);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return response;
        }

        /// <summary>
        /// 订单详情
        /// </summary>
        /// <param name="condition"></param>
        /// <returns></returns>
        public OrderDetailResponse GetOrderDetail(OrderDetailCondition condition)
        {
            OrderDetailResponse response = new OrderDetailResponse();
            try
            {
                var result = HotelApiAccess.Query<OrderDetailCondition, OrderDetailResponse>(condition, "hotel.order.detail");

                if (result.Code == "0")
                {
                    response = result.Result;
                }
                else
                {
                    throw new Exception("接口请求失败:" + result.Code);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return response;
        }

        /// <summary>
        /// 订单实时状态查询
        /// </summary>
        /// <param name="condition"></param>
        /// <returns></returns>
        public HotelOrderStatus GetOrderStatus(OrderDetailCondition condition)
        {
            HotelOrderStatus response = HotelOrderStatus.B3;
            try
            {
                if (!IsInstantConfirmOrder(condition.OrderId))
                {
                    var result = HotelApiAccess.Query<OrderDetailCondition, OrderDetailResponse>(condition, "hotel.order.detail");

                    if (result.Code == "0")
                    {
                        response = (HotelOrderStatus)Enum.Parse(typeof(HotelOrderStatus), result.Result.Status);
                    }
                    else
                    {
                        throw new Exception("接口请求失败:" + result.Code);
                    }
                }
                else
                {
                    response = HotelOrderStatus.A;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return response;
        }

        /// <summary>
        /// 是否为即时确认订单-即时确认订单是艺龙提高订单快速确认所提供的一项服务，当此订单为即时确认订单时，即是订单状态未变成“已确认“状态，也可以先给客人进行订单确认；
        /// </summary>
        /// <param name="orderId">三方订单Id</param>
        /// <returns></returns>
        public bool IsInstantConfirmOrder(long orderId)
        {
            InstantOrderResponse response = new InstantOrderResponse();
            try
            {
                OrderDetailCondition condition = new OrderDetailCondition() { OrderId = orderId };
                var result = HotelApiAccess.Query<OrderDetailCondition, InstantOrderResponse>(condition, "hotel.order.instant");

                if (result.Code == "0")
                {
                    response = result.Result;
                }
                else
                {
                    throw new Exception("接口请求失败:" + result.Code);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return (response.InstantStatus == EnumInstantStatus.Instant);
        }

        /// <summary>
        /// 修改订单
        /// </summary>
        /// <param name="condition"></param>
        /// <returns></returns>
        public OrderUpdateResponse OrderUpdate(OrderUpdateCondition condition)
        {
            OrderUpdateResponse response = new OrderUpdateResponse();
            try
            {
                var result = HotelApiAccess.Query<OrderUpdateCondition, OrderUpdateResponse>(condition, "hotel.order.update");

                if (result.Code == "0")
                {
                    response = result.Result;
                }
                else
                {
                    throw new Exception("接口请求失败:" + result.Code);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return response;
        }

        /// <summary>
        /// 取消订单
        /// </summary>
        /// <param name="condition"></param>
        /// <returns></returns>
        public bool OrderCancel(OrderCancelCondition condition)
        {
            bool response = false;
            try
            {
                var result = HotelApiAccess.Query<OrderCancelCondition, OrderCancelResponse>(condition, "hotel.order.cancel");

                if (result.Code == "0")
                {
                    response = result.Result.Successs;
                }
                else
                {
                    throw new Exception("接口请求失败:" + result.Code);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return response;
        }

    }
}
