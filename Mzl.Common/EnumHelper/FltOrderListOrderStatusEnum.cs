using System.ComponentModel;

namespace Mzl.Common.EnumHelper
{
    /// <summary>
    /// 机票订单列表中的订单状态
    /// </summary>
    public enum FltOrderListOrderStatusEnum
    {
        /// <summary>
        /// 待出票
        /// </summary>
        [Description("待出票")]
        WaitTicket =1,
        /// <summary>
        /// 出票中
        /// </summary>
        [Description("出票中")]
        Ticketing =2,
        /// <summary>
        /// 已出票
        /// </summary>
        [Description("已出票")]
        Ticketed =3,
        /// <summary>
        /// 部分退
        /// </summary>
        [Description("部分退")]
        PartRefunded = 4,
        /// <summary>
        /// 全部退
        /// </summary>
        [Description("全部退")]
        AllRefunded = 5,
        /// <summary>
        /// 已取消
        /// </summary>
        [Description("已取消")]
        Cancel,
        /// <summary>
        /// 审批中
        /// </summary>
        [Description("审批中")]
        Aduiting
    }
}
