using Mzl.EntityModel.Hotel.Elong;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mzl.Proxy.Hotel.Elong.Query
{
    public class HotelDetail : IHotelDetail
    {
        public HotelListResponseEntity Query(HotelDetailRequestEntity request)
        {
            var result = HotelApiAccess.Query<HotelDetailRequestEntity, HotelListResponseEntity>(request, "hotel.detail").Result;

            //#region 担保过滤
            //if (result.Hotels == null || (!result.Hotels.Any()))
            //{
            //    return result;
            //}
            //if (result.Hotels[0].Rooms == null || (!result.Hotels[0].Rooms.Any()))
            //{
            //    return result;
            //}
            //foreach (var room in result.Hotels[0].Rooms) 
            //{
            //    if (room.RatePlans != null && room.RatePlans.Any())
            //    {
            //        room.RatePlans = room.RatePlans.Where(a => string.IsNullOrWhiteSpace(a.GuaranteeRuleIds)).ToArray();
            //    }
            //}
            //#endregion
            return result;
        }

        public string QueryStr(HotelDetailRequestEntity request)
        {
            return HotelApiAccess.Query(request, "hotel.detail");
        }
    }
}
