using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mzl.DomainModel.Common.TravelManage;
using Mzl.Framework.Base;

namespace Mzl.IBLL.Common.TravelManage
{
    public interface IGetTravelServiceBll : IBaseServiceBll
    {
        TravelModel GetTravelList(TravelQueryModel query);
    }
}
