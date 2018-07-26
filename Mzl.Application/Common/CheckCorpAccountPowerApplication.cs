using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mzl.DomainModel.Customer.Base;
using Mzl.Framework.Base;
using Mzl.IApplication.Common;
using Mzl.IBLL.Common.CheckAccount;
using Mzl.IBLL.Customer.Customer;
using Mzl.UIModel.Common.CheckAccount;

namespace Mzl.Application.Common
{
    internal class CheckCorpAccountPowerApplication : BaseApplicationService, ICheckCorpAccountPowerApplication
    {
        private readonly ICheckCorpAccountPowerServiceBll _checkCorpAccountPowerServiceBll;
        private readonly IGetCustomerServiceBll _getCustomerServiceBll;

        public CheckCorpAccountPowerApplication(ICheckCorpAccountPowerServiceBll checkCorpAccountPowerServiceBll,
            IGetCustomerServiceBll getCustomerServiceBll)
        {
            _checkCorpAccountPowerServiceBll = checkCorpAccountPowerServiceBll;
            _getCustomerServiceBll = getCustomerServiceBll;
        }

        public CheckCorpAccountPowerResponseViewModel CheckCorpAccountPower(
            CheckCorpAccountPowerRequestViewModel request)
        {

            CustomerModel customer = _getCustomerServiceBll.GetCustomerByCid(request.Cid);

            bool isHasPower = _checkCorpAccountPowerServiceBll.CheckAccountPower(customer, request.Url);


            return new CheckCorpAccountPowerResponseViewModel() {IsHasPower = isHasPower};
        }
    }
}
