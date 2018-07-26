using Mzl.Common.EnumHelper.ElongEnum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Mzl.EntityModel.Hotel.Elong
{
    public class BookingRuleEntity
    {


        /// <summary>
        /// 规则类型
        /// </summary>
        public EnumBookingRule TypeCode { get; set; }

        /// <summary>
        /// 预订规则编号
        /// 
        /// 
        /// RatePlan.BookingRuleIds将与此关联
        /// </summary>
        public long BookingRuleId { get; set; }

        /// <summary>
        /// 描述
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Yeano：不知道干嘛的，文档中没有提到
        /// </summary>
        public string RoomTypeIds { get; set; }

        /// <summary>
        /// 日期类型
        /// 
        /// BookDay –预订日期（订单的创建日期）
        /// </summary>
        public EnumDateType DateType { get; set; }

        /// <summary>
        /// 开始日期
        /// </summary>
        public System.DateTime StartDate { get; set; }

        /// <summary>
        /// 结束日期
        /// </summary>
        public System.DateTime EndDate { get; set; }

        /// <summary>
        /// 每天开始时间
        /// 
        /// 针对日期段内每天生效, 当TypeCode 为4时表示StartHour到EndHour 酒店不接受预订
        /// </summary>
        public string StartHour { get; set; }

        /// <summary>
        /// 每天结束日期
        /// 
        /// 针对日期段内每天生效, 当TypeCode 为4时表示StartHour到EndHour 酒店不接受预订
        /// </summary>
        public string EndHour { get; set; }
    }
}
