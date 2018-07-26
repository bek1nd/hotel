using Mzl.EntityModel.Proxy.CTripHotel.ChangeInfo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mzl.Proxy.Hotel.CTrip.Query
{
    public interface IGetChangeInfo
    {
        ChangeInfoResEntity Query(ChangeInfoReqEntity req);
        string QueryStr(ChangeInfoReqEntity req);
    }
}
