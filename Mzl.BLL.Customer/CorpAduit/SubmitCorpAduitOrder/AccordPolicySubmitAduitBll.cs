using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mzl.Common.EnumHelper;
using Mzl.DomainModel.Customer.CorpAduit;

namespace Mzl.BLL.Customer.CorpAduit.SubmitCorpAduitOrder
{
    /// <summary>
    /// 符合差旅政策送审
    /// </summary>
    [Obsolete("已废弃")]
    public class AccordPolicySubmitAduitBll : BaseSubmitAduiBll
    {
        public AccordPolicySubmitAduitBll(SubmitCorpAduitOrderModel submitInfo) : base(submitInfo)
        {
        }
        public override bool DoSubmit(ISubmitAduitVisitor submitAduitVisitor)
        {
            return submitAduitVisitor.DoSubmit(this);
        }


        
    }
}
