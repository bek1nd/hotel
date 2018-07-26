using System;
using System.ComponentModel;
using Mzl.Common.EnumHelper.ElongEnum;

namespace Mzl.UIModel.Hotel.Elong.HotelInfo
{
    public class HotelGuaranteeRuleViewModel
    {
        /// <summary>
        /// 担保规则编号
        /// </summary>
        [Description("担保规则编号")]
        public int GuranteeRuleId { get; set; }

        /// <summary>
        /// 描述
        /// </summary>
        [Description("描述")]
        public string Description { get; set; }

        /// <summary>
        /// 日期类型
        /// CheckInDay-入住日期
        /// StayDay-在店日期
        /// </summary>
        [Description("日期类型")]
        public EnumDateType DateType { get; set; }

        /// <summary>
        /// 开始日期
        /// 
        /// 举例：DateType为CheckInDay：表示当前订单的入住日期落在StartDate和EndDate之间，并且入住日期符合周设置时才需要判断其它条件是否担保，否则不需要担保DateType为StayDay：表示当前订单的客人只要有住在店里面的日期（[ArrivalDate,DepartureDate））落在StartDate和EndDate之间，并且入住日期符合周设置时才需要判断其它条件是否担保，否则不需要担保
        /// </summary>
        [Description("开始日期")]
        public DateTime StartDate { get; set; }

        /// <summary>
        /// 结束日期
        /// 
        /// 举例：DateType为CheckInDay：表示当前订单的入住日期落在StartDate和EndDate之间，并且入住日期符合周设置时才需要判断其它条件是否担保，否则不需要担保DateType为StayDay：表示当前订单的客人只要有住在店里面的日期（[ArrivalDate,DepartureDate））落在StartDate和EndDate之间，并且入住日期符合周设置时才需要判断其它条件是否担保，否则不需要担保
        /// </summary>
        [Description("结束日期")]
        public DateTime EndDate { get; set; }

        /// <summary>
        /// 周有效天数， 一般为周一到周日都有效， 判断日期符合日期段同时也要满足周设置的有效 
        /// 周一对应为1，周二对应为2， 依次类推;逗号分隔
        /// 
        /// 举例：DateType为CheckInDay：表示当前订单的入住日期落在StartDate和EndDate之间，并且入住日期符合周设置时才需要判断其它条件是否担保，否则不需要担保DateType为StayDay：表示当前订单的客人只要有住在店里面的日期（[ArrivalDate,DepartureDate））落在StartDate和EndDate之间，并且入住日期符合周设置时才需要判断其它条件是否担保，否则不需要担保
        /// </summary>
        [Description("周有效天数")]
        public string WeekSet { get; set; }

        /// <summary>
        /// 是否到店时间担保
        /// 
        /// False:为不校验到店时间
        /// True:为需要校验到店时间
        /// </summary>
        [Description("是否到店时间担保")]
        public bool IsTimeGuarantee { get; set; }

        /// <summary>
        /// 到店担保开始时间
        /// 
        /// Yeano：文档中类型为Time，Demo中为String
        /// 
        /// 用于IsTimeGuarantee ==true进行检查。
        /// [补充]当EndTime小于StartTime的时候，默认从StartTime到次日6点都需要担保。
        /// </summary>
        [Description("到店担保开始时间")]
        public string StartTime { get; set; }

        /// <summary>
        /// 到店担保结束时间
        /// 
        /// Yeano：文档中类型为Time，Demo中为String
        /// 
        /// 用于IsTimeGuarantee ==true进行检查。
        /// [补充]当EndTime小于StartTime的时候，默认从StartTime到次日6点都需要担保。
        /// </summary>
        [Description("到店担保结束时间")]
        public string EndTime { get; set; }

        /// <summary>
        /// 到店担保的结束时间是否为第二天 ; 0为当天，1为次日
        /// 
        /// Yeano：文档中类型为Time，Demo中为String
        /// 
        /// 用于IsTimeGuarantee ==true进行检查。
        /// [补充]当EndTime小于StartTime的时候，默认从StartTime到次日6点都需要担保。
        /// </summary>
        [Description("到店担保的结束时间是否为第二天")]
        public bool? IsTomorrow { get; set; }

        /// <summary>
        /// 是否房量担保
        /// 
        /// False:为不校验房量条件
        /// True:为校验房量条件
        /// </summary>
        [Description("是否房量担保")]
        public bool IsAmountGuarantee { get; set; }

        /// <summary>
        /// 担保的房间数,预定几间房以上要担保
        /// 
        /// 用于IsAmountGuarantee ==true进行检查
        /// </summary>
        [Description("担保的房间数,预定几间房以上要担保")]
        public int? Amount { get; set; }

        /// <summary>
        /// 担保类型
        /// </summary>
        [Description("担保类型")]
        public EnumGuaranteeMoneyType? GuaranteeType { get; set; }

        /// <summary>
        /// 变更规则
        /// 
        ///  担保规则条数，规则NoChange、不允许变更取消 NeedSomeDay、允许变更/取消,需在XX日YY时之前通知NeedCheckinTime、允许变更/取消,需在最早到店时间之前几小时通知NeedCheckin24hour、允许变更/取消,需在到店日期的24点之前几小时通知
        /// </summary>
        [Description("变更规则")]
        public EnumGuaranteeChangeRule? ChangeRule { get; set; }

        /// <summary>
        /// 日期参数
        /// 
        /// ChangeRule= NeedSomeDay时，对应规则2描述中 “允许变更/取消,需在XX日YY时之前通知” 中的XX日，YY时
        /// </summary>
        [Description("日期参数")]
        public DateTime? Day { get; set; }

        /// <summary>
        /// 时间参数
        /// 
        /// ChangeRule= NeedSomeDay时，对应规则2描述中 “允许变更/取消,需在XX日YY时之前通知” 中的XX日，YY时
        /// </summary>
        [Description("时间参数")]
        public string Time { get; set; }

        /// <summary>
        /// 小时参数
        /// 
        /// ChangeRule= NeedCheckinTime时，对应规则3描述中 “ 允许变更/取消,需在最早到店时间之前几小时通知” 中的几小时 
        /// ChangeRule= NeedCheckin24hour时，对应规则4描述中“ 允许变更/取消,需在到店日期的24点之前几小时通知” 中的几小时
        /// </summary>
        [Description("小时参数")]
        public int? Hour { get; set; }
    }
}
