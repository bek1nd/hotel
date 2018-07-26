using Mzl.Framework.Base;
using Mzl.UIModel.Flight;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mzl.IApplication.Flight
{
    public interface IGetFltDomesticModApplyViewApplication : IBaseApplication
    {
        GetModApplyResponseViewModel GetFltDomesticModApply(GetModApplyRequestViewModel request);
    }
}
