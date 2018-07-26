using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mzl.Common.EnumHelper;
using Mzl.DomainModel.Customer.CorpAduit;

namespace Mzl.BLL.Customer.CorpAduit.SubmitCorpAduitOrder
{
    public abstract class BaseSubmitAduiBll
    {
        public SubmitCorpAduitOrderModel SubmitInfo { get; private set; }
        protected BaseSubmitAduiBll(SubmitCorpAduitOrderModel submitInfo)
        {
            SubmitInfo = submitInfo;
        }

        public abstract bool DoSubmit(ISubmitAduitVisitor submitAduitVisitor);
    }
}
