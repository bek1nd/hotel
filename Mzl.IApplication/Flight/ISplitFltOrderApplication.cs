using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mzl.Framework.Base;
using Mzl.UIModel.Flight.SplitOrder;

namespace Mzl.IApplication.Flight
{
    public interface ISplitFltOrderApplication : IBaseApplication
    {
        SplitFltOrderResponseViewModel SplitFltOrder(SplitFltOrderRequestViewModel request);
    }
}
