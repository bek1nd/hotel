using System.ComponentModel;

namespace Mzl.UIModel.Hotel.Elong.HotelInfo
{
    public class HotelDetailViewModel
    {
        /// <summary>
        /// 酒店名称
        /// </summary>
        [Description("酒店名称")]
        public string HotelName { get; set; }

        /// <summary>
        /// 挂牌星级
        /// </summary>
        [Description("挂牌星级")]
        public int StarRate { get; set; }

        /// <summary>
        /// 艺龙推荐级别
        /// </summary>
        [Description("艺龙推荐级别")]
        public int Category { get; set; }

        /// <summary>
        /// 维度
        /// 
        /// 采用Google坐标系，其他坐标系请联系对应的厂商获取转换方法
        /// 当入参Opitons包含8的时候，输出为百度坐标。
        /// </summary>
        [Description("维度")]
        public string Latitude { get; set; }

        /// <summary>
        /// 经度
        /// 
        /// 采用Google坐标系，其他坐标系请联系对应的厂商获取转换方法
        /// 当入参Opitons包含8的时候，输出为百度坐标。
        /// </summary>
        [Description("经度")]
        public string Longitude { get; set; }

        /// <summary>
        /// 地址
        /// </summary>
        [Description("地址")]
        public string Address { get; set; }

        /// <summary>
        /// 前台电话
        /// </summary>
        [Description("前台电话")]
        public string Phone { get; set; }

        /// <summary>
        /// 封面图片
        /// </summary>
        [Description("封面图片")]
        public string ThumbNailUrl { get; set; }

        /// <summary>
        /// 城市ID
        /// </summary>
        [Description("城市ID")]
        public string City { get; set; }

        /// <summary>
        /// 城市名称
        /// </summary>
        [Description("城市名称")]
        public string CityName { get; set; }

        /// <summary>
        /// 行政区ID
        /// </summary>
        [Description("酒店信息")]
        public string District { get; set; }

        /// <summary>
        /// 行政区名称
        /// </summary>
        [Description("行政区名称")]
        public string DistrictName { get; set; }

        /// <summary>
        /// 商业区ID
        /// </summary>
        [Description("商业区ID")]
        public string BusinessZone { get; set; }

        /// <summary>
        /// 商业区名称
        /// </summary>
        [Description("商业区名称")]
        public string BusinessZoneName { get; set; }


        /// <summary>
        /// 用户评论
        /// </summary>
        [Description("用户评论")]
        public HotelReviewViewModel Review { get; set; }

        /// <summary>
        /// 特色介绍
        /// </summary>
        [Description("特色介绍")]
        public string Features { get; set; }

        /// <summary>
        /// 酒店服务
        /// </summary>
        [Description("酒店服务")]
        public string GeneralAmenities { get; set; }

        /// <summary>
        /// 交通
        /// </summary>
        [Description("交通")]
        public string Traffic { get; set; }
    }
}
