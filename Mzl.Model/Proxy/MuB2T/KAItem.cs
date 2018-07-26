using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace Mzl.EntityModel.Proxy.MuB2T
{
    /// <summary>
    /// 集团大客户信息,非集团客户填NULL
    /// </summary>
    //[Serializable]
    public class KAItem
    {
        /// <summary>
        /// 集团客户编号(当客户类型是“KA”时必须填写)
        /// </summary>
        //[XmlElement]
        public string KA_CD { get; set; }
        /// <summary>
        /// 集团客户等级(当集团客户编号存在时可填写)
        /// </summary>
        //[XmlElement]
        public string KA_LEVEL_TP { get; set; }
        /// <summary>
        /// 集团客户员工等级
        /// </summary>
        //[XmlElement]
        public string KA_EMP_LEVEL { get; set; }
    }
}
