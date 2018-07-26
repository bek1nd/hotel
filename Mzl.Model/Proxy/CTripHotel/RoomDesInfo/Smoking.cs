using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mzl.EntityModel.Proxy.CTripHotel.RoomDesInfo
{
    public class Smoking
    {
        /// <summary>
        /// 定义酒店是否能为客人安排无烟楼层的房间：T-是；F-否；空-无此选项
        /// </summary>
        public string HasRoomInNonSmokingArea { get; set; }
        /// <summary>
        /// 定义该房型是否有无烟房型：T-有；F-无；unknown-不确定
        /// </summary>
        public string HasNonSmokingRoom { get; set; }
        /// <summary>
        /// 定义是否可为此房型提供无烟处理服务：T-是；F-否；空-不确定
        /// </summary>
        public string HasDeorderizedRoom { get; set; }
        /// <summary>
        /// 该房型是否不可吸烟：T-不可吸烟；F-允许吸烟
        /// </summary>
        public string NotAllowSmoking { get; set; }
    }
}
