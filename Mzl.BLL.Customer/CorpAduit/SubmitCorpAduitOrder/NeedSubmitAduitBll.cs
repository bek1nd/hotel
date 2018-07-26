using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mzl.DomainModel.Customer.CorpAduit;

namespace Mzl.BLL.Customer.CorpAduit.SubmitCorpAduitOrder
{
    public class NeedSubmitAduitBll : BaseSubmitAduiBll
    {
        public NeedSubmitAduitBll(SubmitCorpAduitOrderModel submitInfo) : base(submitInfo)
        {
        }

        public override bool DoSubmit(ISubmitAduitVisitor submitAduitVisitor)
        {
            return submitAduitVisitor.DoSubmit(this);
        }
    }
}
