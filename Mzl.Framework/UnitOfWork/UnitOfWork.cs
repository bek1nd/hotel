using System;
using System.Data.Entity;
using System.Transactions;

namespace Mzl.Framework.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private DbContextTransaction _trans = null;
        public UnitOfWork(DbContext context)
        {
            _trans = context.Database.BeginTransaction();
        }

        public void Commit()
        {
            _trans?.Commit();
        }

        public void RollBack()
        {
            _trans?.Rollback();
        }


        public void Dispose()
        {
            _trans?.Dispose();
        }
    }
}
