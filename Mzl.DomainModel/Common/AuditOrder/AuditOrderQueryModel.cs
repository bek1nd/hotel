using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mzl.Common.EnumHelper;
using Mzl.DomainModel.Customer.Base;

namespace Mzl.DomainModel.Common.AuditOrder
{
    public abstract class AuditOrderQueryModel
    {
        public int Id { get; set; }
        public int Cid { get; set; }
        public CustomerModel AuditCustomer { get; set; }
        /// <summary>
        /// 是否通过审批
        /// </summary>
        public bool IsAgree { get; set; }
        /// <summary>
        /// 审批阶段
        /// </summary>
        public string AuditStep { get; set; }
    }
}
