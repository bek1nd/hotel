using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mzl.Framework.Base;
using Mzl.UIModel.Train.Order.CopyOrder;

namespace Mzl.IApplication.Train
{
    public interface ICopyTraOrderApplication : IBaseApplication
    {
        CopyTraOrderResponseViewModel CopyTraOrder(CopyTraOrderRequestViewModel request);
    }
}
