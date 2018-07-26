using Mzl.DomainModel.Common.Insurance;
using Mzl.DomainModel.Customer.Base;
using Mzl.DomainModel.Customer.ProjectName;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mzl.DomainModel.Flight
{
    public class QueryFlightOrderQueryModel
    {
        public int OrderId { get; set; }
        public int? Cid { get; set; }
        public string UserId { get; set; }
        public string CorpId { get; set; }
        public SearchCityAportModel AportInfo { get; set; }
        public List<InsuranceCompanyModel> InsuranceCompany { get; set; }
        public List<ProjectNameModel> ProjectName { get; set; }
        public CustomerModel Customer { get; set; }
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
        /// <summary>
        /// 是否审批人查询
        /// </summary>
        public bool IsFromAduitQuery { get; set; }
    }
}
