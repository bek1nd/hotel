using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Mzl.EntityModel.Hotel.Elong
{
    public class HotelImg
    {
        /// <summary>
        /// 关联的房型
        /// 
        /// 有值则表示这是对应房型的图片
        /// </summary>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string RoomId { get; set; }

        /// <summary>
        /// 是否是主图
        /// </summary>
        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public Boolean IsCoverImage { get; set; }


        /// <summary>
        /// yeano:文档中没有提及
        /// </summary>
        public string IsRoomCoverImage { get; set; }

        /// <summary>
        /// 图片地址
        /// </summary>
        public Location[] Locations { get; set; }

        /// <summary>
        /// 图片类型
        /// 
        /// 详见EnumImageType
        /// 
        ///  1 - 餐厅 (Restaurant)
        ///  2 - 休闲 (Recreation Facilities)
        ///  3 - 会议室 (Meeting/Conference)
        ///  5 - 外观 (Exterior)
        ///  6 - 大堂/接待台 (Lobby/ Reception)
        ///  8 - 客房 (Guest Room)
        ///  10 - 其他 (Other Facilities)
        ///  11 - 公共区域 (Public Area)
        ///  12 - 周边景点 (Nearby Attractions)
        /// </summary>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public int Type { get; set; }




        /// <summary>
        /// 作者类型
        /// 
        /// Hotel - 酒店
        /// User - 用户
        /// </summary>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string AuthorType { get; set; }
    }
}
