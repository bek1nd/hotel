using System;

namespace Mzl.Framework.UnitOfWork
{
    public interface IUnitOfWork : IDisposable
    {
        /// <summary>
        /// 提交事务
        /// </summary>
        void Commit();

        void RollBack();
    }
}
