using Mzl.EntityModel.Proxy.MuB2T;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace Mzl.EntityModel.Proxy.MuB2T
{
    /// <summary>
    /// 国内运价查询回传结果
    /// </summary>
    //[XmlInclude(typeof(RtnEcfareInfo))]
    //[Serializable]
    public class RtnEcfareInfo
    {
        /// <summary>
        /// 航段错误代码
        /// </summary>
        public string ECFARE_ERR_ID { get; set; }
        /// <summary>
        /// 航段错误信息
        /// </summary>
        public string ECFARE_ERR_MSG { get; set; }
        /// <summary>
        /// 运价查询返回主对象
        /// </summary>
        //public List<EcfareInfoOutput> ecfareInfo { get; set; }
        public EcfareInfoOutput ecfareInfo { get; set; }
        #region XML文档
        ///// <summary>
        ///// 
        ///// </summary>
        ////[XmlElement]
        //public string ei { get; set; }
        ///// <summary>
        ///// 
        ///// </summary>
        ////[XmlElement]
        //public string em { get; set; }
        ///// <summary>
        ///// 
        ///// </summary>
        ////[XmlElement]
        //public string eid { get; set; }
        ///// <summary>
        ///// 
        ///// </summary>
        ////[XmlElement]
        //public string fa { get; set; }
        ///// <summary>
        ///// 
        ///// </summary>
        ////[XmlElement]
        //public string ch { get; set; }
        ///// <summary>
        ///// 
        ///// </summary>
        ////[XmlElement]
        //public string rt { get; set; }
        ///// <summary>
        ///// 
        ///// </summary>
        ////[XmlElement]
        //public string cc { get; set; }
        ///// <summary>
        ///// 
        ///// </summary>
        ////[XmlElement]
        //public string cr { get; set; }
        ///// <summary>
        ///// 
        ///// </summary>
        ////[XmlElement]
        //public string td { get; set; }
        ///// <summary>
        ///// 
        ///// </summary>
        ////[XmlElement]
        //public string ed { get; set; }
        ///// <summary>
        ///// 
        ///// </summary>
        ////[XmlElement]
        //public string co { get; set; }
        ///// <summary>
        ///// 
        ///// </summary>
        ////[XmlElement]
        //public string tc { get; set; }
        ///// <summary>
        ///// 
        ///// </summary>
        ////[XmlElement]
        //public string sn { get; set; }
        ///// <summary>
        ///// 
        ///// </summary>
        ////[XmlElement]
        //public string pt { get; set; }
        ///// <summary>
        ///// 
        ///// </summary>
        ////[XmlElement]
        //public string gi { get; set; }
        ///// <summary>
        ///// 
        ///// </summary>
        ////[XmlElement]
        //public string prc { get; set; }
        ///// <summary>
        ///// 
        ///// </summary>
        ////[XmlElement]
        //public string jf_type { get; set; }
        ///// <summary>
        ///// 
        ///// </summary>
        ////[XmlElement]
        //public string ps_am { get; set; }
        ///// <summary>
        ///// 
        ///// </summary>
        ////[XmlElement]
        //public string ps_cu { get; set; }
        ///// <summary>
        ///// 
        ///// </summary>
        ////[XmlElement]
        //public string sfc { get; set; }
        ///// <summary>
        ///// 
        ///// </summary>
        ////[XmlElement]

        ///// <summary>
        ///// 
        ///// </summary>
        ////[XmlElement]
        //public string sfi { get; set; }
        ///// <summary>
        ///// 
        ///// </summary>
        ////[XmlElement]
        //public string fca { get; set; }
        ///// <summary>
        ///// 
        ///// </summary>
        ////[XmlElement]
        //public string fam { get; set; }
        #endregion

        #region 测试回调结果
        ///// <summary>
        ///// 
        ///// </summary>
        //public string ECFARE_ID { get; set; }
        ///// <summary>
        ///// 
        ///// </summary>
        //public string FARE_SQ { get; set; }
        ///// <summary>
        ///// 
        ///// </summary>
        //public string CHANNEL_CODE { get; set; }
        ///// <summary>
        ///// 
        ///// </summary>
        //public string ROUTE_TYPE { get; set; }
        ///// <summary>
        ///// 
        ///// </summary>
        //public string CURRENCY_CODE { get; set; }
        ///// <summary>
        ///// 
        ///// </summary>
        //public string CURRENCY_RATE { get; set; }
        ///// <summary>
        ///// 
        ///// </summary>
        //public string TICKETING_DL { get; set; }
        ///// <summary>
        ///// 
        ///// </summary>
        //public string ENDORSEMENT { get; set; }
        ///// <summary>
        ///// 
        ///// </summary>
        //public string COMMENT { get; set; }
        ///// <summary>
        ///// 
        ///// </summary>
        //public string TOUR_CODE { get; set; }
        ///// <summary>
        ///// 
        ///// </summary>
        //public string SEGMENT_NUMBER { get; set; }
        ///// <summary>
        ///// 
        ///// </summary>
        //public string PRODUCT_TYPE { get; set; }
        ///// <summary>
        ///// 
        ///// </summary>
        //public string GROUP_INDICATOR { get; set; }
        ///// <summary>
        ///// 
        ///// </summary>
        //public List<SegmentItem> SEGMENT_ITEM { get; set; }
        //public string SPECIAL_FARE_INFO { get; set; }
        //public string FARE_CALCULATION { get; set; }
        //public string FARE_AMOUNT { get; set; }

        #endregion
    }
}
