using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mzl.DomainModel.Train.BaseMaintenance;
using Mzl.Framework.Base;

namespace Mzl.IBLL.Train.TrainWebAccount
{
    /// <summary>
    /// 获取12306帐号信息
    /// </summary>
    public interface IGet12306AccountServiceBll : IBaseServiceBll
    {
        List<Tra12306AccountModel> GetTra12306Account();
    }
}
