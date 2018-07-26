using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Mzl.Common.EnumHelper.ElongEnum;
using Mzl.UIModel.Base;

namespace Mzl.UIModel.Hotel.Elong.HotelInfo
{
    /// <summary>
    /// 查询酒店详情请求实体
    /// </summary>
    public class QueryHotelDetailRequestViewModel : RequestBaseViewModel
    {
        /// <summary>
        /// 入住日期
        /// </summary>
        [Description("入住日期")]
        public DateTime ArrivalDate { get; set; }
        /// <summary>
        /// 离店日期
        /// </summary>
        [Description("离店日期")]
        public DateTime DepartureDate { get; set; }
        /// <summary>
        /// 酒店ID列表
        /// </summary>
        [Required]
        [Description("酒店ID列表")]
        public string HotelIds { get; set; }
        /// <summary>
        /// 房型编号
        /// 当RatePlanId传值的时候不能为空。V1.10后对应销售房型编号 
        /// </summary>
        [Description("房型编号，当RatePlanId传值的时候不能为空")]
        public string RoomTypeId { get; set; }
        /// <summary>
        /// 产品编码
        /// </summary>
        [Description("产品编码")]
        public int RatePlanId { get; set; }
        /// <summary>
        /// 默认为All，All-不限、SelfPay-现付、Prepay-预付
        /// </summary>
        [Description("支付方式")]
        public EnumPaymentType PaymentType { get; set; }
        /// <summary>
        /// 预付发票模式
        /// </summary>
        [Description("预付发票模式")]
        public string InvoiceMode { get; set; }
        /// <summary>
        /// 房间入住人数
        /// 默认为0。结果返回的酒店中将包含至少一个房间的可容纳人数大于等于该值，小于该值的房型将会过滤掉 
        /// </summary>
        [Description("房间入住人数")]
        public int CheckInPersonAmount { get; set; }

        /// <summary>
        /// 其他条件（仅单酒店有效，可逗号分割）
        /// 1.酒店详情2.房型 3.图片4.当前不可销售的rp不出现在结果里（该选项多个酒店也有效）5. 每日价格数组输出未DRR计算的原始价格7. 返回汇率信息#ExchangeRateList8. 经纬度返回百度坐标9. 仅返回钟点房
        /// </summary>
        [Description("其他条件，默认1,2,3,4,8；1.酒店详情2.房型 3.图片4.当前不可销售的rp不出现在结果里（该选项多个酒店也有效）5. 每日价格数组输出未DRR计算的原始价格7. 返回汇率信息#ExchangeRateList8. 经纬度返回百度坐标9. 仅返回钟点房")]
        public string Options { get; set; } = "1,2,3,4,8";
    }
}
