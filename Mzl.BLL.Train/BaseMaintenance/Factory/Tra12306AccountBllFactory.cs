using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mzl.BLL.Train.BaseMaintenance.Bll;
using Mzl.DAL.Train.BaseMaintenance.Factory;
using Mzl.DomainModel.Train.BaseMaintenance;
using Mzl.IBLL.Train.BaseMaintenance.Bll;
using Mzl.IBLL.Train.BaseMaintenance.Factory;
using Mzl.IDAL.Train.BaseMaintenance.Factory;

namespace Mzl.BLL.Train.BaseMaintenance.Factory
{
    public class Tra12306AccountBllFactory : ITra12306AccountBllFactory
    {
        public ITra12306AccountBll<Tra12306AccountModel> CreateBllObj()
        {
            ITra12306AccountDalFactory tra12306AccountDalFactory = new Tra12306AccountDalFactory();
            return new Tra12306AccountBll(tra12306AccountDalFactory.CreateSampleDalObj());
        }

        public ITra12306AccountBll<Tra12306AccountModel> CreateSampleBllObj()
        {
            ITra12306AccountDalFactory tra12306AccountDalFactory = new Tra12306AccountDalFactory();
            return new Tra12306AccountBll(tra12306AccountDalFactory.CreateSampleDalObj());
        }
    }
}
