using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mzl.Common.CacheHelper
{
    /// <summary>
    /// 缓存Key
    /// </summary>
    public enum CacheKeyEnum
    {
        /// <summary>
        /// 保险产品
        /// </summary>
        InsuranceProduct,
        OnlineInsuranceProduct,
        /// <summary>
        /// 机场查询结果
        /// </summary>
        AirportSearch,
        /// <summary>
        /// 舱位等级
        /// </summary>
        FltClassName,
        /// <summary>
        /// 协议白名单
        /// </summary>
        WhitePassengerList,
        /// <summary>
        /// B2T航班
        /// </summary>
        B2TFlightNo,
        /// <summary>
        /// 客户信息
        /// </summary>
        CustomerInfo,
        /// <summary>
        /// 火车弥补服务
        /// </summary>
        TrainMakeUp,
        /// <summary>
        /// 艺龙国内酒店城市
        /// </summary>
        ElongHotelDomesticCity,

        /// <summary>
        /// 客户手机短信验证码
        /// </summary>
        CustomerMobileVerifyCode,

        /// <summary>
        /// 携程酒店城市信息
        /// </summary>
        CTripHotelCityCN,

        /// <summary>
        /// 携程酒店城市英文信息
        /// </summary>
        CTripHotelCityEN
    }
}
