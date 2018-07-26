using Mzl.Common.EnumHelper.ElongEnum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Mzl.EntityModel.Hotel.Elong
{
    public class HotelEntity
    {
        /// <summary>
        /// 酒店编码
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
        /// 该酒店下所有的预订规则。应在订单填写页面提示给用户，也可以做到系统规则中约束用户的选择或输入。
        /// 包含多个 BookingRule节点
        /// </summary>
        public BookingRuleEntity[] BookingRules { get; set; }


        /// <summary>
        /// 担保规则
        /// 
        /// 出现规则即表示需要担保。当 isTimeGuarantee和 isAmountGuarantee都等于false时候表示无条件强制担保
        /// 包含多个 GuaranteeRule节点
        /// 
        /// </summary>
        public GuaranteeRuleEntity[] GuaranteeRules { get; set; }

        /// <summary>
        /// 预付规则
        /// 
        /// 包含多个 PrepayRule节点
        /// </summary>
        public PrepayRuleEntity[] PrepayRules { get; set; }

        /// <summary>
        /// 增值服务
        /// </summary>
        public ValueAddEntity[] ValueAdds { get; set; }

        /// <summary>
        /// 促销规则
        /// </summary>
        public DrrRuleEntity[] DrrRules { get; set; }

        /// <summary>
        /// 酒店设置
        /// 
        /// 详见枚举：EnumFacility
        /// </summary>
        public string Facilities { get; set; }

        /// <summary>
        /// 距离
        /// 
        /// 距离搜索的时候有值
        /// </summary>
        public decimal Distance { get; set; }

        /// <summary>
        /// 距离对应的参照物
        /// 
        /// V1.14新增。如果只有应展示告诉用户Distance计算时候的参照点
        /// </summary>
        public string PoiName { get; set; }
        
        /// <summary>
        /// 包含多个Room节点
        /// </summary>
        public RoomEntity[] Rooms { get; set; }

        /// <summary>
        /// 酒店信息
        /// </summary>
        public DetailEntity Detail{get;set;}


        /// <summary>
        ///
        /// 房型图片以外的图片
        /// 参考静态信息[仅包含无水印图片，规格：120、350、640]
        /// (测试环境这个节点因缓存服务器的问题没有数据)
        /// </summary>
        public HotelImg[] Images { get; set; }

        /// <summary>
        /// 送礼活动
        /// 
        /// 包含多个 Gift节点
        /// </summary>
        public GiftEntity[] Gifts { get; set; }

        /// <summary>
        /// 酒店特殊信息提示
        /// 
        /// 包含多个 HAvailPolicy节点
        /// V1.04新增. 请把此信息展示给用户，以便用户预订
        /// </summary>
        public HAvailPolicyEntity[] HAvailPolicys { get; set; }

        /// <summary>
        /// 简易产品信息
        /// </summary>
        public ProductEntity[] Products { get; set; }
    }
}
