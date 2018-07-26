using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace Mzl.EntityModel.Proxy.MuB2T
{
    /// <summary>
    /// 常旅客信息
    /// </summary>
    //[Serializable]
    public class FFPItem
    {
        /// <summary>
        /// 航空公司代码
        /// </summary>
        //[XmlElement]
        public string FFP_CARR_CD { get; set; }
        /// <summary>
        /// 常旅客卡号
        /// </summary>
        //[XmlElement]
        public string FFP_CARD_NO { get; set; }
        /// <summary>
        /// 常旅客等级(仅当ProductType =FF时需填写)
        /// </summary>
        //[XmlElement]
        public string FFP_LEVEL_TP { get; set; }
    }
}
