using Mzl.BLL.Customer.SendAppMessage;
using Mzl.DAL.Customer.Customer;
using Mzl.IBLL.Customer.Customer;
using Mzl.IDAL.Customer.Customer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mzl.IDAL.Customer.Corporation;
using Mzl.DAL.Customer.Corporation;

namespace Mzl.BLL.Customer.Customer.Factory
{
    public class CustomerFactory
    {
        public static IAddAppClientIdServiceBll CreateObj()
        {
            ICustomerAppClientIdDal customerAppClientIdDal = new CustomerAppClientIdDal();
            return new AddAppClientIdServiceBll(customerAppClientIdDal);
        }

        public static IAddSendAppMessageServiceBll CreateSendAppMessageObj()
        {
            ISendAppMessageDal sendAppMessageDal = new SendAppMessageDal();
            ICustomerDal customerDal=new CustomerDal();
            ICorporationDal corporationDal=new CorporationDal();
            IAddSendAppMessageBll addSendAppMessageBll = new AddSendAppMessageBll(sendAppMessageDal, customerDal,
                corporationDal);
            return new AddSendAppMessageServiceBll(addSendAppMessageBll);
        }
    }
}
