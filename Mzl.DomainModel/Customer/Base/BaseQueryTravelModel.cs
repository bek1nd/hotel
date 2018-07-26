using Mzl.DomainModel.Customer.CorpDepartment;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mzl.DomainModel.Customer.Base
{
    public class BaseQueryTravelModel
    {
        /// <summary>
        /// T是预订员 F非预订员
        /// </summary>
        public string IsMaster { get; set; }
        /// <summary>
        /// 差旅系统客户：T 是，F不是
        /// </summary>
        public string IsCorpSystemCustomer { get; set; }
        /// <summary>
        /// 部门信息
        /// </summary>
        public List<CorpDepartmentModel> DepartmentList { get; set; }
    }
}
