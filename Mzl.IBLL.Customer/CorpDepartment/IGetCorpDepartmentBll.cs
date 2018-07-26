using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mzl.DomainModel.Customer.CorpDepartment;
using Mzl.Framework.Base;

namespace Mzl.IBLL.Customer.CorpDepartment
{
    public interface IGetCorpDepartmentBll 
    {
        List<CorpDepartmentModel> GetCorpDepartmentByCorpId(string corpId);
    }
}
