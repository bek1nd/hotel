using System;
using System.ComponentModel;

namespace Mzl.DomainModel.Hotel.Elong.HotelInfo
{
    public class HotelNightlyRatesModel
    {
        /// <summary>
        /// 当天日期
        /// </summary>
        [Description("当天日期")]
        public DateTime Date { get; set; }

        /// <summary>
        /// 会员价
        /// 
        /// 已经通过DRR的计算可以直接显示给客人.。价格为-1表示不能销售。
        /// </summary>
        [Description("会员价")]
        public decimal Member { get; set; }

        /// <summary>
        /// 结算价
        /// 
        /// 仅结算价模式下的预付产品
        /// </summary>
        [Description("结算价,仅结算价模式下的预付产品")]
        public decimal Cost { get; set; }

        /// <summary>
        /// 原始价格
        /// 未经过DRR计算过的原始价格，入参Options包含5的时候返回
        /// </summary>
        [Description("原始价格")]
        public decimal? Basis { get; set; }

        /// <summary>
        /// 库存状态
        /// 表示当天库存是否可用
        /// </summary>
        [Description("库存状态")]
        public bool Status { get; set; }

        /// <summary>
        /// -1表示不能加床
        /// </summary>
        [Description("-1表示不能加床")]
        public decimal? AddBed { get; set; }

        /// <summary>
        ///早餐份数
        /// </summary>
        [Description("早餐份数")]
        public int? BreakfastCount { get; set; }
        /// <summary>
        /// 每日优惠
        /// </summary>
        [Description("每日优惠")]
        public decimal? Coupon { get; set; }
    }
}
