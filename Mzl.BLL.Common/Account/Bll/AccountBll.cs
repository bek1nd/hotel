using System;
using AutoMapper;
using Mzl.DomainModel.Common.Account;
using Mzl.IBLL.Common.Account.Bll;
using Mzl.IDAL.Common.Account.Dal;
using Mzl.EntityModel.Common.AccountInfo;
using Mzl.Common.AutoMapperHelper;

namespace Mzl.BLL.Common.Account.Bll
{
    internal class AccountBll : IAccountBll<AccountModel>
    {
        private readonly IAccountDal _dal;

        public AccountBll(IAccountDal dal)
        {
            _dal = dal;
        }

        public AccountModel GetAccountInfo(int aid)
        {
            AccountEntity accountEntity = _dal.Query(aid);
            if (accountEntity == null)
                return null;
            return Mapper.Map<AccountEntity, AccountModel>(accountEntity);
        }

        public int UpdateAccount(AccountModel t)
        {
            AccountEntity accountEntity = Mapper.Map<AccountModel, AccountEntity>(t);
            return _dal.Update(accountEntity);
        }
    }
}
