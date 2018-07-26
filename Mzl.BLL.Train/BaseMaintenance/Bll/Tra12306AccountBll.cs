using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Mzl.Common.AutoMapperHelper;
using Mzl.DomainModel.Train.BaseMaintenance;
using Mzl.EntityModel.Train.BaseMaintenance;
using Mzl.IBLL.Train.BaseMaintenance.Bll;
using Mzl.IDAL.Train.BaseMaintenance.DAL;

namespace Mzl.BLL.Train.BaseMaintenance.Bll
{
    internal class Tra12306AccountBll : ITra12306AccountBll<Tra12306AccountModel>
    {
        private readonly ITra12306AccountDal _iTra12306AccountDal;

        public Tra12306AccountBll(ITra12306AccountDal iTra12306AccountDal)
        {
            _iTra12306AccountDal = iTra12306AccountDal;
        }

        public List<Tra12306AccountModel> GetTra12306AccountList()
        {
            List<Tra12306AccountEntity> accountModels =
                _iTra12306AccountDal.GeTraAddressByExpression(n => !string.IsNullOrEmpty(n.IsDel) && n.IsDel == "F");
            if (accountModels == null)
                return null;
            return Mapper.Map<List<Tra12306AccountEntity>, List<Tra12306AccountModel>>(accountModels);
        }
    }
}
