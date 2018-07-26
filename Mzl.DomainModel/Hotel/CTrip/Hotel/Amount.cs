using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mzl.DomainModel.Hotel.CTrip.Hotel
{
    public class Amount
    {
        /// <summary>
        /// 此条价格的所属类型，如：原币种价、自定义币种价
        /// </summary>
        public string Type { get; set; }
        /// <summary>
        /// 金额
        /// </summary>
        public double amount { get; set; }
        /// <summary>
        /// 币种
        /// </summary>
        public string Currenty { get; set; }

    }
}
