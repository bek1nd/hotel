using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mzl.EntityModel.Proxy.CTripHotel.HotelDetailPrice
{
   public class PriceInfo
    {
        /// <summary>
        /// Prices
        /// </summary>
        public List<Price> Prices { get; set; }
        /// <summary>
        /// DailyPrices
        /// </summary>
        public List<DailyPrice> DailyPrices { get; set; }
        /// <summary>
        /// Taxes
        /// </summary>
        public List<Taxe> Taxes { get; set; }
        /// <summary>
        /// Fees
        /// </summary>
        public List<Fee> Fees { get; set; }
        /// <summary>
        /// 支付类型，PP-预付，FG-到付
        /// </summary>
        public string PayType { get; set; }
        /// <summary>
        /// 该售卖房型的所属分类，详情：
        ///  501-标准预付房型;
        ///  502-促销预付房型;
        /// 16-标准到付房型;
        /// 14-促销到付房型;
        /// </summary>
        public string RatePlanCategory { get; set; }
        /// <summary>
        /// 售卖房型是否可预订，true-可预订，false-不可预订
        /// </summary>
        public bool IsCanReserve { get; set; }
        /// <summary>
        /// 售卖房型是否需担保，true-需担保，false-不需担保
        /// </summary>
        public bool IsGuarantee { get; set; }
        /// <summary>
        /// 售卖房型是否可立即确认(仅代表订单确认速度，分销商仍需通过相关接口同步携程订单状态)。True-该房型为立即确认房型，false-该房型非立即确认房型
        /// </summary>
        public bool IsInstantConfirm { get; set; }
        /// <summary>
        /// 可定房量，10间以内显示真实房量，大于10间显示”10+”
        /// </summary>
        public string RemainingRooms { get; set; }
        /// <summary>
        /// 可定检查流水号。部分国家酒店的售卖房型会返回该参数
        /// </summary>
        public string BookingCode { get; set; }
        /// <summary>
        /// 价格计划ID，部分国家酒店的售卖房型会返回该参数
        /// </summary>
        public string RatePlanID { get; set; }
    }
}
