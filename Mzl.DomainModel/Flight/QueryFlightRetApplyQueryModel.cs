using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mzl.DomainModel.Base;
using Mzl.DomainModel.Customer.Base;
using Mzl.DomainModel.Customer.CorpPolicy;

namespace Mzl.DomainModel.Flight
{
    public class QueryFlightRetApplyQueryModel : BaseOrderListQueryModel
    {
        public int Rmid { get; set; }
        public SearchCityAportModel AportInfo { get; set; }
        /// <summary>
        /// 违反差旅政策原因
        /// </summary>
        public List<ChoiceReasonModel> PolicyReasonList { get; set; }

        /// <summary>
        /// 公司所有的客户信息
        /// </summary>
        public List<CustomerModel> CorpCustomerList { get; set; }
        /// <summary>
        /// 公司所属客户id
        /// </summary>
        public List<int> CidList => CorpCustomerList?.Select(n => n.Cid).ToList();
        /// <summary>
        /// 是否审批人查询
        /// </summary>
        public bool IsFromAduitQuery { get; set; }
    }
}
