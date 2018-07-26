using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mzl.Common.EnumHelper.ElongEnum
{
    public enum EnumInstantStatus
    {
        /// <summary>
        /// 非即时确认订单
        /// </summary>
        NotInstant,

        /// <summary>
        /// 即时确认订单
        /// </summary>
        Instant,

        /// <summary>
        /// 查询超时-此接口调用有时间限制，即在调用hotel.order.create下单成功后10分钟之内调用，超过10分钟时间将返回查询超时；
        /// </summary>
        Timeout,

        /// <summary>
        /// 输入的订单号无效
        /// </summary>
        InvalidOrderId,
    }
}
