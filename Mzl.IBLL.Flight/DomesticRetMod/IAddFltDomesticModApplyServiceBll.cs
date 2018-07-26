using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mzl.Framework.Base;
using Mzl.DomainModel.Flight;

namespace Mzl.IBLL.Flight.DomesticRetMod
{
    public interface IAddFltDomesticModApplyServiceBll : IBaseServiceBll
    {
        int AddModApply(AddRetModApplyModel modApplyModel);
    }
}
