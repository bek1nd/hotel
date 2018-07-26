using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mzl.DomainModel.Enum
{
    public enum OrderTypeEnum
    {
        /// <summary>
        /// 申请占座
        /// </summary>
        [Description("申请占座")]
        ApplyHoldSeat = 0,
        /// <summary>
        /// 占座失败
        /// </summary>
        [Description("占座失败")]
        HoldSeatFail = 1,
        /// <summary>
        /// 占座成功
        /// </summary>
        [Description("占座成功")]
        HoldSeatSuccess = 2,
        /// <summary>
        /// 正在出票
        /// </summary>
        [Description("正在出票")]
        MakingTicket = 3,
        /// <summary>
        /// 出票成功
        /// </summary>
        [Description("出票成功")]
        TicketSuccess = 4,
        /// <summary>
        /// 出票失败
        /// </summary>
        [Description("出票失败")]
        TicketFail = 5,
        /// <summary>
        /// 订单已取消
        /// </summary>
        [Description("订单已取消")]
        OrderCancel = 6,
        /// <summary>
        /// 补单成功
        /// </summary>
        [Description("补单成功")]
        SupplementOrder = 7,
        /// <summary>
        /// 正在退票 
        /// </summary>
        [Description("正在退票 ")]
        ReturnTickets = 8,
        /// <summary>
        /// 退票成功 
        /// </summary>
        [Description("退票成功 ")]
        ReturnTicketsSuccess = 9,
        /// <summary>
        /// 退票失败
        /// </summary>
        [Description("退票失败")]
        ReturnTicketsFail = 10,
        /// <summary>
        /// 改签订单提交
        /// </summary>
        [Description("改签订单提交")]
        ApplyRequestChange = 11,
        /// <summary>
        /// 改签订单取消
        /// </summary>
        [Description("改签订单取消")]
        RequestChangeCancel = 12,
        /// <summary>
        /// 改签订单出票成功
        /// </summary>
        [Description("改签订单已出票")]
        RequestChangeConfirm = 13,
        /// <summary>
        /// 改签占座失败
        /// </summary>
        [Description("改签占座失败")]
        RequestChangeFail = 14,
        /// <summary>
        /// 改签占座成功
        /// </summary>
        [Description("改签占座成功")]
        RequestChangeSuccess = 15,
        /// <summary>
        /// 改签正在出票
        /// </summary>
        [Description("改签正在出票")]
        RequestChangeMakingTicket = 16

    }
}
