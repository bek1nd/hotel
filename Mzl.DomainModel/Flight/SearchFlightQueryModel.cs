using Mzl.DomainModel.Customer.Base;
using Mzl.DomainModel.Customer.Corp;
using Mzl.DomainModel.Customer.CorpDepartment;
using Mzl.DomainModel.Customer.CorpPolicy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mzl.DomainModel.Flight
{
    public class SearchFlightQueryModel
    {
        /// <summary>
        /// 公司Id
        /// </summary>
        public string CorpId { get; set; }
        /// <summary>
        /// 出发机场三字码
        /// </summary>
        public string Dport { get; set; }
        /// <summary>
        /// 到达机场三字码
        /// </summary>
        public string Aport { get; set; }
        /// <summary>
        /// 出发日期
        /// </summary>
        public DateTime TackOffTime { get; set; }
        /// <summary>
        /// 航司二字码名称
        /// </summary>
        public string AirlineNo { get; set; }
        /// <summary>
        /// 符合该客户查询航班的差旅政策信息
        /// </summary>
        public CorpPolicyDetailConfigModel CorpPolicy { get; set; }

        public string IsMaster { get; set; }
        public List<string> CardNoList { get; set; }
        public List<string> PassengerNameList { get; set; }

        public string Class { get; set; }
        public string OrderSource { get; set; }


        /// <summary>
        /// 共享航班显示  0否 1是
        /// </summary>
        public int? IsShareFly { get; set; }
        /// <summary>
        /// 协议价格是否单独展示  0否 1是
        /// </summary>
        public int? IsXYPrice { get; set; }
        /// <summary>
        /// 是否显示全部舱位  0否 1是
        /// </summary>
        public int? IsAllSeat { get; set; }
        /// <summary>
        /// 是否显示最高舱位  0否 1是
        /// </summary>
        public int? IsHeightSeat { get; set; }
    }
}
