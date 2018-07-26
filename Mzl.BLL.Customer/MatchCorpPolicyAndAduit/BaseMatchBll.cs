using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mzl.DomainModel.Customer.Base;
using Mzl.DomainModel.Customer.CorpPolicy;
using Mzl.DomainModel.Customer.MatchCorpPolicyAndAduit;

namespace Mzl.BLL.Customer.MatchCorpPolicyAndAduit
{
    public abstract class BaseMatchBll
    {
        public List<int> CidList { get; private set; }
        public List<CustomerModel> CustomerList { get; private set; }
        public int IsAllowUserInsurance { get; private set; }

        protected BaseMatchBll(List<int> cidList, List<CustomerModel> customerList, int isAllowUserInsurance)
        {
            CidList = cidList;
            CustomerList = customerList;
            IsAllowUserInsurance = isAllowUserInsurance;
        }

        public abstract MatchCorpPolicyAndAduitResultModel DoMatch(IMatchVisitor macthVisitor);
    }
}
