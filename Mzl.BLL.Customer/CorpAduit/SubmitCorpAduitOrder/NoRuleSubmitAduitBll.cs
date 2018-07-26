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
    /// 没有审批规则送审
    /// </summary>
    public class NoRuleSubmitAduitBll : BaseSubmitAduiBll
    {
        public NoRuleSubmitAduitBll(SubmitCorpAduitOrderModel submitInfo) : base(submitInfo)
        {
        }
        public override bool DoSubmit(ISubmitAduitVisitor submitAduitVisitor)
        {
            return submitAduitVisitor.DoSubmit(this);
        }


      
    }
}
