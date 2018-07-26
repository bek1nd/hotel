using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Mzl.EntityModel.Hotel.Elong
{
    public class RoomEntity
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
        /// 楼层
        /// </summary>
        public string Floor { get; set; }

        /// <summary>
        /// 上网情况
        /// </summary>
        public string Broadnet { get; set; }

        /// <summary>
        /// yeano:文档中没有出现，推测为床型
        /// </summary>
        public string BedType { get; set; }

        /// <summary>
        /// yeano:文档中没出现，推测为描述
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// yeano：文档中没出现
        /// </summary>
        public string Area { get; set; }

        /// <summary>
        /// yeano:文档中没出现
        /// </summary>
        public string ImageUrl { get; set; }

        /// <summary>
        /// 产品信息
        /// </summary>
        public ListRatePlanEntity[] RatePlans { get; set; }

        /// <summary>
        /// yeano:文档中没出现
        /// </summary>
        public string Comments { get; set; }

        /// <summary>
        /// yeano:文档中没出现
        /// </summary>
        public string Capcity { get; set; }

        /// <summary>
        /// yeano:文档中没出现
        /// </summary>
        public string RoomAmenityIds { get; set; }
    }
}
