using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mzl.DomainModel.Hotel.CTrip.Hotel
{
    public class TransportationInfo
    {
        /// <summary>
        /// 坐标
        /// </summary>
        public IList<Coordinate> Coordinates { get; set; }
        /// <summary>
        /// 地标名称
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// 地标类型
        /// </summary>
        public string Type { get; set; }
        /// <summary>
        /// 酒店与地标的距离
        /// </summary>
        public string Distance { get; set; }
        /// <summary>
        /// 到达方式
        /// </summary>
        public string Directions { get; set; }
    }
}
