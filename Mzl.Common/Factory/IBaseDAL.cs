using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mzl.Common.Factory
{
    public interface IBaseDAL<T> where T : class
    {
        /// <summary>
        /// 增
        /// </summary>
        /// <param name="t"></param>
        /// <returns></returns>
        int Insert(T t);

        /// <summary>
        /// 改
        /// </summary>
        /// <param name="t"></param>
        /// <param name="properties">需要更新的字段，默认为全部更新</param>
        /// <returns></returns>
        int Update(T t, string[] properties = null);
        /// <summary>
        /// 删
        /// </summary>
        /// <param name="t"></param>
        /// <returns></returns>
        int Delete(T t);
        /// <summary>
        /// 查
        /// </summary>
        /// <returns></returns>
        T Query(int id);


    }
}
