using Mzl.IBLL.Customer.CorpDepartment.Factory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mzl.DomainModel.Customer.CorpDepartment;
using Mzl.IBLL.Customer.CorpDepartment.BLL;
using Mzl.IDAL.Customer.Factory;
using Mzl.DAL.Customer.Corporation.Factory;
using Mzl.BLL.Customer.CorpDepartment.BLL;

namespace Mzl.BLL.Customer.CorpDepartment.Factory
{
    public class CorpDepartmentBLLFactory : ICorpDepartmentBLLFactory
    {
        public ICorpDepartmentBLL<CorpDepartmentModel> CreateBllObj()
        {
            ICorpDepartmentDALFactory factory = new CorpDepartmentDALFactory();
            return new CorpDepartmentBLL(factory.CreateSampleDalObj());
        }

        public ICorpDepartmentBLL<CorpDepartmentModel> CreateSampleBllObj()
        {
            throw new NotImplementedException();
        }
    }
}
