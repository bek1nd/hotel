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
    /// 违反差旅政策送审
    /// </summary>
    [Obsolete("已废弃")]
    public class ViolatePolicySubmitAduitBll : BaseSubmitAduiBll
    {
        public ViolatePolicySubmitAduitBll(SubmitCorpAduitOrderModel submitInfo) : base(submitInfo)
        {
        }
        public override bool DoSubmit(ISubmitAduitVisitor submitAduitVisitor)
        {
            return submitAduitVisitor.DoSubmit(this);
        }


       
    }
}
