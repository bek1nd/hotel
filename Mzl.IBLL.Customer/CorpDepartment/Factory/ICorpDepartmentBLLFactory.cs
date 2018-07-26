using Mzl.Common.Factory;
using Mzl.DomainModel.Customer.CorpDepartment;
using Mzl.IBLL.Customer.CorpDepartment.BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mzl.IBLL.Customer.CorpDepartment.Factory
{
    public interface ICorpDepartmentBLLFactory : IBaseBLLFactory<ICorpDepartmentBLL<CorpDepartmentModel>>
    {
    }
}
