using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Mzl.DomainModel.Customer.Base;
using Mzl.DomainModel.Customer.MatchCorpPolicyAndAduit;
using Mzl.Framework.Base;
using Mzl.IApplication.Customer;
using Mzl.IBLL.Customer.Customer;
using Mzl.IBLL.Customer.MatchCorpPolicyAndAduit;
using Mzl.UIModel.Customer.MatchCorpPolicyAndAduit;

namespace Mzl.Application.Customer
{
    public class MatchCorpPolicyAndAduitApplication: BaseApplicationService,IMatchCorpPolicyAndAduitApplication
    {
        private readonly IMatchCorpPolicyAndAduitServiceBll _mathCorpPolicyAndAduitServiceBll;
        private readonly IGetCustomerServiceBll _getCustomerServiceBll;


        public MatchCorpPolicyAndAduitApplication(IMatchCorpPolicyAndAduitServiceBll mathCorpPolicyAndAduitServiceBll, IGetCustomerServiceBll getCustomerServiceBll)
        {
            _mathCorpPolicyAndAduitServiceBll = mathCorpPolicyAndAduitServiceBll;
            _getCustomerServiceBll = getCustomerServiceBll;
        }

        public MatchCorpPolicyAndAduitResponseViewModel Match(MatchCorpPolicyAndAduitRequestViewModel request)
        {
            CustomerModel  customerModel= _getCustomerServiceBll.GetCustomerByCid(request.Cid);

            MatchCorpPolicyAndAduitResultModel matchCorpPolicyAndAduitResultModel =
                _mathCorpPolicyAndAduitServiceBll.Match(new MatchCorpPolicyAndAduitModel()
                {
                    PassengerCidList = request.PassengerCidList,
                    BookingCid = request.Cid,
                    IsAllowUserInsurance = (customerModel?.Corporation?.IsAllowUserInsurance ?? 0)
                });

            return
                Mapper.Map<MatchCorpPolicyAndAduitResultModel, MatchCorpPolicyAndAduitResponseViewModel>(
                    matchCorpPolicyAndAduitResultModel);
        }
    }
}
