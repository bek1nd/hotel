using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mzl.IApplication.Customer;
using Mzl.IBLL.Token;
using Mzl.Common.ConfigHelper;

namespace Mzl.Application.Customer
{
    public class CustomerLoginOutApplication : ICustomerLoginOutApplication
    {
        private readonly IDeleteTokenServiceBll _deleteTokenServiceBll;

        public CustomerLoginOutApplication(IDeleteTokenServiceBll deleteTokenServiceBll)
        {
            _deleteTokenServiceBll = deleteTokenServiceBll;
        }

        public void MojoryLoginOut(string token)
        {
            if (token == AppSettingsHelper.GetAppSettings(AppSettingsEnum.OAToken))
                return;
            _deleteTokenServiceBll.DeleteToken(token);
        }
    }
}
