using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Mzl.DomainModel.Train.BaseMaintenance;
using Mzl.EntityModel.Train.BaseMaintenance;
using Mzl.Framework.Base;
using Mzl.IBLL.Train.TrainWebAccount;
using Mzl.IDAL.Train;

namespace Mzl.BLL.Train.TrainWebAccount
{
    internal class Get12306AccountServiceBll: BaseServiceBll,IGet12306AccountServiceBll
    {
        private readonly ITra12306AccountDal _tra12306AccountDal;

        public Get12306AccountServiceBll(ITra12306AccountDal tra12306AccountDal)
        {
            _tra12306AccountDal = tra12306AccountDal;
        }

        public List<Tra12306AccountModel> GetTra12306Account()
        {
            List<Tra12306AccountEntity> tra12306AccountEntities =
                _tra12306AccountDal.Query<Tra12306AccountEntity>(n => !string.IsNullOrEmpty(n.IsDel) && n.IsDel == "F",
                    true).ToList();
            if (tra12306AccountEntities == null || tra12306AccountEntities.Count == 0)
                return null;
            return Mapper.Map<List<Tra12306AccountEntity>, List<Tra12306AccountModel>>(tra12306AccountEntities);
        }
    }
}
