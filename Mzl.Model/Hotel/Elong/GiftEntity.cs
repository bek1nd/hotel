using Mzl.Common.EnumHelper.ElongEnum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Mzl.EntityModel.Hotel.Elong
{
    public class GiftEntity
    {
        /// <summary>
        /// 送礼编号
        /// 
        /// 关联RatePlan.GiftId
        /// </summary>
        public int GiftId { get; set; }


        /// <summary>
        /// 开始时间
        /// </summary>
        public System.DateTime StartDate { get; set; }

        /// <summary>
        /// 结束时间
        /// </summary>
        public System.DateTime EndDate { get; set; }

        /// <summary>
        /// 日期类型
        /// </summary>
        public EnumHotelGiftDateType DateType { get; set; }

        /// <summary>
        /// 星期设置
        /// </summary>
        public string WeekSet { get; set; }

        /// <summary>
        /// 活动内容
        /// </summary>
        public string GiftContent { get; set; }

        /// <summary>
        /// 送礼类型
        /// 
        /// 1        送餐相关
        /// 2        延迟退房
        /// 3        送礼品
        /// 4        设施服务（如免费健身、送洗衣等）
        /// 5        免费接站/接机
        /// 6        送折扣/抵扣券
        /// 7        送旅游/门票
        /// 8        其他
        /// </summary>
        public string GiftTypes { get; set; }

        /// <summary>
        /// 小时数
        /// </summary>
        public int HourNumber { get; set; }

        /// <summary>
        /// 小时数的类型
        /// </summary>
        public EnumHotelGiftHourType HourType { get; set; }

        /// <summary>
        /// 送礼方式
        /// </summary>
        public EnumHotelGiftWayOfGiving WayOfGiving { get; set; }

        /// <summary>
        /// 其他的送礼具体方式
        /// 
        /// 送礼方式为其他的时候，送礼活动的名称
        /// </summary>
        public string WayOfGivingOther { get; set; }
    }
}
