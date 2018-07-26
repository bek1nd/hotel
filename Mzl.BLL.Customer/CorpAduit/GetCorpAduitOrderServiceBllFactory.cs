using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mzl.BLL.Customer.Customer;
using Mzl.IBLL.Customer.CorpAduit;
using Mzl.DAL.Customer.Corporation;
using Mzl.DAL.Customer.Customer;
using Mzl.Framework.Base;
using Mzl.IBLL.Customer.Customer;
using Mzl.IDAL.Customer.Corporation;
using Mzl.IDAL.Customer.Customer;

namespace Mzl.BLL.Customer.CorpAduit
{
    public class GetCorpAduitOrderServiceBllFactory: BaseServiceBll
    {
        public IGetCorpAduitOrderServiceBll CreateObj()
        {
            ICorpAduitOrderDal corpAduitOrderDal = new CorpAduitOrderDal();
            ICorpAduitOrderDetailDal corpAduitOrderDetailDal= new CorpAduitOrderDetailDal();
            ICorpAduitOrderFlowDal corpAduitOrderFlowDal=new CorpAduitOrderFlowDal();
            ICorpAduitOrderLogDal corpAduitOrderLogDal = new CorpAduitOrderLogDal();
            ICustomerDal customerDal = new CustomerDal();
            ICustomerUnionDal customerUnionDal = new CustomerUnionDal();
            ICorpDepartmentDal corpDepartmentDal = new CorpDepartmentDal();
            ICorporationDal corporationDal = new CorporationDal();
            IGetCustomerBll getCustomerBll = new GetCustomerBll(customerDal, customerUnionDal, corpDepartmentDal,
                corporationDal);
            return new GetCorpAduitOrderServiceBll(corpAduitOrderDal, 
                corpAduitOrderFlowDal, 
                corpAduitOrderLogDal,
                corpAduitOrderDetailDal,
                getCustomerBll);
        }
    }
}
