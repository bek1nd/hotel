using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mzl.Framework.UnitOfWork;

namespace Mzl.Framework.Base
{
    public class BaseBll
    {
        /// <summary>
        /// EF上下文
        /// </summary>
        protected DbContext Context { get; private set; }
        protected BaseBll()
        {
            this.Context = DbContextFactory.CreateDbContext();
        }
    }
}
