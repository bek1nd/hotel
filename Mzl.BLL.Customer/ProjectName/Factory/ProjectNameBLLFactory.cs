using Mzl.IBLL.Customer.ProjectName.Factory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mzl.DomainModel.Customer.ProjectName;
using Mzl.IBLL.Customer.ProjectName.BLL;
using Mzl.IDAL.Customer.Factory;
using Mzl.DAL.Customer.Corporation.Factory;
using Mzl.BLL.Customer.ProjectName.BLL;

namespace Mzl.BLL.Customer.ProjectName.Factory
{
    public class ProjectNameBLLFactory : IProjectNameBLLFactory
    {
        public IProjectNameBLL<ProjectNameModel> CreateBllObj()
        {
            IProjectNameDALFactory factory = new ProjectNameDALFactory();
            return new ProjectNameBLL(factory.CreateSampleDalObj());
        }

        public IProjectNameBLL<ProjectNameModel> CreateSampleBllObj()
        {
            throw new NotImplementedException();
        }
    }
}
