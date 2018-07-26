using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Mzl.EntityModel.Hotel.Elong
{
    public class ReviewEntity
    {

        /// <summary>
        /// 评论总数
        /// </summary>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string Count { get; set; }

        /// <summary>
        /// 好评数
        /// </summary>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string Good { get; set; }

        /// <summary>
        /// 差评数
        /// </summary>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string Poor { get; set; }

        /// <summary>
        /// 好评率
        /// </summary>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string Score { get; set; }
    }
}
