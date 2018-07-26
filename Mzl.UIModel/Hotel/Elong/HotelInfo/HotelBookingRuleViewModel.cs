using System;
using System.ComponentModel;
using Mzl.Common.EnumHelper.ElongEnum;

namespace Mzl.UIModel.Hotel.Elong.HotelInfo
{
    /// <summary>
    /// 酒店预定规则
    /// </summary>
    public class HotelBookingRuleViewModel
    {
        /// <summary>
        /// 规则类型
        /// NeedNationality务必提供客人国籍
        /// PerRoomPerName您预订了N间房，请您提供不少于N的入住客人姓名
        /// ForeignerNeedEnName此酒店要求外宾务必留英文拼写
        /// RejectCheckinTime几点到几点酒店不接受预订 , 此处校验的是下单时的预订时间
        /// NeedPhoneNo务必提供客人手机号(请加在联系人结点Contact上)
        /// </summary>
        [Description("规则类型")]
        public EnumBookingRule TypeCode { get; set; }
        /// <summary>
        /// 预订规则编号
        /// RatePlan.BookingRuleIds将与此关联
        /// </summary>
        [Description("预订规则编号")]
        public long BookingRuleId { get; set; }
        /// <summary>
        /// 描述
        /// </summary>
        [Description("描述")]
        public string Description { get; set; }
        /// <summary>
        /// 日期类型
        /// </summary>
        [Description("日期类型")]
        public string DateType { get; set; }
        /// <summary>
        /// 开始日期
        /// </summary>
        [Description("开始日期")]
        public DateTime? StartDate { get; set; }
        /// <summary>
        /// 结束日期
        /// </summary>
        [Description("结束日期")]
        public DateTime? EndDate { get; set; }
        /// <summary>
        /// 每天开始时间
        /// 针对日期段内每天生效, 当TypeCode 为RejectCheckinTime时表示StartHour到EndHour   酒店不接受预订
        /// </summary>
        [Description("每天开始时间")]
        public DateTime? StartHour { get; set; }
        /// <summary>
        /// 每天结束时间
        /// 针对日期段内每天生效, 当TypeCode 为RejectCheckinTime时表示StartHour到EndHour   酒店不接受预订
        /// </summary>
        [Description("每天结束时间")]
        public DateTime? EndHour { get; set; }
    }
}
