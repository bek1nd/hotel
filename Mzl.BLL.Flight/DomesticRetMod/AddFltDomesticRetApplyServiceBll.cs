using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mzl.DomainModel.Flight;
using Mzl.Framework.Base;
using Mzl.IBLL.Flight.DomesticRetMod;

namespace Mzl.BLL.Flight.DomesticRetMod
{
    internal class AddFltDomesticRetApplyServiceBll : BaseServiceBll, IAddFltDomesticRetApplyServiceBll
    {
        private readonly IAddFltRetModApplyBll _addFltRetModApplyBll;
        private readonly IValidateRetApplyBll _validateModApplyBll;
        public AddFltDomesticRetApplyServiceBll(IAddFltRetModApplyBll addFltRetModApplyBll,
             IValidateRetApplyBll validateModApplyBll) : base()
        {
            _addFltRetModApplyBll = addFltRetModApplyBll;
            _validateModApplyBll = validateModApplyBll;
        }

        public int AddRetApply(AddRetModApplyModel addRetModApplyModel)
        {
            //1.申请验证
            _validateModApplyBll.ValidateRetApply(addRetModApplyModel);

            int rmid = _addFltRetModApplyBll.AddRetModApply(addRetModApplyModel);
            return rmid;
        }
    }
}
