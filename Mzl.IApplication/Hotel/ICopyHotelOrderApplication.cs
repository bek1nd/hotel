using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mzl.Framework.Base;
using Mzl.UIModel.Hotel.CopyOrder;

namespace Mzl.IApplication.Hotel
{
    public interface ICopyHotelOrderApplication : IBaseApplication
    {
        CopyHotelOrderResponseViewModel CopHotelOrder(CopyHotelOrderRequestViewModel request);
    }
}
