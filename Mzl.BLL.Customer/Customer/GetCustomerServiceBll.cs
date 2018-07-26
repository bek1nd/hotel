using Mzl.Framework.Base;
using Mzl.IBLL.Customer.Customer;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mzl.DomainModel.Customer.Base;
using Mzl.IDAL.Customer.Customer;
using Mzl.EntityModel.Customer.BaseInfo;
using AutoMapper;
using Mzl.IDAL.Customer.Corporation;

namespace Mzl.BLL.Customer.Customer
{
    public class GetCustomerServiceBll : BaseServiceBll, IGetCustomerServiceBll
    {
        private readonly IGetCustomerBll _customerBll;
      
        public GetCustomerServiceBll(IGetCustomerBll customerBll) : base()
        {
            _customerBll = customerBll;
        }

        public CustomerModel GetCustomerByCid(int cid)
        {
            return _customerBll.GetCustomerByCid(cid);
        }

        public List<CustomerModel> GetCustomerByCidList(List<int> cidList)
        {
            return _customerBll.GetCustomerByCidList(cidList);
        }

        public List<CustomerModel> GetCustomerByCorpId(string corpId)
        {
            return _customerBll.GetCustomerByCorpId(corpId);
        }
    }
}
