using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mzl.Common.EnumHelper;
using Mzl.DomainModel.Customer.Login;
using Mzl.Framework.Base;
using Mzl.IApplication.Customer;
using Mzl.IBLL.Customer.Customer;
using Mzl.UIModel.Customer.Login;

namespace Mzl.Application.Customer
{
    public class CustomerLoginApplication : BaseApplicationService, ICustomerLoginApplication
    {
        private readonly IAddAppClientIdServiceBll _addAppClientIdServiceBll;

        public CustomerLoginApplication(IAddAppClientIdServiceBll addAppClientIdServiceBll)
        {
            _addAppClientIdServiceBll = addAppClientIdServiceBll;
        }

        public LoginResponseViewModel MojoryLogin(LoginRequestViewModel request)
        {
            throw new NotImplementedException();
        }

        public int AddAppClientId(int cid, string clientId, string clientType)
        {
            return _addAppClientIdServiceBll.AddAppClientId(new AddAppClientIdModel()
            {
                Cid = cid,
                ClientId = clientId,
                ClientType = clientType
            });
        }
    }
}
