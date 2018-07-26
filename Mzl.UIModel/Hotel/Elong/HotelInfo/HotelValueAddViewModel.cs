using System;
using System.ComponentModel;
using Mzl.Common.EnumHelper.ElongEnum;

namespace Mzl.UIModel.Hotel.Elong.HotelInfo
{
    public class HotelValueAddViewModel
    {
        /// <summary>
        /// 增值服务编号
        /// </summary>
        [Description("增值服务编号")]
        public string ValueAddId { get; set; }

        /// <summary>
        /// 描述
        /// </summary>
        [Description("描述")]
        public string Description { get; set; }

        /// <summary>
        /// 业务代码
        /// 
        ///  01-早餐
        ///  02-午餐
        ///  03-晚餐
        ///  04-宽带上网
        ///  05-服务费
        ///  06-政府税
        ///  99-特殊早餐(可能存在不同日期段的多个记录)
        /// </summary>
        [Description("业务代码")]
        public string TypeCode { get; set; }

        /// <summary>
        /// 是否包含在房费中
        /// 
        /// false-不包含 true-包含
        /// </summary>
        [Description("是否包含在房费中")]
        public bool IsInclude { get; set; }

        /// <summary>
        /// 包含的份数
        /// </summary>
        [Description("包含的份数")]
        public int? Amount { get; set; }

        /// <summary>
        /// 货币代码
        /// 
        /// 参考http://open.elong.com/wiki/Currency
        /// </summary>
        [Description("货币代码")]
        public string CurrencyCode { get; set; }

        /// <summary>
        /// 单价默认选项
        /// 
        /// Money-金额，Percent-比例，None-无效
        /// </summary>
        [Description("单价默认选项")]
        public EnumValueAddPriceOption? PriceOption { get; set; }

        /// <summary>
        /// 单价
        /// 
        /// 视PriceOption表示金额或比例， 比例值保存的百分数，不是最终的小数， 例如 20%， 则该字段保存为20
        /// </summary>
        [Description("单价")]
        public decimal? Price { get; set; }

        /// <summary>
        /// 是否单加
        /// 
        /// 目前只有早餐服务该字段有意义
        /// </summary>
        [Description("是否单加")]
        public bool IsExtAdd { get; set; }

        /// <summary>
        /// 单加单价默认选项
        /// 
        /// Money-金额，Percent-比例
        /// </summary>
        [Description("单加单价默认选项")]
        public EnumValueAddPriceOption? ExtOption { get; set; }

        /// <summary>
        /// 单加单价
        /// 
        /// 视 extOption 不同表示金额或比例值, 比例值保存的百分数，不是最终的小数， 例如 20%， 则该字段保存为20
        /// </summary>
        [Description("单加单价")]
        public decimal? ExtPrice { get; set; }

        /// <summary>
        /// 开始日期
        /// 
        /// 仅对特殊早餐有效,表示在指定的日期范围内符合星期设置的条件下，该产品的早晨服务使用本条信息；特殊早晨优先于通常的早晨设置。
        /// EndDate是包含该天。
        /// </summary>
        [Description("开始日期")]
        public DateTime? StartDate { get; set; }

        /// <summary>
        /// 结束日期
        /// 
        /// 仅对特殊早餐有效,表示在指定的日期范围内符合星期设置的条件下，该产品的早晨服务使用本条信息；特殊早晨优先于通常的早晨设置。
        /// EndDate是包含该天。
        /// </summary>
        [Description("结束日期")]
        public DateTime? EndDate { get; set; }

        /// <summary>
        /// 周有效设置
        /// 
        /// 仅对特殊早餐有效,表示在指定的日期范围内符合星期设置的条件下，该产品的早晨服务使用本条信息；特殊早晨优先于通常的早晨设置。
        /// EndDate是包含该天。
        /// </summary>
        [Description("周有效设置")]
        public string WeekSet { get; set; }
    }
}
