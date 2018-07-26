using System.ComponentModel;

namespace Mzl.Common.EnumHelper
{
    public enum MojoryApiResponseCode
    {
        /// <summary>
        /// Error
        /// </summary>
        [Description("Error")]
        Error = -99,
        /// <summary>
        /// Success
        /// </summary>
        [Description("Success")]
        Success = 0,
        /// <summary>
        /// 初始Token,只允许访问登录Api
        /// </summary>
        [Description("初始Token,只允许访问登录Api")]
        InitialToken = 1,
        /// <summary>
        ///被禁止的Token，不允许访问任何Api和页面
        /// </summary>
        [Description("被禁止的Token，不允许访问任何Api和页面")]
        NoAllowToken = 2,
        /// <summary>
        /// 请求参数异常
        /// </summary>
        [Description("请求参数异常")]
        NoValid =3,
        /// <summary>
        /// 不在白名单内
        /// </summary>
        [Description("不在白名单内")]
        NotInWhiteList =4,
        /// <summary>
        /// 查无此订单
        /// </summary>
        [Description("查无此订单")]
        NoFindOrder = 5,
        /// <summary>
        /// 当前版本已过期，请更新app
        /// </summary>
        [Description("当前版本已过期，请更新app")]
        NoAllowVision = 6,

        /// <summary>
        /// 验证码错误
        /// </summary>
        [Description("验证码错误，请重新输入验证码")]
        VerifyCodeError = 7,
        /// <summary>
        /// 手机号码已存在
        /// </summary>
        [Description("手机号码已存在，无法更新")]
        MobileExist = 8,
        /// <summary>
        /// 手机号码格式错误
        /// </summary>
        [Description("手机号码格式错误")]
        MobileError = 9,
        /// <summary>
        /// 存在相同乘机人与航程的订单
        /// </summary>
        [Description("存在相同乘机人与航程的订单")]
        SameFlight =10,
        /// <summary>
        /// 审批单中的订单已经取消
        /// </summary>
        [Description("审批单中的订单已经取消")]
        AduitCancelOrder=11,
        /// <summary>
        /// 存在未使用的票号
        /// </summary>
        [Description("存在未使用的票号")]
        HasUnUsedTicketNo =12
    }
}
