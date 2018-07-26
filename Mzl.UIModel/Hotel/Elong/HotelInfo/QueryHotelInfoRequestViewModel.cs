using System;
using Mzl.Common.EnumHelper.ElongEnum;
using Mzl.UIModel.Base;

namespace Mzl.UIModel.Hotel.Elong.HotelInfo
{
    /// <summary>
    /// 查询酒店信息请求实体
    /// </summary>
    public class QueryHotelInfoRequestViewModel : RequestBaseViewModel
    {
        /// <summary>
        /// 入住日期
        /// </summary>
        public DateTime ArrivalDate { get; set; }
        /// <summary>
        /// 离店日期
        /// </summary>
        public DateTime DepartureDate { get; set; }
        /// <summary>
        /// 城市编码
        /// </summary>
        public string CityId { get; set; }
        /// <summary>
        /// 地区编码
        /// </summary>
        public string DistrictId { get; set; }
        /// <summary>
        /// 商圈编码
        /// </summary>
        public string BusinessZoneId { get; set; }
        /// <summary>
        /// 查询关键词
        /// 可以是酒店名、位置或品牌等。使用本参数的时候，需要输入CityId或DistrictId
        /// </summary>
        public string QueryText { get; set; }

        /// <summary>
        /// 查询类型
        /// </summary>
        public EnumQueryType? QueryType { get; set; } = EnumQueryType.Intelligent;

        /// <summary>
        /// 支付方式
        /// </summary>
        public EnumPaymentType? PaymentType { get; set; } = EnumPaymentType.All;
        /// <summary>
        /// 产品类型
        /// All =全部,LastMinuteSale =今日特价,LimitedTimeSale =限时抢购,WithoutGuarantee =免担保,AdvanceBooking = 早订优惠,LongStayBooking=连住优惠
        /// </summary>
        public string ProductProperties { get; set; }
        /// <summary>
        /// 设施
        /// </summary>
        public string Facilities { get; set; }
        /// <summary>
        /// 主题
        /// </summary>
        public string ThemeIds { get; set; }
        /// <summary>
        /// 推荐星级
        /// </summary>
        public string StarRate { get; set; }
        /// <summary>
        /// 最小价格
        /// </summary>
        public int? LowRate { get; set; }
        /// <summary>
        /// 最大价格
        /// </summary>
        public int? HighRate { get; set; }
        /// <summary>
        /// 位置查询
        /// 点选位置搜索，坐标采用百度的坐标体系，字段参考Position节点
        /// </summary>
        public string Position { get; set; }

        /// <summary>
        /// 排序类型
        /// Default艺龙默认排序,StarRankDesc推荐星级降序,RateAsc价格升序,RateDesc价格降序,DistanceAsc距离升序
        /// </summary>
        public EnumSortType? Sort { get; set; } = EnumSortType.Default;
        /// <summary>
        /// 页码
        /// 从1开始
        /// </summary>
        public int? PageIndex { get; set; }
        /// <summary>
        /// 每页记录数
        /// 取值范围：1-20 （PageIndex>0时PageSize为必填，否则分页失败）
        /// </summary>
        public int? PageSize { get; set; }
        /// <summary>
        /// 返回信息类型 可以是逗号分隔的组合。
        /// 1.可销售价格信息(房间、RP、促销、增值)
        /// 2. 规则信息(预订、Drr、担保规则、预付规则)
        /// 3. 酒店基本信息，即返回信息中的Detail字段
        /// 4. 当前不可销售的rp（产品计划）不出现在结果里
        /// 5. 不返回Rooms、GuaranteeeRules、PrepayRules、AddValues等和产品有关系的对象
        /// 7.   返回汇率信息ExchangeRateList
        /// 8. 经纬度返回百度坐标
        /// 9. 仅返回钟点房
        /// </summary>
        public string ResultType { get; set; } = "1,2,3,4";
    }
}
