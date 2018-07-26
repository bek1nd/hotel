using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mzl.Framework.Base;
using Mzl.UIModel.Flight;

namespace Mzl.IApplication.Flight
{
    public interface IAddFltDomesticRetApplyApplication : IBaseApplication
    {
        AddRetApplyResponseViewModel AddRetApply(AddRetApplyRequestViewModel request);
    }
}
