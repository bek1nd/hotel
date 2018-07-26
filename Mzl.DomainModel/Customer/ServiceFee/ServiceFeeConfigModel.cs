using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mzl.DomainModel.Customer.ServiceFee
{
    public class ServiceFeeConfigModel
    {
        /// <summary>
        /// 主键
        /// </summary>
        public int SfcId { get; set; }
        /// <summary>
        /// 廉价航空公司
        /// </summary>
        public string AirlineName { get; set; }
        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime? CreateTime { get; set; }
        /// <summary>
        /// 创建人
        /// </summary>
        public string Oid { get; set; }
        /// <summary>
        /// 服务费政策名称
        /// </summary>
        public string ServiceFeeName { get; set; }
        /// <summary>
        /// 航司代码
        /// </summary>
        public string AirlineCode { get; set; }
    }
}
