using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mzl.DomainModel.Hotel.CTrip.Hotel
{
    public class LimitInfo
    {
        /// <summary>
        /// 限制类型
        /// Age:年龄；Height:身高
        /// </summary>
        public string Type { get; set; }
        /// <summary>
        /// 起始时间
        /// </summary>
        public string Min { get; set; }
        /// <summary>
        /// 起始时间
        /// </summary>
        public string Max { get; set; }
    }
}
