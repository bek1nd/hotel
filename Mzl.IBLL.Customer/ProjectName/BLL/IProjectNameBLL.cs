using System.Collections.Generic;

namespace Mzl.IBLL.Customer.ProjectName.BLL
{
    public interface IProjectNameBLL<T> where T : class
    {
        /// <summary>
        /// 根据公司Id获取对应的项目信息
        /// </summary>
        /// <param name="corpId"></param>
        /// <returns></returns>
        List<T> GetProjectNameByCorpId(string corpId);
        /// <summary>
        /// 根据Id获取项目名称
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        T GetProjectNameById(int id);
        /// <summary>
        /// 根据Id获取项目名称
        /// </summary>
        /// <param name="ids"></param>
        /// <returns></returns>
        List<T> GetProjectNameByIds(List<int> ids);
    }
}
