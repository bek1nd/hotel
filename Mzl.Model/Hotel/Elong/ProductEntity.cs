using Mzl.Common.EnumHelper.ElongEnum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Mzl.EntityModel.Hotel.Elong
{
    public class ProductEntity
    {
        /// <summary>
        /// 酒店编码
        /// </summary>
        public string HotelCode { get; set; }

        /// <summary>
        /// 房型ID
        /// </summary>
        public string RoomId { get; set; }

        /// <summary>
        /// 房型编码
        /// </summary>
        public string RoomTypeId { get; set; }

        /// <summary>
        /// 房型名称
        /// </summary>
        public string RoomName { get; set; }

        /// <summary>
        /// 价格计划ID
        /// </summary>
        public int RatePlanId { get; set; }

        /// <summary>
        /// 价格计划名称
        /// </summary>
        public string RatePlanName { get; set; }

        /// <summary>
        /// 支付类型
        /// </summary>
        public EnumPaymentType PaymentType { get; set; }

        /// <summary>
        /// 包含早餐的份数
        /// </summary>
        public int BreakfastAmount { get; set; }

        /// <summary>
        /// 单加早餐信息
        /// 
        /// 存在数额并且大于0表示可以单加早餐，大于0小于1表示单加早餐金额对应饭费的比率，大于等于1表示单加早餐的金额
        /// </summary>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
        public System.Nullable<decimal> ExtraBreakfastPrice { get; set; }

        /// <summary>
        /// 房型设施信息
        /// 
        /// 暂时仅包含 床型、上网情况，入住人数； 参考[Amenities]
        /// </summary>
        public string RoomAmenityIds { get; set; }

        /// <summary>
        /// 日均价
        /// </summary>
        public decimal AverageRate { get; set; }

        /// <summary>
        /// 加床价格
        /// 不存在或者-1的时候表示不可加床
        /// </summary>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
        public System.Nullable<decimal> ExtraBedPrice { get; set; }

        /// <summary>
        /// 促销前的日均价
        /// 
        /// 用于价格的划线
        /// </summary>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
        public System.Nullable<decimal> AverageBaseRate { get; set; }

        /// <summary>
        /// 返现金额
        /// </summary>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
        public System.Nullable<decimal> Coupon { get; set; }

        /// <summary>
        /// yeano:文档中未提及
        /// </summary>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
        public System.Nullable<decimal> CouponInRed { get; set; }

        /// <summary>
        /// 价格对应的货币
        /// </summary>
        public EnumCurrencyCode CurrencyCode { get; set; }

        /// <summary>
        /// 可用库存
        /// </summary>
        public int CurrentAlloment { get; set; }

        /// <summary>
        /// 取消规则
        /// 
        /// 0--不可取消，1--限时取消，2--免费取消。限时取消是表示存在取消规则的时候可能的担保情况
        /// </summary>
        public int CancelRuleType { get; set; }

        /// <summary>
        /// 可能的最晚取消时间
        /// 
        /// 按14点到店计算
        /// </summary>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
        public System.Nullable<System.DateTime> LatestCancelTime { get; set; }

        /// <summary>
        /// 产品类型
        /// 
        /// 3-限时抢购 4-钟点房 5-手机专享
        /// </summary>
        public string ProductTypes { get; set; }

        /// <summary>
        /// 礼包说明
        /// 
        /// 查找Gifts列表
        /// </summary>
        public string GiftIds { get; set; }

        /// <summary>
        /// 每晚详细信息
        /// </summary>
        public NightlyRateWithBreakfastEntity[] Nights { get; set; }

        /// <summary>
        /// 产品是否可销售
        /// </summary>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
        public System.Nullable<bool> Status { get; set; }
    }
}
