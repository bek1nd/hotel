using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mzl.DomainModel.Flight;
using Mzl.Framework.Base;
using Mzl.IBLL.Flight.DomesticRetMod;
using Mzl.IDAL.Flight;

namespace Mzl.BLL.Flight.DomesticRetMod
{
    internal class AddFltDomesticModApplyServiceBll : BaseServiceBll, IAddFltDomesticModApplyServiceBll
    {
        private readonly IAddFltRetModApplyBll _addFltRetModApplyBll;
        private readonly IValidateModApplyBll _validateModApplyBll;

        public AddFltDomesticModApplyServiceBll(IAddFltRetModApplyBll addFltRetModApplyBll,
            IValidateModApplyBll validateModApplyBll)
            : base()
        {
            _addFltRetModApplyBll = addFltRetModApplyBll;
            _validateModApplyBll = validateModApplyBll;
        }

        public int AddModApply(AddRetModApplyModel modApplyModel)
        {

            //1.改签申请验证
            _validateModApplyBll.ValidateModApply(modApplyModel);

            //2.添加改签
            int rmid=_addFltRetModApplyBll.AddRetModApply(modApplyModel);

            return rmid;
        }
    }
}
