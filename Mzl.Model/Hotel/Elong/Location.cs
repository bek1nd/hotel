using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Mzl.EntityModel.Hotel.Elong
{
    /// <summary>
    /// 图片地址
    /// </summary>
    public class Location
    {

        /// <summary>
        /// 是否有水印
        /// 
        /// 0-N,1-Y
        /// </summary>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string WaterMark { get; set; }

        /// <summary>
        ///  	
        /// 1：jpg图片，固定长边350，固定长边350缩放(用于详情页图片展示)
        /// 2：jpg图片，尺寸70x70(用于详情页图片列表的缩微图)
        /// 3：jpg图片，尺寸120x120(用于列表页)
        /// 5：png图片，尺寸70x70
        /// 6：png图片，尺寸120x120
        /// 7：png图片，固定长边640放缩
        /// </summary>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public int Size { get; set; }

        /// <summary>
        /// 节点内容
        /// 
        /// 图片的http地址
        /// </summary>
        [System.Xml.Serialization.XmlTextAttribute()]
        public string Url { get; set; }
    }
}
