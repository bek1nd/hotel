using Mzl.Framework.UnitOfWork;
using System.Data.Entity;

namespace Mzl.Framework.Base
{
    /// <summary>
    /// 基础服务类
    /// </summary>
    public abstract class BaseServiceBll
    {
        /// <summary>
        /// EF上下文
        /// </summary>
        protected DbContext Context { get; private set; }
        protected BaseServiceBll()
        {
            this.Context = DbContextFactory.CreateDbContext();
        }

    }
}
