using System.Collections.Generic;
using System.ComponentModel;
using Mzl.Common.EnumHelper.ElongEnum;

namespace Mzl.DomainModel.Hotel.Elong.HotelInfo
{
    public class HotelRatePlanModel
    {

        /// <summary>
        /// 产品编号
        /// </summary>
        [Description("产品信息")]
        public int RatePlanId { get; set; }

        /// <summary>
        /// 产品名称
        /// </summary>
        [Description("产品名称")]
        public string RatePlanName { get; set; }


        /// <summary>
        /// 销售状态
        /// 
        /// false--不可销售（可能是满房、部分日期满房、缺少价格）、true--可销售
        /// </summary>
        [Description("销售状态")]
        public bool Status { get; set; }

        /// <summary>
        /// 销售房型编号
        /// 
        /// V1.10新增，用于hotel.order.create中的入参RoomTypeId
        /// </summary>
        [Description("销售房型编号")]
        public string RoomTypeId { get; set; }


        /// <summary>
        /// 供应商房型附加名称
        /// 
        /// V1.10新增, 房型信息的补充说明
        /// </summary>
        [Description("供应商房型附加名称")]
        public string SuffixName { get; set; }


        /// <summary>
        /// 供应商酒店编码
        /// </summary>
        [Description("供应商酒店编码")]
        public string HotelCode { get; set; }

        /// <summary>
        /// 客人类型
        /// </summary>
        [Description("客人类型")]
        public EnumGuestTypeCode? CustomerType { get; set; }

        /// <summary>
        /// 房量限额
        /// 
        /// 入住时间内不能超售的最小值。当大于0小于5时，表示目前仅剩的房量;0表示房量充足
        /// </summary>
        [Description("房量限额")]
        public int? CurrentAlloment { get; set; }

        /// <summary>
        /// 是否支持即时确认
        /// 
        /// 表示这个产品是否支持即时确认。最终的订单是否是即时确认还需调用即时确认接口来验证
        /// </summary>
        [Description("是否支持即时确认")]
        public bool? InstantConfirmation { get; set; }

        /// <summary>
        /// 付款类型
        /// </summary>
        [Description("付款类型")]
        public EnumPaymentType PaymentType { get; set; }


        /// <summary>
        /// 对应的预订规则编号
        /// </summary>
        [Description("对应的预订规则编号")]
        public string BookingRuleIds { get; set; }

        /// <summary>
        /// 对应的担保规则编号
        /// </summary>
        [Description("对应的担保规则编号")]
        public string GuaranteeRuleIds { get; set; }

        /// <summary>
        /// 对应的预付规则编号
        /// </summary>
        [Description("对应的预付规则编号")]
        public string PrepayRuleIds { get; set; }

        /// <summary>
        /// 对应的促销规则编号
        /// </summary>
        [Description("对应的促销规则编号")]
        public string DrrRuleIds { get; set; }

        /// <summary>
        /// 对应的增值服务编号
        /// </summary>
        [Description("对应的增值服务编号")]
        public string ValueAddIds { get; set; }


        /// <summary>
        /// 产品特性类型
        /// 
        /// 版本1.08新增。可逗号分隔，目前取值：
        /// 3-限时抢购
        /// 4-钟点房
        /// 5-手机专享
        /// </summary>
        [Description("产品特性类型")]
        public string ProductTypes { get; set; }

        /// <summary>
        /// 是否今日特价
        /// IsLastMinuteSale == true的时候再判断StartTime和EndTime
        /// </summary>
        [Description("是否今日特价")]
        public bool? IsLastMinuteSale { get; set; }

        /// <summary>
        /// 每天可以销售的开始时间
        /// </summary>
        [Description("每天可以销售的开始时间")]
        public string StartTime { get; set; }

        /// <summary>
        /// 每天可以销售的结束时间
        /// </summary>
        [Description("每天可以销售的结束时间")]
        public string EndTime { get; set; }

        /// <summary>
        /// 预定最少数量
        /// </summary>
        [Description("预定最少数量")]
        public int? MinAmount { get; set; }

        /// <summary>
        /// 最少入住天数
        /// </summary>
        [Description("最少入住天数")]
        public int? MinDays { get; set; }

        /// <summary>
        /// 最多入住天数
        /// </summary>
        [Description("最多入住天数")]
        public int? MaxDays { get; set; }

        /// <summary>
        /// 总价
        /// 
        /// 已经通过DRR的计算可以直接显示给客人。价格为-1表示不能销售。
        /// </summary>
        [Description("总价")]
        public decimal? TotalRate { get; set; }

        /// <summary>
        /// 日均价
        /// 
        /// 已经通过DRR的计算可以直接显示给客人。价格为-1表示不能销售。
        /// </summary>
        [Description("日均价")]
        public decimal? AverageRate { get; set; }

        /// <summary>
        /// 促销前的日均价
        /// </summary>
        [Description("促销前的日均价")]
        public decimal? AverageBaseRate { get; set; }

        /// <summary>
        /// 货币
        /// </summary>
        [Description("货币")]
        public EnumCurrencyCode? CurrencyCode { get; set; }

        /// <summary>
        /// 优惠券
        /// </summary>
        [Description("优惠券")]
        public decimal? Coupon { get; set; }

        /// <summary>
        /// 每天价格数组
        /// </summary>
        [Description("每天价格数组")]
        public List<HotelNightlyRatesModel> NightlyRates { get; set; }


        /// <summary>
        /// 礼品ID
        /// </summary>
        [Description("礼品ID")]
        public string GiftIds { get; set; }
        /// <summary>
        /// 预付产品发票模式
        /// Hotel -- 酒店开具,Elong -- 艺龙开具
        /// </summary>
        [Description("预付产品发票模式")]
        public string InvoiceMode { get; set; }
        /// <summary>
        /// 产品可以展示销售的渠道
        /// </summary>
        [Description("产品可以展示销售的渠道")]
        public string BookingChannels { get; set; }


    }
}
