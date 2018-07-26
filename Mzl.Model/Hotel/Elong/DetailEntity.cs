using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Mzl.EntityModel.Hotel.Elong
{
    /// <summary>
    /// 酒店信息
    /// </summary>
    public class DetailEntity
    {

        /// <summary>
        /// 酒店名称
        /// </summary>
        public string HotelName { get; set; }

        /// <summary>
        /// 挂牌星级
        /// </summary>
        public int StarRate { get; set; }

        /// <summary>
        /// 艺龙推荐级别
        /// </summary>
        public int Category { get; set; }

        /// <summary>
        /// 维度
        /// 
        /// 采用Google坐标系，其他坐标系请联系对应的厂商获取转换方法
        /// 当入参Opitons包含8的时候，输出为百度坐标。
        /// </summary>
        public string Latitude { get; set; }

        /// <summary>
        /// 经度
        /// 
        /// 采用Google坐标系，其他坐标系请联系对应的厂商获取转换方法
        /// 当入参Opitons包含8的时候，输出为百度坐标。
        /// </summary>
        public string Longitude { get; set; }

        /// <summary>
        /// 地址
        /// </summary>
        public string Address { get; set; }

        /// <summary>
        /// 前台电话
        /// </summary>
        public string Phone { get; set; }

        /// <summary>
        /// 封面图片
        /// </summary>
        public string ThumbNailUrl { get; set; }

        /// <summary>
        /// 城市ID
        /// </summary>
        public string City { get; set; }

        /// <summary>
        /// 城市名称
        /// </summary>
        public string CityName { get; set; }

        /// <summary>
        /// 行政区ID
        /// </summary>
        public string District { get; set; }

        /// <summary>
        /// 行政区名称
        /// </summary>
        public string DistrictName { get; set; }

        /// <summary>
        /// 商业区ID
        /// </summary>
        public string BusinessZone { get; set; }

        /// <summary>
        /// 商业区名称
        /// </summary>
        public string BusinessZoneName { get; set; }


        /// <summary>
        /// 用户评论
        /// </summary>
        public ReviewEntity Review { get; set; }

        /// <summary>
        /// yeano:文档中没有提及
        /// </summary>
        public string Features { get; set; }

        /// <summary>
        /// 酒店服务
        /// </summary>
        public string GeneralAmenities { get; set; }

        /// <summary>
        /// 交通
        /// </summary>
        public string Traffic { get; set; }
    }
}
