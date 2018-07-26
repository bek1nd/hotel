using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace Mzl.EntityModel.Proxy.MuB2T
{
    /// <summary>
    /// 仓位价格信息列表（在返回时使用）
    /// </summary>
    //[Serializable]
    public class ClasFare
    {
        /// <summary>
        /// 仓位代码(一码)
        /// </summary>
        //[XmlElement]
        public string CLAS_TP { get; set; }
        /// <summary>
        /// 仓是否使用集团大客户政策标记政策仓位 置1
        /// </summary>
        //[XmlElement]
        public string policy { get; set; }
        /// <summary>
        /// 价格列表
        /// </summary>
        //[XmlArrayItem]
        public List<FareInfo> fareInfo { get; set; }
        ///// <summary>
        ///// 
        ///// </summary>
        ////[XmlElement]
        //public string sg_fcct { get; set; }
        ///// <summary>
        ///// 
        ///// </summary>
        ////[XmlElement]
        //public List<FareInfo> sg_fccf { get; set; }
    }
}
