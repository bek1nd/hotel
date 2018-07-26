using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mzl.DomainModel.Common.Account;
using Mzl.DomainModel.Events;

namespace Mzl.IApplication.Account.Domain
{
    /// <summary>
    /// 账户业务接口
    /// </summary>
    public interface IAccountDomain
    {
        /// <summary>
        /// 付供应商记录
        /// </summary>
        void Pay(AccountDetailModel account);
        /// <summary>
        /// 收客户记录
        /// </summary>
        void Collect(AccountDetailModel account);
        /// <summary>
        /// 付供应商记录事件
        /// </summary>
        /// <param name="o"></param>
        /// <param name="e"></param>
        void DoPaySupplierEvent(object o, CommonEventArgs<AccountDetailModel> e);
        /// <summary>
        /// 收供应商记录事件
        /// </summary>
        /// <param name="o"></param>
        /// <param name="e"></param>
        void DoCollectSupplierEvent(object o, CommonEventArgs<AccountDetailModel> e);
    }
}
