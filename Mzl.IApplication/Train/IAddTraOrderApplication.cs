using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mzl.Framework.Base;
using Mzl.UIModel.Train.Order;

namespace Mzl.IApplication.Train
{
    public interface IAddTraOrderApplication : IBaseApplication
    {
        AddTraOrderResponseViewModel AddTraOrder(AddTraOrderRequestViewModel request);
    }
}
