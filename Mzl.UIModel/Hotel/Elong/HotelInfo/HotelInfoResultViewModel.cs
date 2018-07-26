using System.Collections.Generic;
using System.ComponentModel;
using Mzl.Common.EnumHelper.ElongEnum;

namespace Mzl.UIModel.Hotel.Elong.HotelInfo
{
    public class HotelInfoResultViewModel
    {
        /// <summary>
        /// 酒店编号
        /// </summary>
        [Description("酒店编号")]
        public string HotelId { get; set; }
        /// <summary>
        /// 最低价格
        /// </summary>
        [Description("最低价格")]
        public decimal LowRate { get; set; }
        /// <summary>
        /// 最低价格的货币
        /// </summary>
        [Description("最低价格的货币")]
        public EnumCurrencyCode CurrencyCode { get; set; }
        /// <summary>
        /// 酒店设置
        /// </summary>
        [Description("酒店设置")]
        public string Facilities { get; set; }
        /// <summary>
        /// 距离
        /// </summary>
        [Description("距离")]
        public decimal Distance { get; set; }
        /// <summary>
        /// 距离对应的参照物
        /// </summary>
        [Description("距离对应的参照物")]
        public string PoiName { get; set; }
        /// <summary>
        /// 酒店特惠信息
        /// </summary>
        [Description("酒店特惠信息")]
        public string HotelFlags { get; set; }
        /// <summary>
        /// 预定规则
        /// </summary>
        [Description("预定规则")]
        public List<HotelBookingRuleViewModel> BookingRules { get; set; }
        /// <summary>
        /// 担保规则
        /// </summary>
        [Description("担保规则")]
        public List<HotelGuaranteeRuleViewModel> GuaranteeRules { get; set; }
        /// <summary>
        /// 预付规则
        /// </summary>
        [Description("预付规则")]
        public List<HotelPrepayRuleViewModel> PrepayRules { get; set; }
        /// <summary>
        /// 增值服务
        /// </summary>
        [Description("增值服务")]
        public List<HotelValueAddViewModel> ValueAdds { get; set; }
        /// <summary>
        /// 促销规则
        /// </summary>
        [Description("促销规则")]
        public List<HotelDrrRuleViewModel> DrrRules { get; set; }
        /// <summary>
        /// 房型列表
        /// </summary>
        [Description("房型列表")]
        public List<HotelRoomsViewModel> Rooms { get; set; }
        /// <summary>
        /// 酒店信息
        /// </summary>
        [Description("酒店信息")]
        public HotelDetailViewModel Detail { get; set; }
        /// <summary>
        /// 酒店特殊信息提示
        /// </summary>
        [Description("酒店特殊信息提示")]
        public List<HotelHAvailPolicyViewModel> HAvailPolicys { get; set; }
    }
}
