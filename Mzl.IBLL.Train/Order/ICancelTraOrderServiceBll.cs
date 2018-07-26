using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mzl.DomainModel.Base;
using Mzl.DomainModel.Train.Order;
using Mzl.Framework.Base;

namespace Mzl.IBLL.Train.Order
{
    public interface ICancelTraOrderServiceBll : IBaseServiceBll
    {
        UpdateResultBaseModel<int> CancelTraOrder(CancelTraOrderModel cancelTraOrderModel);
    }
}
