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
    /// <summary>
    /// 全部临时客人
    /// </summary>
    public class AllTemporaryBll: BaseMatchBll
    {

        public CustomerModel  BookingCustomerModel { get;private set; }

        public AllTemporaryBll(List<int> cidList, List<CustomerModel> customerList, CustomerModel bookingCustomerModel,
            int isAllowUserInsurance)
            : base(cidList, customerList, isAllowUserInsurance)
        {
            BookingCustomerModel = bookingCustomerModel;
        }

        public override MatchCorpPolicyAndAduitResultModel DoMatch(IMatchVisitor macthVisitor)
        {
            return macthVisitor.DoMatch(this);
        }

      
    }
}
