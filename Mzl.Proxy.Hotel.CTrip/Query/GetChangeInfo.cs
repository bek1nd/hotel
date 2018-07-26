using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mzl.Common.JsonHelper;
using Mzl.EntityModel.Proxy.CTripHotel.ChangeInfo;

namespace Mzl.Proxy.Hotel.CTrip.Query
{
    public class GetChangeInfo : IGetChangeInfo
    {
        public ChangeInfoResEntity Query(ChangeInfoReqEntity req)
        {
            return JsonHelper.DeserializeJsonToObject<ChangeInfoResEntity>(HotelApiAccess.Query<ChangeInfoReqEntity>(req, "ChangeInfo"));
        }

        public string QueryStr(ChangeInfoReqEntity req)
        {
            return HotelApiAccess.Query(req, "ChangeInfo");
        }
    }
}
