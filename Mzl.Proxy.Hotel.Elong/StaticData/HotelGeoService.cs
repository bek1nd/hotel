using Mzl.EntityModel.Hotel.Elong;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mzl.Proxy.Hotel.Elong.StaticData
{
    public class HotelGeoService : IHotelGeoService
    {
        public HotelGeosResponseEntity GetAll()
        {
            return HotelApiAccess.GetStatic<HotelGeosResponseEntity>(string.Format("{0}xml/v2.0/hotel/geo_cn.xml", Configuraton.ApiGatewayConfig.URL_STATIC));
        }
    }
}
