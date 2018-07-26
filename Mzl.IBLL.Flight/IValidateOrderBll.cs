using Mzl.DomainModel.Flight;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mzl.IBLL.Flight
{
    public interface IValidateOrderBll
    {
        AddOrderModel Validate(AddOrderModel fltAddOrderModel);
    }
}
