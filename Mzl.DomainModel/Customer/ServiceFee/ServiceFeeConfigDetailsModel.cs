using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mzl.DomainModel.Customer.ServiceFee
{
    public class ServiceFeeConfigDetailsModel
    {
        /// <summary>
        /// 主键
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// 设置开始时间
        /// </summary>
        public string BeginTime { get; set; }
        /// <summary>
        /// 设置结束时间
        /// </summary>
        public string EndTime { get; set; }
        /// <summary>
        /// 面价反扣
        /// </summary>
        public string Point { get; set; }
        /// <summary>
        /// 明加服务费
        /// </summary>
        public decimal? ServiceFee { get; set; }
        /// <summary>
        /// 暗加服务费
        /// </summary>
        public decimal? NightServicefee { get; set; }
        /// <summary>
        /// 外键（P_ServiceFeeConfig）
        /// </summary>
        public int? SfcId { get; set; }
        /// <summary>
        /// 火车服务费
        /// </summary>
        public decimal? TrainServiceFee { get; set; }
        /// <summary>
        /// 火车抢票服务费
        /// </summary>
        public decimal? TrainGrabTicketServiceFee { get; set; }
        /// <summary>
        /// 酒店服务费
        /// </summary>
        public decimal? HotelServiceFee { get; set; }
    }
}
