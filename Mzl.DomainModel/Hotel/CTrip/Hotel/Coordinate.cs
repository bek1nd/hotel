using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mzl.DomainModel.Hotel.CTrip.Hotel
{
    public class Coordinate
    {
        /// <summary>
        /// 坐标提供者
        /// </summary>
        public string Provider { get; set; }
        /// <summary>
        /// 酒店经度
        /// </summary>
        public double LNG { get; set; }
        /// <summary>
        /// 酒店纬度
        /// </summary>
        public double LAT { get; set; }
    }
}
