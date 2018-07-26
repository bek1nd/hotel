using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mzl.DomainModel.Flight;
using Mzl.Framework.Base;

namespace Mzl.IBLL.Flight.DomesticRetMod
{
    /// <summary>
    /// 添加退票申请服务
    /// </summary>
    public interface IAddFltDomesticRetApplyServiceBll : IBaseServiceBll
    {
        int AddRetApply(AddRetModApplyModel modApplyModel);
    }
}
