using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mzl.DomainModel.Customer.ServiceFee
{
    public class ServiceFeeInfoModel
    {
        /// <summary>
        /// 明加服务费
        /// </summary>
        public decimal ServiceFee { get; set; }
        /// <summary>
        /// 暗加服务费
        /// </summary>
        public decimal NightServicefee { get; set; }
        /// <summary>
        /// 火车服务费
        /// </summary>
        public decimal TrainServiceFee { get; set; }
        /// <summary>
        /// 火车抢票服务费
        /// </summary>
        public decimal TrainGrabTicketServiceFee { get; set; } = 5;
        /// <summary>
        /// 酒店服务费
        /// </summary>
        public decimal HotelServiceFee { get; set; }

        /// <summary>
        /// 暗加服务费比值
        /// </summary>
        public decimal NightServicefeeRate { get; set; }
    }
}
