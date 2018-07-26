using System;
using Mzl.Common.EnumHelper.ElongEnum;

namespace Mzl.DomainModel.Hotel.Elong.HotelInfo
{
    /// <summary>
    /// 促销规则
    /// </summary>
    public class HotelDrrRuleModel
    {
        /// <summary>
        /// 促销规则编号
        /// </summary>
        public int DrrRuleId { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string Description { get; set; }


        /// <summary>
        /// 产品促销规则类型代码
        /// </summary>
        public EnumDrrRuleCode TypeCode { get; set; }

        /// <summary>
        /// 日期类型
        /// 
        /// CheckInDay:入住日期 
        /// StayDay:在店日期 
        /// BookDay:预订日期
        /// </summary>
        public EnumDateType DateType { get; set; }

        /// <summary>
        /// 促销生效开始日期
        /// </summary>
        public DateTime StartDate { get; set; }

        /// <summary>
        /// 促销生效结束日期
        /// </summary>
        public DateTime EndDate { get; set; }

        /// <summary>
        /// 提前几天
        /// </summary>
        public int DayNum { get; set; }

        /// <summary>
        /// 连住几天
        /// </summary>
        public int CheckInNum { get; set; }

        /// <summary>
        /// 每连住几晚
        /// </summary>
        public int EveryCheckInNum { get; set; }

        /// <summary>
        /// 最后几天
        /// </summary>
        public int LastDayNum { get; set; }

        /// <summary>
        /// 第几晚及以后优惠
        /// </summary>
        public int WhichDayNum { get; set; }

        /// <summary>
        /// 按金额或按比例来优惠
        /// </summary>
        public EnumDrrPreferential CashScale { get; set; }

        /// <summary>
        /// 按金额或比例优惠的数值
        /// 
        /// 当CashScale为Percent时，该值保存的为百分数，例如30%
        /// </summary>
        public decimal DeductNum { get; set; }

        /// <summary>
        /// 星期有效设置
        /// 
        /// 日期符合Weekset中的周设置，才享受 feetype所对应的价格
        /// 仅DRRStayWeekDay和DRRCheckInWeekDay的时候使用
        /// </summary>
        public string WeekSet { get; set; }

        /// <summary>
        /// 价格类型
        /// </summary>
        public EnumDrrFeeType FeeType { get; set; }
    }
}
