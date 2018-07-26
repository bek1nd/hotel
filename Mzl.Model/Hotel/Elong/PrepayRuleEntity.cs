using Mzl.Common.EnumHelper.ElongEnum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Mzl.EntityModel.Hotel.Elong
{
    /// <summary>
    /// 预付规则
    /// </summary>
    public class PrepayRuleEntity
    {
        /// <summary>
        /// 规则编码
        /// </summary>
        public int PrepayRuleId { get; set; }

        /// <summary>
        /// 描述
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// 日期类型
        /// 
        /// CheckInDay：入住日期
        /// </summary>
        public EnumDateType DateType { get; set; }

        /// <summary>
        /// 开始日期
        /// 
        /// hotel.list 和 hotel.detail的内部逻辑对这三个属性已经判断了, 可以不进行额外的判断。
        /// </summary>
        public System.DateTime StartDate { get; set; }

        /// <summary>
        /// 结束日期
        /// 
        /// hotel.list 和 hotel.detail的内部逻辑对这三个属性已经判断了, 可以不进行额外的判断。
        /// </summary>
        public System.DateTime EndDate { get; set; }

        /// <summary>
        /// 周有效设置
        /// 
        /// hotel.list 和 hotel.detail的内部逻辑对这三个属性已经判断了, 可以不进行额外的判断。
        /// </summary>
        public string WeekSet { get; set; }

        /// <summary>
        /// 变更规则
        /// </summary>
        public EnumPrepayChangeRule ChangeRule { get; set; }

        /// <summary>
        /// 具体取消时间日期部分
        /// 
        /// 用于 PrepayNeedOneTime
        /// </summary>
        public System.DateTime DateNum { get; set; }


        /// <summary>
        /// 具体取消时间小时部分
        /// 
        /// 用于 PrepayNeedOneTime
        /// </summary>
        public string Time { get; set; }

        /// <summary>
        /// 在变更时间点前是否扣费
        /// 
        /// 用于 PrepayNeedSomeDay的Hour前扣款类型（一般不收罚金）
        /// </summary>
        public int DeductFeesBefore { get; set; }


        /// <summary>
        /// 时间点前扣费的金额或比例
        /// 
        /// 用于 PrepayNeedSomeDay的Hour前扣款类型（一般不收罚金）
        /// </summary>
        public decimal DeductNumBefore { get; set; }

        /// <summary>
        /// 时间点后扣款类型
        /// </summary>
        public EnumPrepayCutPayment CashScaleFirstAfter { get; set; }

        /// <summary>
        /// 在变更时间点后是否扣费
        /// 
        /// 用于 PrepayNeedSomeDay的Hour到Hour2之间的扣款类型
        /// </summary>
        public int DeductFeesAfter { get; set; }

        /// <summary>
        /// 时间点后扣费的金额或比例
        /// 
        /// 用于 PrepayNeedSomeDay的Hour到Hour2之间的扣款类型
        /// </summary>
        public decimal DeductNumAfter { get; set; }

        /// <summary>
        /// 时间点前扣款类型
        /// </summary>
        public EnumPrepayCutPayment CashScaleFirstBefore { get; set; }

        /// <summary>
        /// 第一阶段提前几小时
        /// 
        /// 用于 PrepayNeedSomeDay
        /// </summary>
        public int Hour { get; set; }

        /// <summary>
        /// 第二阶段提前几小时
        /// 
        /// 用于 PrepayNeedSomeDay
        /// </summary>
        public int Hour2 { get; set; }
    }
}
