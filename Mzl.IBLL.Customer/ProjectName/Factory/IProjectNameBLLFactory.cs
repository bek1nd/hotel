using Mzl.Common.Factory;
using Mzl.DomainModel.Customer.ProjectName;
using Mzl.IBLL.Customer.ProjectName.BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mzl.IBLL.Customer.ProjectName.Factory
{
    public interface IProjectNameBLLFactory : IBaseBLLFactory<IProjectNameBLL<ProjectNameModel>>
    {
    }
}
