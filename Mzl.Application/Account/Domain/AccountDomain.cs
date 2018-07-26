using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;
using Mzl.Common.TransactionOptionsHelper;
using Mzl.DomainModel.Common.Account;
using Mzl.DomainModel.Events;
using Mzl.IApplication.Account.Domain;
using Mzl.IBLL.Common.Account.Bll;

namespace Mzl.Application.Account.Domain
{
    /// <summary>
    /// 账户业务
    /// </summary>
    internal class AccountDomain : IAccountDomain
    {
        private readonly IAccountBll<AccountModel> _accountBll;
        private readonly IAccountDetailBll<AccountDetailModel> _accountDetailBll;

        public AccountDomain(IAccountBll<AccountModel> accountBll, IAccountDetailBll<AccountDetailModel> accountDetailBll)
        {
            _accountBll = accountBll;
            _accountDetailBll = accountDetailBll;
        }

        #region 事件
        public void DoPaySupplierEvent(object o, CommonEventArgs<AccountDetailModel> e)
        {
            Pay(e.Obj);
        }

        public void DoCollectSupplierEvent(object o, CommonEventArgs<AccountDetailModel> e)
        {
            Collect(e.Obj);
        }
        #endregion

        #region 公共方法
        public void Pay(AccountDetailModel account)
        {
            AccountModel accountModel = _accountBll.GetAccountInfo(account.Aid);
            account.OldAmount = accountModel.Amount;
            accountModel.Amount = accountModel.Amount - account.Amount;
            account.NewAmount = accountModel.Amount;
            account.BusinessType = "P";
            account.Amount = account.Amount * -1;
            _accountBll.UpdateAccount(accountModel);
            _accountDetailBll.AddAccountDetail(account);
        }

        public void Collect(AccountDetailModel account)
        {
            AccountModel accountModel = _accountBll.GetAccountInfo(account.Aid);
            account.OldAmount = accountModel.Amount;
            accountModel.Amount = accountModel.Amount + account.Amount;
            account.NewAmount = accountModel.Amount;
            account.BusinessType = "C";
            _accountBll.UpdateAccount(accountModel);
            _accountDetailBll.AddAccountDetail(account);
        } 
        #endregion


    }
}
