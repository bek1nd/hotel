using Mzl.DomainModel.Register;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mzl.IBLL.Register
{
    public interface IRegisterCustomer
    {
        bool Add(RegisterCustomerModel model);
    }
}
