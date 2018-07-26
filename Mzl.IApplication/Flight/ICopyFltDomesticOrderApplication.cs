using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mzl.Framework.Base;
using Mzl.UIModel.Flight.CopyOrder;

namespace Mzl.IApplication.Flight
{
    public interface ICopyFltDomesticOrderApplication : IBaseApplication
    {
        CopyFltDomesticOrderResponseViewModel CopyFltDomesticOrder(CopyFltDomesticOrderRequestViewModel request);
    }
}
