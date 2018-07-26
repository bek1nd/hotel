using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace Mzl.EntityModel.Proxy.MuB2T
{
    /// <summary>
    /// 旅客信息列表
    /// </summary>
    //[Serializable]
    public class PaxInfo
    {
        /// <summary>
        /// 旅客证件类型
        /// </summary>
        //[XmlElement]
        public string PAX_ID_TP { get; set; }
        /// <summary>
        /// 证件号码
        /// </summary>
        //[XmlElement]
        public string PAX_ID_NO { get; set; }
        /// <summary>
        /// 生日
        /// </summary>
        //[XmlElement]
        public string PAX_BRTH_DT { get; set; }
        /// <summary>
        /// 性别
        /// </summary>
        //[XmlElement]
        public string PAX_GENDER { get; set; }
        /// <summary>
        /// ｅｍａｉｌ
        /// </summary>
        //[XmlElement]
        public string PAX_EMAIL { get; set; }
        /// <summary>
        /// 旅客类型
        /// </summary>
        //[XmlElement]
        public string PAX_TYPE_CD { get; set; }
        /// <summary>
        /// 手机号码
        /// </summary>
        //[XmlElement]
        public string PAX_MOBILE { get; set; }
        /// <summary>
        /// ＱＱ账号
        /// </summary>
        //[XmlElement]
        public string PAX_QQ_NO { get; set; }
        /// <summary>
        /// ＭＳＮ账号
        /// </summary>
        //[XmlElement]
        public string PAX_MSN { get; set; }
        /// <summary>
        /// 淘宝账号
        /// </summary>
        //[XmlElement]
        public string PAX_TAOBAO { get; set; }
        /// <summary>
        /// 旅客职业
        /// </summary>
        //[XmlElement]
        public string PAX_INDUSTRY { get; set; }
        /// <summary>
        /// 婚姻情况
        /// </summary>
        //[XmlElement]
        public string PAX_ISMARRIED { get; set; }
    }
}
