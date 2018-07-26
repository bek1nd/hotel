using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mzl.Framework.Base;
using Mzl.UIModel.Train.Order.CopyOrder;
using Mzl.UIModel.Flight.SplitOrder;

namespace Mzl.IApplication.Train
{
    public interface ISplitTraOrderApplication : IBaseApplication
    {
        SplitTraOrderResponseViewModel SplitTraOrder(SplitTraOrderRequestViewModel request,out string Message);
    }
}
