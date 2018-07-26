using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace Mzl.EntityModel.Proxy.MuB2T
{
    /// <summary>
    /// 直达国内运价查询条件
    /// </summary>   
    //[XmlRoot("r")]
    //[Serializable]
    public class EcfareInfoInput
    {
        /// <summary>
        /// ECFare账号
        /// </summary>
        //[XmlElement]
        public string USR_ID { get; set; }
        /// <summary>
        /// ECFare密码
        /// </summary>
        //[XmlElement]
        public string USR_PWD { get; set; }
        /// <summary>
        /// 方案类别说
        /// </summary>
        //[XmlArrayItem]
        //public SEARCH_ITEM SEARCH_ITEM { get; set; }
        /// <summary>
        /// 渠道代碼
        /// </summary>
        //[XmlElement]
        public string CHANNEL_CODE { get; set; }
        /// <summary>
        /// 貨比代碼
        /// </summary>
        //[XmlElement]
        public string CURRENCY_CODE { get; set; }
        /// <summary>
        /// 
        /// </summary>
        //[XmlElement]
        public string FARE_TYPE { get; set; }
        /// <summary>
        /// 
        /// </summary>
        //[XmlElement]
        public string GROUP_INDICATOR { get; set; }
        /// <summary>
        /// 產品類型
        /// </summary>
        //[XmlElement]
        public string PRODUCT_TYPE { get; set; }
        /// <summary>
        /// 
        /// </summary>
        //[XmlElement]
        public string LANGUAGE { get; set; }
        /// <summary>
        /// 
        /// </summary>
        //[XmlElement]
        public string ROUTE_TYPE { get; set; }
        /// <summary>
        /// 
        /// </summary>
        //[XmlElement]
        public string TICKETING_DATE { get; set; }
        /// <summary>
        /// 
        /// </summary>
        //[XmlArrayItem]
        //[XmlElement]
        //public List<SegmentItem> SegItem { get; set; }
        /// <summary>
        /// 
        /// </summary>
        //[XmlElement]
        public string PASSENGER_TYPE { get; set; }
        /// <summary>
        /// 
        /// </summary>
        //[XmlElement]
        public string SEGMENT_NUMBER { get; set; }
        /// <summary>
        /// 
        /// </summary>
        //[XmlElement]
        public string SPECIAL_FARE_CODE { get; set; }
        /// <summary>
        /// 
        /// </summary>
        //[XmlElement]
        public bool? LOG_FG { get; set; }
        #region 2017-09-01新增字段

        public SEL_PAX_NUM selPaxNum;
        public List<PaxInfo> paxInfo { get; set; }
        public FFPItem ffpItem { get; set; }
        public KAItem kaItem { get; set; }
        public AGTItem agtItem { get; set; }

        public List<SegmentItem> SEGMENT_ITEM { get; set; }

        public MemShipPointItem MEM_POINTS_ITEM { get; set; }
        public string promoCode { get; set; }
        public string JF_TYPE { get; set; }
        public string PRODUCT_SPECIAL { get; set; }
        public string PASSENGER_NUMBER { get; set; }
        //public bool? getLOG_FG { get; set; }
        public string OFFICE_CODE { get; set; }
        public string STAY_DAYS { get; set; }
        public string addonFlg { get; set; }
        #endregion
    }
}
