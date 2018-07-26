using Mzl.EntityModel.Hotel.Elong;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mzl.Proxy.Hotel.Elong.StaticData
{
    public class CreditCardService : ICreditCardService
    {
        public CreditCardsResponseEntity GetAll()
        {
            return HotelApiAccess.GetStatic<CreditCardsResponseEntity>(string.Format("{0}xml/v2.0/hotel/creditcards.xml", Configuraton.ApiGatewayConfig.URL_STATIC));
        }
    }
}
