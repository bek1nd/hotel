using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mzl.Framework.Base;
using Mzl.UIModel.Common.TravelManage;

namespace Mzl.IApplication.Common
{
    public interface IGetTravelListApplication : IBaseApplication
    {
        TravelResponseViewModel GetTravel(TravelRequestViewModel request);
    }
}
