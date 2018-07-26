using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mzl.EntityModel.Proxy.CTripHotel.HotelDesInfo
{
    public class AcceptedCreditCard
    {
        /// <summary>
        /// 信用卡类型代码
        /// 适用于“酒店接受的信用卡（后付费）”部分
        /// </summary>
        public string CardType { get; set; }
        /// <summary>
        /// 发卡行
        /// </summary>
        public string CardName { get; set; }
    }
}
