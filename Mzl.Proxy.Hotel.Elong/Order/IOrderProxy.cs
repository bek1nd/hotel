using Mzl.EntityModel.Hotel.Elong;
using Mzl.Common.EnumHelper.ElongEnum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mzl.Proxy.Hotel.Elong.Order
{
    public interface IOrderProxy
    {
        /// <summary>
        /// 创建订单
        /// </summary>
        /// <param name="condition"></param>
        /// <returns></returns>
        OrderCreateResponse OrderCreate(OrderCreateCondition condition);

        /// <summary>
        /// 订单详情
        /// </summary>
        /// <param name="condition"></param>
        /// <returns></returns>
        OrderDetailResponse GetOrderDetail(OrderDetailCondition condition);

        /// <summary>
        /// 订单实时状态查询
        /// </summary>
        /// <param name="condition"></param>
        /// <returns></returns>
        HotelOrderStatus GetOrderStatus(OrderDetailCondition condition);

        /// <summary>
        /// 是否为即时确认订单-即时确认订单是艺龙提高订单快速确认所提供的一项服务，当此订单为即时确认订单时，即是订单状态未变成“已确认“状态，也可以先给客人进行订单确认；
        /// </summary>
        /// <param name="orderId">三方订单Id</param>
        /// <returns></returns>
        bool IsInstantConfirmOrder(long orderId);

        /// <summary>
        /// 修改订单
        /// </summary>
        /// <param name="condition"></param>
        /// <returns></returns>
        OrderUpdateResponse OrderUpdate(OrderUpdateCondition condition);

        /// <summary>
        /// 取消订单
        /// </summary>
        /// <param name="condition"></param>
        /// <returns></returns>
        bool OrderCancel(OrderCancelCondition condition);
        
        //同步订单状态

        //订单列表-半年内,所有-结合本地库
        //库存验证-通过hotel.detail判断
        //订单支付-担保三方操作预授予权-创建订单时采集信用卡

    }
}
