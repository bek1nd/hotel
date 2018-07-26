using System.Data.Entity;
using Mzl.Framework.UnitOfWork;

namespace Mzl.Framework.Base
{
    public abstract class BaseApplicationService
    {
        /// <summary>
        /// EF上下文
        /// </summary>
        protected DbContext Context { get; private set; }
        protected BaseApplicationService()
        {
            this.Context = DbContextFactory.CreateDbContext();
        }
    }
}
