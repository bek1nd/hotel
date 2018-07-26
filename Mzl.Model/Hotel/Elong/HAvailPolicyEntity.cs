using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Mzl.EntityModel.Hotel.Elong
{

    public class HAvailPolicyEntity
    {
        /// <summary>
        /// 提示编号
        /// </summary>
        public string Id { get; set; }


        /// <summary>
        /// 提示内容
        /// </summary>
        public string AvailPolicyText { get; set; }

        /// <summary>
        /// 有效开始时间
        /// </summary>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string StartDate { get; set; }

        /// <summary>
        /// 有效结束时间
        /// </summary>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string EndDate { get; set; }
    }
}
