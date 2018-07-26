using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mzl.Framework.Base;

namespace Mzl.IBLL.Customer.CorpAduit
{
    public interface ICopyAduitOrderServiceBll : IBaseServiceBll
    {
        int Copy(int copyFromOrderId,int newOrderId);
    }
}
