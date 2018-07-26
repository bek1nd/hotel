using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace Mzl.EntityModel.Proxy.MuB2T
{
    /// <summary>
    /// 旅客人数信息
    /// </summary>
    //[Serializable]
    public class SEL_PAX_NUM
    {
        /// <summary>
        /// 成人数
        /// </summary>
        //[XmlElement]
        public int? ADT_CNT { get; set; }
        /// <summary>
        /// 儿童数
        /// </summary>
        //[XmlElement]
        public int? CHD_CNT { get; set; }
        /// <summary>
        /// 婴儿数
        /// </summary>
        //[XmlElement]
        public int? INF_CNT { get; set; }
    }
}
