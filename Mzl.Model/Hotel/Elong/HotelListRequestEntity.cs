using Mzl.Common.EnumHelper.ElongEnum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mzl.EntityModel.Hotel.Elong
{
    /// <summary>
    /// 酒店列表查询
    /// </summary>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.33440")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "", IsNullable = true)]
    public class HotelListRequestEntity
    {
        /// <summary>
        /// 入住日期
        /// </summary>
        public System.DateTime ArrivalDate { get; set; }
        
        /// <summary>
        /// 离店日期
        /// </summary>
        public System.DateTime DepartureDate { get; set; }

        /// <summary>
        /// 城市编码
        /// </summary>
        public string CityId { get; set; }

        /// <summary>
        /// 查询关键词
        /// </summary>
        public string QueryText { get; set; }

        /// <summary>
        /// 查询类型
        /// </summary>
        public EnumQueryType? QueryType { get; set; }

        /// <summary>
        /// 支付方式
        /// </summary>
        public EnumPaymentType? PaymentType { get; set; }

        /// <summary>
        /// 产品类型
        /// 详见枚举：EnumProductProperty
        /// 
        /// 
        /// 2015.02.10修改类型为String，支持多个选项同时传入，以逗号分隔。本参数是筛选包含指定条件的酒店，结果中的酒店可能包含其他属性的产品请自行过滤。可选值为：
        /// 
        /// All =全部,
        /// LastMinuteSale =今日特价,       
        /// LimitedTimeSale =限时抢购,
        /// WithoutGuarantee =免担保
        /// AdvanceBooking=早订省
        /// LongStayBooking=连住省
        /// HourlyRoom=钟点房
        /// </summary>
        public string ProductProperties { get; set; }

        /// <summary>
        /// 设施
        /// 
        /// 可以逗号分隔的组合，建议最多3个。
        /// 详见枚举：EnumFacility
        /// 
        /// 1        免费wifi
        /// 2        收费wifi
        /// 3        免费宽带
        /// 4        收费宽带
        /// 5        免费停车场
        /// 6        收费停车场
        /// 7        免费接机服务
        /// 8        收费接机服务
        /// 9        室内游泳池
        /// 10      室外游泳池
        /// 11      健身房
        /// 12      商务中心
        /// 13      会议室
        /// 14      酒店餐厅
        /// </summary>
        public string Facilities { get; set; }

        /// <summary>
        /// 主题
        /// 详见枚举：EnumThemeId
        /// 
        /// 97    客栈 
        /// 98    家庭旅馆 
        /// 99    青年旅舍 
        /// 100    精品酒店（设计师酒店） 
        /// 101    情侣酒店 
        /// 105    园林庭院 
        /// 103    海景 
        /// 106    农家乐 
        /// 102    温泉酒店 
        /// 104    高尔夫酒店 
        /// 107    四合院 
        /// 259    别墅 
        /// 260    聚会做饭 
        /// 261    商旅之家 
        /// 262    休闲情调 
        /// 265    看病就医 
        /// 264    度假休闲 
        /// 266    培训学习 
        /// 267    聚会 
        /// 268    蜜月出行
        /// 可以逗号分隔的组合，建议最多3个。
        /// </summary>
        public string ThemeIds { get; set; }


        /// <summary>
        /// 推荐星级
        /// 
        /// 详见类：ConstStarRate
        /// 
        /// 搜索多个星级以逗号分隔
        /// 经济/客栈: 0,1,2
        /// 三星/舒适: 3
        /// 四星/高档: 4
        /// 五星/豪华: 5
        /// 公寓: A
        /// </summary>
        public string StarRate { get; set; }

        /// <summary>
        /// 品牌编码
        /// </summary>
        public string BrandId { get; set; }

        /// <summary>
        /// 酒店集团编码
        /// </summary>
        public int? GroupId { get; set; }

        /// <summary>
        /// 最小价格
        /// 
        /// 过滤的是酒店中的产品,如果酒店的产品有一个满足这个区间这个酒店就算满足这个条件。注意不是按酒店最低价格来过滤的。
        /// </summary>
        public int? LowRate { get; set; }

        /// <summary>
        /// 最大价格
        /// 
        /// 过滤的是酒店中的产品,如果酒店的产品有一个满足这个区间这个酒店就算满足这个条件。注意不是按酒店最低价格来过滤的。
        /// </summary>
        public int? HighRate { get; set; }

        /// <summary>
        /// 地区编码
        /// </summary>
        public string DistrictId { get; set; }

        /// <summary>
        /// 地标编码
        /// 
        /// 失效，不再使用
        /// </summary>
        public string LocationId { get; set; }


        /// <summary>
        /// 位置查询
        /// 
        /// 
        /// </summary>
        public Position Position { get; set; }

        /// <summary>
        /// 商业区ID
        /// 
        /// Yeano：不确定是否可以用
        /// </summary>
        public string BusinessZoneId { get; set; }

        /// <summary>
        /// 排序类型
        /// </summary>
        public EnumSortType? Sort { get; set; }

        /// <summary>
        /// 页码
        /// 
        /// 从1开始
        /// </summary>
        public int? PageIndex { get; set; }

        /// <summary>
        /// 每页记录数
        /// 
        /// 取值访问：1-20（PageIndex>0时PageSize为必填，否则分页失败）
        /// </summary>
        public int? PageSize { get; set; }

        /// <summary>
        /// 宾客类型
        /// 详见枚举：EnumCustomerType
        /// 
        /// 只选择：All
        /// 
        /// None=全部;  All=统一价；Chinese =内宾价；OtherForeign =外宾价；HongKong =港澳台客人价Japanese=日本客人价
        /// </summary>
        public string CustomerType { get; set; }


        /// <summary>
        ///  	房间入住人数
        /// </summary>
        public int? CheckInPersonAmount { get; set; }


        /// <summary>
        /// 床型
        /// 
        /// yeano：不知道是否能用
        /// </summary>
        public string BedTypes { get; set; }

        /// <summary>
        /// 返回信息类型
        /// 
        /// 
        /// 可以是逗号分隔的组合。
        /// 1.可买价格信息(房间、RP、促销、增值)
        /// 2. 规则信息(预订、Drr、担保规则、预付规则)
        /// 3. 酒店基本信息
        /// 4. 当前不可销售的rp不出现在结果里
        /// 5. 不返回Rooms、*Rules、AddValues等和产品有关系的对象
        /// 6. 产品方面仅返回简单的#Products
        /// 7. 返回汇率信息#ExchangeRateList
        /// 8. 经纬度返回百度坐标
        /// 9. 仅返回钟点房
        /// </summary>
        public string ResultType { get; set; }
    }
}
