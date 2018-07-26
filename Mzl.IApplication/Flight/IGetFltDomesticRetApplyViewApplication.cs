using Mzl.Framework.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mzl.UIModel.Flight;

namespace Mzl.IApplication.Flight
{
    public interface IGetFltDomesticRetApplyViewApplication : IBaseApplication
    {
        GetRetApplyResponseViewModel GetRetApplyView(GetRetApplyRequestViewModel request);
    }
}
