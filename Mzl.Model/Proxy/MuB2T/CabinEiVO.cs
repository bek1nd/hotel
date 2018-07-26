using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace Mzl.EntityModel.Proxy.MuB2T
{
    /// <summary>
    /// 退改签对象
    /// </summary>
    //[Serializable]
    public class CabinEiVO
    {
        /// <summary>
        /// 退票金额
        /// </summary>
        //[XmlElement]
        public float? refundedAm { get; set; }
        /// <summary>
        /// 退票金额表示是否是用百分比 0：表示否 1：表示是
        /// </summary>
        //[XmlElement]
        public string refundedAmPer { get; set; }
        /// <summary>
        /// 退根据父舱位的价格退票 0:表示否 1：表示是 默认是0
        /// </summary>
        //[XmlElement]
        public string refundedParentFlag { get; set; }
        /// <summary>
        /// 是否可退票
        /// </summary>
        //[XmlElement]
        public string refundedFlag { get; set; }
        /// <summary>
        /// 改期金额
        /// </summary>
        //[XmlElement]
        public float? rescheduledAm { get; set; }
        /// <summary>
        /// 根据父舱位的价格改期 0:表示否 1：表示是 默认是0
        /// </summary>
        //[XmlElement]
        public string rescheduledParentFlag { get; set; }
        /// <summary>
        /// 改期金额表示是否是用百分比 0：表示否 1：表示是
        /// </summary>
        //[XmlElement]
        public string rescheduledAmPer { get; set; }
        /// <summary>
        /// 是否可改期
        /// </summary>
        //[XmlElement]
        public string rescheduledFlag { get; set; }
        /// <summary>
        /// 改签金额
        /// </summary>
        //[XmlElement]
        public float? changeAirLineAm { get; set; }
        /// <summary>
        /// 改签金额表示是否是用百分比 0：表示否 1：表示是
        /// </summary>
        //[XmlElement]
        public string changeAirLineAmPer { get; set; }
        /// <summary>
        /// 是否可改签
        /// </summary>
        //[XmlElement]
        public string changeAirLineFlag { get; set; }
        /// <summary>
        /// 退最大时间
        /// </summary>
        //[XmlElement]
        public int? maxTime { get; set; }
        /// <summary>
        /// 最大时间单位，包含D(天),N(分钟),H(小时),M(月)
        /// </summary>
        //[XmlElement]
        public string maxTimeUnit { get; set; }
        /// <summary>
        /// 最短时间
        /// </summary>
        //[XmlElement]
        public int? minTime { get; set; }
        /// <summary>
        /// 最短时间单位，包含D(天),N(分钟),H(小时),M(月)
        /// </summary>
        //[XmlElement]
        public string minTimeUnit { get; set; }
        /// <summary>
        /// 起飞前 0 ， 起飞后 1，如果为空，标识不限制
        /// </summary>
        //[XmlElement]
        public string timeflag { get; set; }
        /// <summary>
        /// 最短时间是否含，开闭集，0表示是开集，1表示是闭集
        /// </summary>
        //[XmlElement]
        public string minTimeFlag { get; set; }
        /// <summary>
        /// 最长时间是否含，开闭集，0表示是开集，1表示是闭集
        /// </summary>
        //[XmlElement]
        public string maxTimeFlag { get; set; }

        #region
        ///// <summary>
        ///// 
        ///// </summary>
        ////[XmlElement]
        //public string sg_fccfeia { get; set; }
        ///// <summary>
        ///// 
        ///// </summary>
        ////[XmlElement]
        //public string sg_fccfeib { get; set; }
        ///// <summary>
        ///// 
        ///// </summary>
        ////[XmlElement]
        //public string sg_fccfeic { get; set; }
        ///// <summary>
        ///// 
        ///// </summary>
        ////[XmlElement]
        //public string sg_fccfeid { get; set; }
        ///// <summary>
        ///// 
        ///// </summary>
        ////[XmlElement]
        //public string sg_fccfeie { get; set; }
        ///// <summary>
        ///// 
        ///// </summary>
        ////[XmlElement]
        //public string sg_fccfeif { get; set; }
        ///// <summary>
        ///// 
        ///// </summary>
        ////[XmlElement]
        //public string sg_fccfeig { get; set; }
        ///// <summary>
        ///// 
        ///// </summary>
        ////[XmlElement]
        //public string sg_fccfeih { get; set; }
        ///// <summary>
        ///// 
        ///// </summary>
        ////[XmlElement]
        //public string sg_fccfeii { get; set; }
        ///// <summary>
        ///// 
        ///// </summary>
        ////[XmlElement]
        //public string sg_fccfeij { get; set; }
        ///// <summary>
        ///// 
        ///// </summary>
        ////[XmlElement]
        //public string sg_fccfeik { get; set; }
        ///// <summary>
        ///// 
        ///// </summary>
        ////[XmlElement]
        //public string sg_fccfeil { get; set; }
        ///// <summary>
        ///// 
        ///// </summary>
        ////[XmlElement]
        //public string sg_fccfeim { get; set; }
        ///// <summary>
        ///// 
        ///// </summary>
        ////[XmlElement]
        //public string sg_fccfein { get; set; }
        ///// <summary>
        ///// 
        ///// </summary>
        ////[XmlElement]
        //public string sg_fccfeio { get; set; }
        ///// <summary>
        ///// 
        ///// </summary>
        ////[XmlElement]
        //public string sg_fccfeip { get; set; }        
        #endregion
    }
}
