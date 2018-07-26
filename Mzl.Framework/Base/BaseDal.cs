using System;
using System.Data;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Linq;
using System.Linq.Expressions;
using Mzl.Framework.UnitOfWork;

namespace Mzl.Framework.Base
{
    public abstract class BaseDal
    {
        #region Identity
        protected DbContext Context { get; private set; }//
        protected BaseDal()
        {
            this.Context = DbContextFactory.CreateDbContext();
        }
        #endregion Identity

        public void Dispose()
        {
            this.Context?.Dispose();
        }

        public T Find<T>(int id) where T : class
        {
            return this.Context.Set<T>().Find(id);
        }
        /// <summary>
        /// 获取数据
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="funcWhere"></param>
        /// <param name="isUseNoTracking">是否启用AsNoTracking</param>
        /// <returns></returns>
        public IQueryable<T> Query<T>(Expression<Func<T, bool>> funcWhere,bool isUseNoTracking=false) where T : class
        {
            if(isUseNoTracking)
                return this.Context.Set<T>().Where(funcWhere).AsNoTracking();
            return this.Context.Set<T>().Where(funcWhere);
        }

        public T Insert<T>(T t) where T : class
        {
            this.Context.Set<T>().Add(t);
            this.Commit();
            return t;
        }

        public void Update<T>(T t, string[] properties = null) where T : class
        {
            if (t == null) throw new Exception("t is null");
            this.Context.Set<T>().Attach(t);
            this.Context.Configuration.ValidateOnSaveEnabled = false;//这里更新的时候关闭实体的检查
            if (properties == null)
            {
                this.Context.Entry<T>(t).State = EntityState.Modified;
            }
            else
            {
                foreach (var item in properties)
                {
                    this.Context.Entry<T>(t).Property(item).IsModified = true;
                }
            }
            this.Commit();
            this.Context.Configuration.ValidateOnSaveEnabled = true;//更新完毕后，打开实体检查
        }

        public void Delete<T>(int id) where T : class
        {
            T t = this.Find<T>(id);
            if (t == null) throw new Exception("t is null");
            this.Context.Set<T>().Remove(t);
            this.Commit();
        }

        public void Commit()
        {
            this.Context.SaveChanges();
        }


        /**
         *  List<SqlParameter> parameters = new List<SqlParameter>()
            {
                new SqlParameter("@parameter1", 1),
                new SqlParameter("@parameter2", Convert.ToInt32(0))
            };
            List<T> ddd =
                _corpAduitOrderDal.ExcuteQueryBySql<T>(
                    @"exec proc_test @parameter1,@parameter2 ",
                    parameters.ToArray()
                    ).ToList();
         * 
         * 
         * **/

        /// <summary>
        /// 执行SQL或存储过程查询
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="sql"></param>
        /// <param name="parameters"></param>
        /// <returns></returns>
        protected IQueryable<T> ExcuteQueryBySql<T>(string sql, params SqlParameter[] parameters) where T : class
        {
            return this.Context.Database.SqlQuery<T>(sql, parameters).AsQueryable();
        }

        /// <summary>
        /// 执行SQL CUD操作
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="sql"></param>
        /// <param name="parameters"></param>
        protected int ExcuteBySql<T>(string sql, params SqlParameter[] parameters) where T : class
        {
            return this.Context.Database.ExecuteSqlCommand(sql, parameters);
        }
        protected int ExcuteScalar(string sql,params SqlParameter[] parameters)
        {
            int count = this.Context.Database.SqlQuery<int>(sql,parameters).SingleOrDefault();
            return count;
        }


    }
}
