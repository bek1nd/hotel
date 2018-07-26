using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mzl.DomainModel.Base;
using Mzl.DomainModel.Customer.Base;

namespace Mzl.DomainModel.Flight
{
    public class GetNotUseTicketNoQueryModel : BaseOrderListQueryModel
    {
        public int? OrderId { get; set; }
        public DateTime? TackOffBeginTime { get; set; }
        public DateTime? TackOffEndTime { get; set; }
        public int? OrderStatus { get; set; }
        public SearchCityAportModel AportInfo { get; set; }
        public string PassengerName { get; set; }
        public DateTime? OrderBeginTime { get; set; }
        public DateTime? OrderEndTime { get; set; }

        /// <summary>
        /// 公司所有的客户信息
        /// </summary>
        public List<CustomerModel> CorpCustomerList { get; set; }

        public List<int> CidList
        {
            get
            {
                if (CorpCustomerList == null || CorpCustomerList.Count == 0)
                    return null;
                return CorpCustomerList.Select(n => n.Cid).ToList();
            }
        }
    }
}
