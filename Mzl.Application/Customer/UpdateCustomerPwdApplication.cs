using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mzl.DomainModel.Customer.Base;
using Mzl.Framework.Base;
using Mzl.IApplication.Customer;
using Mzl.IBLL.Customer.Customer;
using Mzl.UIModel.Customer.Customer;

namespace Mzl.Application.Customer
{
    public class UpdateCustomerPwdApplication : BaseApplicationService, IUpdateCustomerPwdApplication
    {
        private readonly IUpdateCustomerPwdServiceBll _updateCustomerPwdServiceBll;

        public UpdateCustomerPwdApplication(IUpdateCustomerPwdServiceBll updateCustomerPwdServiceBll)
        {
            _updateCustomerPwdServiceBll = updateCustomerPwdServiceBll;
        }

        public  bool UpdateMojoryCustomerPwd(UpdateCustomerPwdRequestViewModel request)
        {
            return _updateCustomerPwdServiceBll.UpdateCustomerPwd(new UpdateCustomerPwdModel()
            {
                Cid= request.Cid,
                AfterUpdatePwd = request.AfterUpdatePwd,
                OriginalPwd = request.OriginalPwd
            });
        }
    }
}
