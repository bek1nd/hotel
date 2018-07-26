using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace Mzl.EntityModel.Proxy.MuB2T
{
    /// <summary>
    /// 代理人信息
    /// </summary>
    //[Serializable]
    public class AGTItem
    {
        /// <summary>
        /// 代理人IATA号(当客户类型是“AG”时必须填写；当代理人有多个IATA号码时，任选一个)
        /// </summary>
        //[XmlElement] 
        public string AGT_IATA_NO { get; set; }
        /// <summary>
        /// 代理人等级(当客户类型是“AG”时可填写)
        /// </summary>
        //[XmlElement]
        public string AGT_LEVEL_TP { get; set; }
    }
}
