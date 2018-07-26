using Mzl.Framework.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mzl.DomainModel.Flight;

namespace Mzl.IBLL.Flight
{
    public interface IQueryFlightOrderServiceBll : IBaseServiceBll
    {
        QueryFlightOrderDataModel QueryFlightOrder(QueryFlightOrderQueryModel query);
    }
}
