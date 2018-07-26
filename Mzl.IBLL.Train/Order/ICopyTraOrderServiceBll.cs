using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mzl.DomainModel.Train.Order.CopyOrder;
using Mzl.Framework.Base;

namespace Mzl.IBLL.Train.Order
{
    public interface ICopyTraOrderServiceBll : IBaseServiceBll
    {
        int CopyOrder(CopyTraOrderModel copyTraOrderModel);
    }
}
