using Mzl.EntityModel.Register;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mzl.IDAL.Register
{
    public interface IRegisterCustomer
    {
        int Inster(RegisterCustomerEntity entity);
    }
}
