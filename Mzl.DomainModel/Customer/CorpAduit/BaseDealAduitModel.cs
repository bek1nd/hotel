using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mzl.Common.EnumHelper.CorpAduit;

namespace Mzl.DomainModel.Customer.CorpAduit
{
    public class BaseDealAduitModel
    {
        /// <summary>
        /// 操作人客户Id
        /// </summary>
        public int DealCid { get; set; }
        /// <summary>
        /// 操作人Id TC端
        /// </summary>
        public string DealOid { get; set; }

        /// <summary>
        /// 审批单Id
        /// </summary>
        public int AduitOrderId { get; set; }
        public string DealSource { get; set; }

        public bool IsAgree { get; set; }
        public string AduitReason { get; set; }
        public int CurrentFlow { get; set; }

    }
}
