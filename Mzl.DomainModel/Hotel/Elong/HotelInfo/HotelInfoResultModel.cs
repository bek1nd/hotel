using System.Collections.Generic;
using Mzl.Common.EnumHelper.ElongEnum;

namespace Mzl.DomainModel.Hotel.Elong.HotelInfo
{
    public class HotelInfoResultModel
    {
        /// <summary>
        /// 酒店编号
        /// </summary>
        public string HotelId { get; set; }
        /// <summary>
        /// 最低价格
        /// </summary>
        public decimal LowRate { get; set; }
        /// <summary>
        /// 最低价格的货币
        /// </summary>
        public EnumCurrencyCode CurrencyCode { get; set; }
        /// <summary>
        /// 酒店设置
        /// </summary>
        public string Facilities { get; set; }
        /// <summary>
        /// 距离
        /// </summary>
        public decimal Distance { get; set; }
        /// <summary>
        /// 距离对应的参照物
        /// </summary>
        public string PoiName { get; set; }
        /// <summary>
        /// 酒店特惠信息
        /// </summary>
        public string HotelFlags { get; set; }
        /// <summary>
        /// 预定规则
        /// </summary>
        public List<HotelBookingRuleModel> BookingRules { get; set; }
        /// <summary>
        /// 担保规则
        /// </summary>
        public List<HotelGuaranteeRuleModel> GuaranteeRules { get; set; }
        /// <summary>
        /// 预付规则
        /// </summary>
        public List<HotelPrepayRuleModel> PrepayRules { get; set; }
        /// <summary>
        /// 增值服务
        /// </summary>
        public List<HotelValueAddModel> ValueAdds { get; set; }
        /// <summary>
        /// 促销规则
        /// </summary>
        public List<HotelDrrRuleModel> DrrRules { get; set; }
        /// <summary>
        /// 房型列表
        /// </summary>
        public List<HotelRoomsModel> Rooms { get; set; }
        /// <summary>
        /// 酒店信息
        /// </summary>
        public HotelDetailModel Detail { get; set; }
        /// <summary>
        /// 酒店特殊信息提示
        /// </summary>
        public List<HotelHAvailPolicyModel> HAvailPolicys { get; set; }
    }
}
