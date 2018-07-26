using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mzl.Common.EnumHelper.ElongEnum
{
    /// <summary>
    /// 订单状态
    /// </summary>
    public enum HotelOrderStatus
    {
        /// <summary>
        /// 已确认
        /// </summary>
        [Description("已确认")]
        A,
        /// <summary>
        /// NO SHOW
        /// </summary>
        [Description("NO SHOW")]
        B,
        /// <summary>
        /// 有预定未查到
        /// </summary>
        [Description("有预定未查到")]
        B1,
        /// <summary>
        /// 待查
        /// </summary>
        [Description("待查")]
        B2,
        /// <summary>
        /// 暂不确定
        /// </summary>
        [Description("暂不确定")]
        B3,
        /// <summary>
        /// 已结帐
        /// </summary>
        [Description("已结帐")]
        C,
        [Description("删除")]
        D,
        /// <summary>
        /// 取消
        /// </summary>
        [Description("取消")]
        E,
        [Description("已入住")]
        F,
        [Description("变价")]
        G,
        [Description("变更")]
        H,
        [Description("大单")]
        I,
        /// <summary>
        /// 新单
        /// </summary>
        [Description("新单")]
        N,
        [Description("满房")]
        O,
        [Description("暂无价格")]
        P,
        [Description("特殊")]
        S,
        [Description("计划中")]
        T,
        [Description("特殊满房")]
        U,
        [Description("已审")]
        V,
        [Description("虚拟")]
        W,
        [Description("删除,另换酒店")]
        Z,
    }
}
