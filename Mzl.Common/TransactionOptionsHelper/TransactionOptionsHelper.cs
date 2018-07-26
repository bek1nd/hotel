using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace Mzl.Common.TransactionOptionsHelper
{
    public static class TransactionOptionsHelper
    {
        public static TransactionOptions GetTransactionScope(this TransactionOptions obj)
        {
            return new TransactionOptions {IsolationLevel = IsolationLevel.ReadCommitted};
        }
    }
}
