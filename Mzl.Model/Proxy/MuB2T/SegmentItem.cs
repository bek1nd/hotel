using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace Mzl.EntityModel.Proxy.MuB2T
{
    /// <summary>
    /// 航段资料列表
    /// </summary>
    //[Serializable]
    public class SegmentItem
    {
        /// <summary>
        /// 航段
        /// </summary>
        //[XmlElement]
        public string SEGMENT { get; set; }
        /// <summary>
        /// 航段起飞日期(起飞地当地时间)
        /// </summary>
        //[XmlElement]
        public string DEP_DT { get; set; }
        /// <summary>
        /// 单段开票截止时间，散客填null
        /// </summary>
        //[XmlElement]
        public string SEG_TKT_DEADLINE { get; set; }
        /// <summary>
        /// 航班信息列表
        /// </summary>
        //[XmlArrayItem]
        //[XmlElement]
        public List<FltItem> fltItem { get; set; }
       
        #region 2017-09-01新增字段
        public string STOP_ENG { get; set; }

        //public string getSEGMENT { get; set; }    
        //public string getDEP_DT { get; set; }
        //public string setDEP_DT { get; set; }
        //public string getSEG_TKT_DEADLINE{ get; set; }
        //public string setSEG_TKT_DEADLINE { get; set; }
        //public string getSTOP_ENG { get; set; }
        //public string setSTOP_ENG { get; set; }

        #endregion
        #region
        ///// <summary>
        ///// 
        ///// </summary>
        ////[XmlElement]
        //public string sg_fn { get; set; }
        ///// <summary>
        ///// 
        ///// </summary>
        ////[XmlElement]
        //public string sg_ft { get; set; }
        ///// <summary>
        ///// 
        ///// </summary>
        ////[XmlElement]
        //public string sg_fs { get; set; }
        ///// <summary>
        ///// 
        ///// </summary>
        ////[XmlElement]
        //public string sg_fm { get; set; }
        ///// <summary>
        ///// 
        ///// </summary>
        ////[XmlElement]
        //public string sg_fr { get; set; }
        ///// <summary>
        ///// 
        ///// </summary>
        ////[XmlElement]
        //public string sg_fy { get; set; }
        ///// <summary>
        ///// 
        ///// </summary>
        ////[XmlElement]
        //public string sg_fj { get; set; }
        ///// <summary>
        ///// 
        ///// </summary>
        ////[XmlElement]
        //public string sg_ff { get; set; }
        ///// <summary>
        ///// 
        ///// </summary>
        ////[XmlElement]
        //public string sg_am { get; set; }
        ///// <summary>
        ///// 
        ///// </summary>
        ////[XmlElement]
        //public string sg_fyw { get; set; }
        ///// <summary>
        ///// 
        ///// </summary>
        ////[XmlElement]
        //public string sg_ffw { get; set; }
        #endregion
    }
}
