using System;
using Mzl.Common.EnumHelper.ElongEnum;

namespace Mzl.DomainModel.Hotel.Elong.HotelInfo
{
    public class QueryHotelDetailRequestModel
    {
        /// <summary>
        /// 入住日期
        /// </summary>
        public DateTime ArrivalDate { get; set; }
        /// <summary>
        /// 离店日期
        /// </summary>
        public DateTime DepartureDate { get; set; }
        /// <summary>
        /// 酒店ID列表
        /// </summary>
        public string HotelIds { get; set; }
        /// <summary>
        /// 房型编号
        /// 当RatePlanId传值的时候不能为空。V1.10后对应销售房型编号 
        /// </summary>
        public string RoomTypeId { get; set; }
        /// <summary>
        /// 产品编码
        /// </summary>
        public int RatePlanId { get; set; }
        /// <summary>
        /// 默认为All，All-不限、SelfPay-现付、Prepay-预付
        /// </summary>
        public EnumPaymentType PaymentType { get; set; }
        /// <summary>
        /// 预付发票模式
        /// </summary>
        public string InvoiceMode { get; set; }
        /// <summary>
        /// 房间入住人数
        /// 默认为0。结果返回的酒店中将包含至少一个房间的可容纳人数大于等于该值，小于该值的房型将会过滤掉 
        /// </summary>
        public int CheckInPersonAmount { get; set; }

        /// <summary>
        /// 其他条件（仅单酒店有效，可逗号分割）
        /// 1.酒店详情
        /// 2.房型
        /// 3.图片
        /// 4.当前不可销售的rp不出现在结果里（该选项多个酒店也有效）
        /// 5. 每日价格数组输出未DRR计算的原始价格
        /// 7. 返回汇率信息#ExchangeRateList
        /// 8. 经纬度返回百度坐标
        /// 9. 仅返回钟点房
        /// </summary>
        public string Options { get; set; }
    }
}
