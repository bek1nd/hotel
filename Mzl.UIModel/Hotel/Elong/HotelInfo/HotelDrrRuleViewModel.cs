using System;
using System.ComponentModel;
using Mzl.Common.EnumHelper.ElongEnum;

namespace Mzl.UIModel.Hotel.Elong.HotelInfo
{
    /// <summary>
    /// 促销规则
    /// </summary>
    public class HotelDrrRuleViewModel
    {
        /// <summary>
        /// 促销规则编号
        /// </summary>
        [Description("促销规则编号")]
        public int DrrRuleId { get; set; }

        /// <summary>
        /// 描述
        /// </summary>
        [Description("描述")]
        public string Description { get; set; }


        /// <summary>
        /// 产品促销规则类型代码
        /// </summary>
        [Description("产品促销规则类型代码")]
        public EnumDrrRuleCode TypeCode { get; set; }

        /// <summary>
        /// 日期类型
        /// 
        /// CheckInDay:入住日期 
        /// StayDay:在店日期 
        /// BookDay:预订日期
        /// </summary>
        [Description("日期类型")]
        public EnumDateType DateType { get; set; }

        /// <summary>
        /// 促销生效开始日期
        /// </summary>
        [Description("促销生效开始日期")]
        public DateTime StartDate { get; set; }

        /// <summary>
        /// 促销生效结束日期
        /// </summary>
        [Description("促销生效结束日期")]
        public DateTime EndDate { get; set; }

        /// <summary>
        /// 提前几天
        /// </summary>
        [Description("提前几天")]
        public int DayNum { get; set; }

        /// <summary>
        /// 连住几天
        /// </summary>
        [Description("连住几天")]
        public int CheckInNum { get; set; }

        /// <summary>
        /// 每连住几晚
        /// </summary>
        [Description("每连住几晚")]
        public int EveryCheckInNum { get; set; }

        /// <summary>
        /// 最后几天
        /// </summary>
        [Description("最后几天")]
        public int LastDayNum { get; set; }

        /// <summary>
        /// 第几晚及以后优惠
        /// </summary>
        [Description("第几晚及以后优惠")]
        public int WhichDayNum { get; set; }

        /// <summary>
        /// 按金额或按比例来优惠
        /// </summary>
        [Description("按金额或按比例来优惠")]
        public EnumDrrPreferential CashScale { get; set; }

        /// <summary>
        /// 按金额或比例优惠的数值
        /// 
        /// 当CashScale为Percent时，该值保存的为百分数，例如30%
        /// </summary>
        [Description("按金额或比例优惠的数值")]
        public decimal DeductNum { get; set; }

        /// <summary>
        /// 星期有效设置
        /// 
        /// 日期符合Weekset中的周设置，才享受 feetype所对应的价格
        /// 仅DRRStayWeekDay和DRRCheckInWeekDay的时候使用
        /// </summary>
        [Description("星期有效设置")]
        public string WeekSet { get; set; }

        /// <summary>
        /// 价格类型
        /// </summary>
        [Description("价格类型")]
        public EnumDrrFeeType FeeType { get; set; }
    }
}
