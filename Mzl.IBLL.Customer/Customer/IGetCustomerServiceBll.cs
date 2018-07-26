using Mzl.DomainModel.Customer.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mzl.IBLL.Customer.Customer
{
    public interface IGetCustomerServiceBll
    {
        /// <summary>
        /// 根据Cid获取客户信息
        /// </summary>
        /// <param name="cid"></param>
        /// <returns></returns>
        CustomerModel GetCustomerByCid(int cid);

        List<CustomerModel> GetCustomerByCidList(List<int> cidList);
        List<CustomerModel> GetCustomerByCorpId(string corpId);
    }
}
