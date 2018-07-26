using System.ComponentModel;

namespace Mzl.Common.EnumHelper
{
    /// <summary>
    /// 支付方式
    /// </summary>
    public enum PayTypeEnum
    {
        /// <summary>
        /// 现金支付
        /// </summary>
        [Description("现金支付")]
        Cas,
        /// <summary>
        /// POS机刷卡
        /// </summary>
        [Description("POS机刷卡")]
        Pos,
        /// <summary>
        /// 信用卡扣款
        /// </summary>
        [Description("信用卡扣款")]
        Cre,
        /// <summary>
        /// 银行汇款
        /// </summary>
        [Description("银行汇款")]
        Ban,
        /// <summary>
        /// 公司付款
        /// </summary>
        [Description("公司付款")]
        Cro,
        /// <summary>
        /// 支票支付
        /// </summary>
        [Description("支票支付")]
        Chk,
        /// <summary>
        /// U8账户
        /// </summary>
        [Description("U8账户")]
        Acc,
        /// <summary>
        /// 支付宝
        /// </summary>
        [Description("支付宝")]
        Zfb,
        /// <summary>
        /// 微支付
        /// </summary>
        [Description("微支付")]
        Wzf
    }
}
