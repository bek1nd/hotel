using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mzl.IBLL.Customer.CorpDepartment.BLL
{
    public interface ICorpDepartmentBLL<T> where T : class
    {
        /// <summary>
        /// 根据Id获取部门信息
        /// </summary>
        /// <param name="ids"></param>
        /// <returns></returns>
        List<T> GetCorpDepartmentByIds(List<int> ids);
        /// <summary>
        /// 根据公司Id获取部门信息
        /// </summary>
        /// <param name="corpId"></param>
        /// <returns></returns>
        List<T> GetCorpDepartmentByCorpId(string corpId);
    }
}
