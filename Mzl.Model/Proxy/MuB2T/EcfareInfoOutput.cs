using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace Mzl.EntityModel.Proxy.MuB2T
{
    /// <summary>
    /// 运价查询返回主对象
    /// </summary>
    //[Serializable]
    public class EcfareInfoOutput
    {
        /// <summary>
        /// ECFare分配的查询账号
        /// </summary>
        public string ECFARE_ID { get; set; }
        /// <summary>
        /// 本次运价的编号规则：运价计算的时间（GMT时间）＋子序号
        /// </summary>
        public string FARE_SQ { get; set; }
        /// <summary>
        /// 渠道种类
        /// </summary>
        public string CHANNEL_CODE { get; set; }
        /// <summary>
        /// 支付类型
        /// </summary>
        public string FORMOFPAYMENT { get; set; }
        /// <summary>
        /// OW/RT仅指点到点的单段和单段来回航程
        /// </summary>
        public string ROUTE_TYPE { get; set; }
        /// <summary>
        /// 货币三字代码，表示销售系统的收款所用货币
        /// </summary>
        public string CURRENCY_CODE { get; set; }
        /// <summary>
        /// 格式“货币1/货币2:汇率”
        /// </summary>
        public string CURRENCY_RATE { get; set; }
        /// <summary>
        /// GMT时间，最晚的运价有效时间
        /// </summary>
        public string TICKETING_DL { get; set; }
        /// <summary>
        /// 本次运价查询对应的EI，作为出票时的EI项（特殊运价除外）
        /// </summary>
        public string ENDORSEMENT { get; set; }
        /// <summary>
        /// 备注信息
        /// </summary>
        public string COMMENT { get; set; }
        /// <summary>
        /// 运价代号，作为出票时的TC项(特殊运价除外)
        /// </summary>
        public string TOUR_CODE { get; set; }
        /// <summary>
        /// 指本次查询的航程中所包含的航段数量
        /// </summary>
        public string SEGMENT_NUMBER { get; set; }
        /// <summary>
        /// 与“渠道种类”的关系：
        ///CC:NP/FF/KA/PKG
        ///B2B：KA/AG/PKG
        ///B2C：NP/FF/PKG
        ///B2E：KA/PKG
        /// </summary>
        public string PRODUCT_TYPE { get; set; }
        /// <summary>
        /// G表示团队；I表示散客
        /// </summary>
        public string GROUP_INDICATOR { get; set; }
        /// <summary>
        /// 旅客职业
        /// </summary>
        public string PAX_CAREER_CODE { get; set; }
        /// <summary>
        /// 使用规则信息
        /// </summary>
        public string RULE_LIST { get; set; }
        /// <summary>
        /// 特殊运价代码(目前只有“Q+Q”，表示舱位均为Q的单段RT，或者两段联程)
        /// </summary>
        public string SPECIAL_FARE_CODE { get; set; }
        /// <summary>
        /// 特殊运价信息(格式为“旅客类型:价格+机场税+燃油附加费+FareBasis+TourCode+Endorsement+备注信息”。多个旅客类型以“;”分隔。) , 当前版本返回null
        /// </summary>
        public string SPECIAL_FARE_INFO { get; set; }
        /// <summary>
        /// 运价计算项(当确定了航班、舱位之后才返回), 当前版本返回null
        /// </summary>
        public string FARE_CALCULATION { get; set; }
        /// <summary>
        /// 运价组(当确定了航班、舱位之后才返回) , 当前版本返回null
        /// </summary>
        public string FARE_AMOUNT { get; set; }
        /// <summary>
        /// 旅客人数信息
        /// </summary>
        public SEL_PAX_NUM SelPaxNum { get; set; }
        /// <summary>
        /// 旅客信息列表
        /// </summary>
        public List<PaxInfo> PaxInfo { get; set; }
        /// <summary>
        /// 常旅客信息
        /// </summary>
        public FFPItem ffpItem { get; set; }
        /// <summary>
        /// 集团大客户信息
        /// </summary>
        public KAItem kaItem { get; set; }
        /// <summary>
        /// 代理人信息
        /// </summary>
        public AGTItem agtItem { get; set; }
        /// <summary>
        /// 航段资料列表
        /// </summary>
        public List<SegmentItem> SEGMENT_ITEM { get; set; }
        /// <summary>
        /// 
        /// </summary>

        public string LANGUAGE { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string POINTS_AMOUNT { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string POINTS_CURRENCY { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string promoCode { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string JF_TYPE { get; set; }

        #region xml文档
        ///// <summary>
        ///// 
        ///// </summary>
        //[XmlElement]
        //public string sg_t { get; set; }
        ///// <summary>
        ///// 
        ///// </summary>
        //[XmlElement]
        //public string sg_s { get; set; }
        ///// <summary>
        ///// 
        ///// </summary>
        //[XmlElement]
        //public string sg_d { get; set; }
        ///// <summary>
        ///// 
        ///// </summary>
        //[XmlElement]
        //public string sg_p { get; set; }
        ///// <summary>
        ///// 
        ///// </summary>
        //[XmlElement]
        //public SegmentItem sg_f { get; set; }
        #endregion
    }
}
