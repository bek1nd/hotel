using Mzl.DomainModel.Common.Account;
using Mzl.IBLL.Common.Account.Bll;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Mzl.Common.AutoMapperHelper;
using Mzl.IDAL.Common.Account.Dal;
using Mzl.EntityModel.Common.AccountInfo;

namespace Mzl.BLL.Common.Account.Bll
{
    internal class AccountDetailBll : IAccountDetailBll<AccountDetailModel>
    {
        private readonly IAccountDetailDal _dal;

        public AccountDetailBll(IAccountDetailDal dal)
        {
            _dal = dal;
        }

        public int AddAccountDetail(AccountDetailModel t)
        {
            AccountDetailEntity accountDetailEntity = Mapper.Map<AccountDetailModel, AccountDetailEntity>(t);
            return _dal.Insert(accountDetailEntity);
        }
    }
}
