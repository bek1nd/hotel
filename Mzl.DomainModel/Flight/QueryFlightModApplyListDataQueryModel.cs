using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mzl.DomainModel.Base;
using Mzl.DomainModel.Customer.Base;

namespace Mzl.DomainModel.Flight
{
    public class QueryFlightModApplyListDataQueryModel : BaseOrderListQueryModel
    {
        public int? OrderId { get; set; }
        public DateTime? TackOffBeginTime { get; set; }
        public DateTime? TackOffEndTime { get; set; }
        public string OrderStatus { get; set; }
        public SearchCityAportModel AportInfo { get; set; }
        public DateTime? OrderBeginTime { get; set; }
        public DateTime? OrderEndTime { get; set; }
        public string PassengerName { get; set; }
        /// <summary>
        /// 公司所有的客户信息
        /// </summary>
        public List<CustomerModel> CorpCustomerList { get; set; }
        /// <summary>
        /// 是否国际
        /// </summary>
        public bool IsInter { get; set; }

        /// <summary>
        /// 是否是导出操作
        /// </summary>
        public int? IsExport { get; set; }

    }
}
