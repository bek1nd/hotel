using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mzl.Common.Factory;
using Mzl.DomainModel.Train.BaseMaintenance;
using Mzl.IBLL.Train.BaseMaintenance.Bll;

namespace Mzl.IBLL.Train.BaseMaintenance.Factory
{
    public interface ITra12306AccountBllFactory : IBaseBLLFactory<ITra12306AccountBll<Tra12306AccountModel>>
    {
    }
}
