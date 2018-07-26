using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace Mzl.EntityModel.Proxy.MuB2T
{
    /// <summary>
    /// 
    /// </summary>
    [Serializable]
    public class SEARCH_ITEM
    {
        /// <summary>
        /// 国际还是国内, I-国际/D-国内
        /// </summary>     
        [XmlElement]
        public string FARE_TYPE { get; set; }
        /// <summary>
        /// 渠道种类
        /// </summary>
        [XmlElement]
        public string CHANNEL_CODE { get; set; }
        /// <summary>
        /// OW/RT仅指点到点的单段和单段来回航程
        /// </summary>
        [XmlElement]
        public string ROUTE_TYPE { get; set; }
        /// <summary>
        /// 支付类型
        /// </summary>
        [XmlElement]
        public string FORMOFPAYMENT { get; set; }
        /// <summary>
        /// 货币三字代码，表示销售系统的收款所用货币
        /// </summary>
        [XmlElement]
        public string CURRENCY_CODE { get; set; }
        /// <summary>
        /// 销售系统计划出票的时间
        /// </summary>
        [XmlElement]
        public string TICKETING_DATE { get; set; }
        /// <summary>
        /// 出票者的IATA号（如果是AG时候和AG的IATA号码）
        /// </summary>
        [XmlElement]
        public string TICKETING_IATA_NO { get; set; }
        /// <summary>
        /// TICKETING_IATA_NO
        /// </summary>
        [XmlElement]
        public string SEGMENT_NUMBER { get; set; }
        /// <summary>
        /// 与“渠道种类”的关系：
        /// CC:PX/FF/KA/PKG
        /// B2B：KA/AG/PKG
        /// B2C：PX/FF/PKG
        /// B2E：KA/PKG
        /// </summary>
        [XmlElement]
        public string PRODUCT_TYPE { get; set; }
        /// <summary>
        /// G表示团队；I表示散客
        /// </summary>
        [XmlElement]
        public string GROUP_INDICATOR { get; set; }
        /// <summary>
        /// 特殊运价代码(如果此处不为空，表示请求特殊运价的查询。例如，此处值为“Q+Q”，说明请求返回Q+Q这个种类特殊运价的运价信息)
        /// </summary>
        [XmlElement]
        public string SPECIAL_FARE_CODE { get; set; }
        /// <summary>
        /// 旅客人数信息,散客填NULL
        /// </summary>
        [XmlElement]
        public SEL_PAX_NUM SelPaxNum { get; set; }
        /// <summary>
        /// 旅客信息列表,散客填NULL
        /// </summary>
        [XmlArrayItem]
        public List<PaxInfo> PaxInfo { get; set; }
        /// <summary>
        /// 常旅客信息,散客填NULL
        /// </summary>
        [XmlElement]
        public FFPItem ffpItem { get; set; }
        /// <summary>
        /// 集团大客户信息,非集团客户填NULL
        /// </summary>
        [XmlElement]
        public KAItem kaItem { get; set; }
        /// <summary>
        /// 代理人信息
        /// </summary>
        [XmlElement]
        public AGTItem agtItem { get; set; }
        /// <summary>
        /// 航段资料列表
        /// </summary>
        [XmlArrayItem]
        public List<SegmentItem> SEGMENT_ITEM { get; set; }
    }
}
