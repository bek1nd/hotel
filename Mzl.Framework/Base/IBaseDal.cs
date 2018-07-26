using System;
using System.Data;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Linq;
using System.Linq.Expressions;

namespace Mzl.Framework.Base
{
    public interface IBaseDal : IDisposable
    {
        //DbContext Context { get;  }//
        /// <summary>
        /// 根据id查询实体
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        T Find<T>(int id) where T : class;

        /// <summary>
        /// 查询
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="funcWhere"></param>
        /// <param name="isUseNoTracking">是否启用AsNoTracking，默认不启用，一旦启用获取的实体数据不能用于更新</param>
        /// <returns></returns>
        IQueryable<T> Query<T>(Expression<Func<T, bool>> funcWhere, bool isUseNoTracking = false) where T : class;
        /// <summary>
        /// 新增数据
        /// </summary>
        /// <param name="t"></param>
        /// <returns>返回带主键的实体</returns>
        T Insert<T>(T t) where T : class;

        /// <summary>
        /// 更新数据
        /// </summary>
        /// <param name="t"></param>
        /// <param name="properties"></param>
        void Update<T>(T t, string[] properties = null) where T : class;
        /// <summary>
        /// 根据主键删除数据
        /// </summary>
        /// <param name="id"></param>
        void Delete<T>(int id) where T : class;
        /// <summary>
        /// 立即保存全部修改
        /// </summary>
        void Commit();
    }
}
