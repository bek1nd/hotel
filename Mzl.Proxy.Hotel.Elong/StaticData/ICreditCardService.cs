using Mzl.EntityModel.Hotel.Elong;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mzl.Proxy.Hotel.Elong.StaticData
{
    public interface ICreditCardService
    {
        CreditCardsResponseEntity GetAll();
    }
}
