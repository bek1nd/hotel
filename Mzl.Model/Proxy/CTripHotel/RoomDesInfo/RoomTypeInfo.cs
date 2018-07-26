using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mzl.EntityModel.Proxy.CTripHotel.RoomDesInfo
{
    public class RoomTypeInfo
    {
        public Smoking Smoking { get; set; }
        public BroadNet BroadNet { get; set; }
        public ChildLimit ChildLimit { get; set; }
        public IList<Facility> Facilities { get; set; }
        public IList<Picture> Pictures { get; set; }
        public IList<Description> Descriptions { get; set; }
        public IList<RoomBedInfo> RoomBedInfos { get; set; }
        /// <summary>
        /// 物理房型ID
        /// </summary>
        public int RoomTypeID { get; set; }
        /// <summary>
        /// 物理房型名称
        /// </summary>
        public string RoomTypeName { get; set; }
        /// <summary>
        /// 标准房型名称
        /// </summary>
        public string StandardRoomType { get; set; }
        /// <summary>
        /// 客房数量
        /// </summary>
        public int RoomQuantity { get; set; }
        /// <summary>
        /// 物理房型的最多入住人数
        /// </summary>
        public int MaxOccupancy { get; set; }
        /// <summary>
        /// 物理房型的建筑面积
        /// </summary>
        public string AreaRange { get; set; }
        /// <summary>
        /// 定义物理房型适用的楼层
        /// </summary>
        public string FloorRange { get; set; }
        /// <summary>
        /// 定义物理房型是否有窗：0-无窗；1-部分有窗；2-有窗；4-内窗；5-天窗；6-封闭窗；7-飘窗；-100未知；
        /// </summary>
        public int HasWindow { get; set; }
        /// <summary>
        /// 定义顾客是否需要支付额外加床费用：“Uknown”-未知；空-不能加床；0-免费加床；若值大于0，则是所需额外加床费
        /// </summary>
        public string ExtraBedFee { get; set; }
        /// <summary>
        /// Unknown:未知,1:独立卫浴,2:公共卫浴
        /// </summary>
        public string BathRoomType { get; set; }
    }
}
