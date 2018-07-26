using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mzl.DomainModel.Customer.Base;

namespace Mzl.DomainModel.Train.Order.OrderDetail
{
    public class GetTraOrderDetailInfoQueryModel
    {
        public int OrderId { get; set; }
        public int Cid { get; set; }
        public bool IsFromAduitQuery { get; set; }
        public CustomerModel Customer { get; set; }
        /// <summary>
        /// 公司所有的客户信息
        /// </summary>
        public List<CustomerModel> CorpCustomerList { get; set; }
        public List<int> CidList
        {
            get
            {
                if (CorpCustomerList == null || CorpCustomerList.Count == 0)
                    return null;
                return CorpCustomerList.Select(n => n.Cid).ToList();
            }
        }
    }
}
