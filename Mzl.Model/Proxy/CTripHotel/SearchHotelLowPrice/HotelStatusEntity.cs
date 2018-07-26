using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mzl.EntityModel.Proxy.CTripHotel.SearchHotelLowPrice
{
    public class HotelStatusEntity
    {
        /// <summary>
        /// 酒店ID
        /// </summary>
        public int Hotel { get; set; }
        /// <summary>
        /// 最低价房型的日均最低价，币种为人民币
        /// </summary>
        public double MinPrice { get; set; }
        /// <summary>
        /// 最低价房型的日均最低价，币种为原币种，原币种为Currency_minPrice节点的取值
        /// </summary>
        public double MinPrice_MyCurrentcy { get; set; }
        /// <summary>
        /// 原币种
        /// </summary>
        public string Currency_minPrice { get; set; }
        /// <summary>
        /// 最低价的售卖房型ID
        /// </summary>
        public int MinPriceRoom { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public MinPriceInfoEntity MinPriceInfoEntity { get; set; }
    }
}
