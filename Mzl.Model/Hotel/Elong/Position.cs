using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mzl.EntityModel.Hotel.Elong
{
    /// <summary>
    /// 位置
    /// 
    /// 
    /// </summary>
    public class Position
    {
        /// <summary>
        /// 经度
        /// </summary>
        public decimal Longitude { get; set; }

        /// <summary>
        /// 维度
        /// </summary>
        public decimal Latitude { get; set; }

        /// <summary>
        /// 半径
        /// 
        /// 单位：米,最大20km
        /// </summary>
        public int Radius { get; set; }

        /// <remarks/>
        public bool IsGoogleData { get; set; }
    }
}
