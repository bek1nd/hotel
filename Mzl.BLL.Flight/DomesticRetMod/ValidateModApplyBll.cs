using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mzl.BLL.Flight.OrderValidate;
using Mzl.DomainModel.Flight;
using Mzl.Framework.Base;
using Mzl.IBLL.Flight;
using Mzl.IBLL.Flight.DomesticRetMod;

namespace Mzl.BLL.Flight.DomesticRetMod
{
    internal class ValidateModApplyBll : BaseBll, IValidateModApplyBll
    {
        private readonly AddOrderAbstractContext _orderAbstractContext;
        public ValidateModApplyBll(AddOrderAbstractContext orderAbstractContext) : base()
        {
            _orderAbstractContext = orderAbstractContext;
        }


        public AddRetModApplyModel ValidateModApply(AddRetModApplyModel modApplyModel)
        {
            _orderAbstractContext.AddRetModApplyModel = modApplyModel;
            _orderAbstractContext.DbContext = this.Context;
            //改签审核验证
            //DomesticOrderAbstractValidate aduitValidate = new CorpModApplyAuditValidate();//差旅订单审核验证
            DomesticOrderAbstractValidate corpModApplyCheckValidate = new CorpModApplyCheckSameValidate();//重复提交验证

            //aduitValidate.SetNextNode(corpModApplyCheckValidate);

            corpModApplyCheckValidate.ActionValidate(_orderAbstractContext);
            return modApplyModel;
        }
    }
}
