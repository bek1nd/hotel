using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mzl.DomainModel.Hotel.CopyOrder;
using Mzl.Framework.Base;

namespace Mzl.IBll.Hotel.CopyOrder
{
    public interface ICopyHotelOrderServiceBll : IBaseServiceBll
    {
        int CopyOrder(CopyHotelOrderModel copyHotelOrderModel);
    }
}
