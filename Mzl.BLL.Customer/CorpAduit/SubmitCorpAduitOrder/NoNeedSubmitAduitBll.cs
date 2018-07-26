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
    /// 当前审批规则为无需审批的送审
    /// </summary>
    public class NoNeedSubmitAduitBll : BaseSubmitAduiBll
    {

        public NoNeedSubmitAduitBll(SubmitCorpAduitOrderModel submitInfo) : base(submitInfo)
        {
        }
        public override bool DoSubmit(ISubmitAduitVisitor submitAduitVisitor)
        {
            return submitAduitVisitor.DoSubmit(this);
        }

      
    }
}
