using System.Collections.Generic;
using System.ComponentModel;

namespace Mzl.DomainModel.Hotel.Elong.HotelInfo
{
    public class HotelRoomsModel
    {
        /// <summary>
        /// 展示房型编码
        /// </summary>
        public string RoomId { get; set; }
        /// <summary>
        /// 房型名称
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 产品信息
        /// </summary>
        public List<HotelRatePlanModel> RatePlans { get; set; }
        /// <summary>
        /// 图片地址
        /// </summary>
        [Description("图片地址")]
        public string ImageUrl { get; set; }
        /// <summary>
        /// 楼层
        /// </summary>
        [Description("楼层")]
        public string Floor { get; set; }
        /// <summary>
        /// 上网情况 0-无 1-免费宽带 2-收费宽带 3-免费WIFI 4-收费WIFI
        /// </summary>
        [Description("上网情况")]
        public string Broadnet { get; set; }
        /// <summary>
        /// 床型
        /// </summary>
        [Description("床型")]
        public string BedType { get; set; }
        /// <summary>
        /// 床型描述
        /// </summary>
        [Description("床型描述")]
        public string BedDesc { get; set; }
        /// <summary>
        /// 房间描述
        /// </summary>
        [Description("房间描述")]
        public string Description { get; set; }
        /// <summary>
        /// 房间备注
        /// </summary>
        [Description("房间备注")]
        public string Comments { get; set; }
        /// <summary>
        /// 面积
        /// </summary>
        [Description("面积")]
        public string Area { get; set; }
        /// <summary>
        /// 可容纳人数
        /// </summary>
        [Description("可容纳人数")]
        public string Capcity { get; set; }
    }
}
