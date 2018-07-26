using System;
using System.ComponentModel;
using Mzl.Common.EnumHelper.ElongEnum;

namespace Mzl.UIModel.Hotel.Elong.HotelInfo
{
    public class HotelPrepayRuleViewModel
    {
        /// <summary>
        /// 规则编码
        /// </summary>
        [Description("规则编码")]
        public int PrepayRuleId { get; set; }

        /// <summary>
        /// 描述
        /// </summary>
        [Description("描述")]
        public string Description { get; set; }

        /// <summary>
        /// 日期类型
        /// 
        /// CheckInDay：入住日期
        /// </summary>
        [Description("日期类型")]
        public EnumDateType DateType { get; set; }

        /// <summary>
        /// 开始日期
        /// 
        /// hotel.list 和 hotel.detail的内部逻辑对这三个属性已经判断了, 可以不进行额外的判断。
        /// </summary>
        [Description("开始日期")]
        public DateTime? StartDate { get; set; }

        /// <summary>
        /// 结束日期
        /// 
        /// hotel.list 和 hotel.detail的内部逻辑对这三个属性已经判断了, 可以不进行额外的判断。
        /// </summary>
        [Description("结束日期")]
        public DateTime? EndDate { get; set; }

        /// <summary>
        /// 周有效设置
        /// 
        /// hotel.list 和 hotel.detail的内部逻辑对这三个属性已经判断了, 可以不进行额外的判断。
        /// </summary>
        [Description("周有效设置")]
        public string WeekSet { get; set; }

        /// <summary>
        /// 变更规则
        /// </summary>
        [Description("变更规则")]
        public EnumPrepayChangeRule ChangeRule { get; set; }
        /// <summary>
        /// 变更规则描述
        /// </summary>
        [Description("变更规则描述")]
        public string ChangeRuleDesc { get; set; }

        /// <summary>
        /// 具体取消时间日期部分
        /// 
        /// 用于 PrepayNeedOneTime
        /// </summary>
        [Description("具体取消时间日期部分")]
        public DateTime? DateNum { get; set; }


        /// <summary>
        /// 具体取消时间小时部分
        /// 
        /// 用于 PrepayNeedOneTime
        /// </summary>
        [Description("具体取消时间小时部分")]
        public string Time { get; set; }

        /// <summary>
        /// 在变更时间点前是否扣费
        /// 
        /// 用于 PrepayNeedSomeDay的Hour前扣款类型（一般不收罚金）
        /// </summary>
        [Description("在变更时间点前是否扣费")]
        public int? DeductFeesBefore { get; set; }


        /// <summary>
        /// 时间点前扣费的金额或比例
        /// 
        /// 用于 PrepayNeedSomeDay的Hour前扣款类型（一般不收罚金）
        /// </summary>
        [Description("时间点前扣费的金额或比例")]
        public decimal? DeductNumBefore { get; set; }

        /// <summary>
        /// 时间点后扣款类型
        /// </summary>
        [Description("时间点后扣款类型")]
        public EnumPrepayCutPayment? CashScaleFirstAfter { get; set; }

        /// <summary>
        /// 在变更时间点后是否扣费
        /// 
        /// 用于 PrepayNeedSomeDay的Hour到Hour2之间的扣款类型
        /// </summary>
        [Description("在变更时间点后是否扣费")]
        public int? DeductFeesAfter { get; set; }

        /// <summary>
        /// 时间点后扣费的金额或比例
        /// 
        /// 用于 PrepayNeedSomeDay的Hour到Hour2之间的扣款类型
        /// </summary>
        [Description("时间点后扣费的金额或比例")]
        public decimal? DeductNumAfter { get; set; }

        /// <summary>
        /// 时间点前扣款类型
        /// </summary>
        [Description("时间点前扣款类型")]
        public EnumPrepayCutPayment? CashScaleFirstBefore { get; set; }

        /// <summary>
        /// 第一阶段提前几小时
        /// 
        /// 用于 PrepayNeedSomeDay
        /// </summary>
        [Description("第一阶段提前几小时")]
        public int? Hour { get; set; }

        /// <summary>
        /// 第二阶段提前几小时
        /// 
        /// 用于 PrepayNeedSomeDay
        /// </summary>
        [Description("第二阶段提前几小时")]
        public int? Hour2 { get; set; }
    }
}
