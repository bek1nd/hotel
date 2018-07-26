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
    internal class ValidateRetApplyBll : BaseBll, IValidateRetApplyBll
    {
        private AddOrderAbstractContext _orderAbstractContext;
        public ValidateRetApplyBll(AddOrderAbstractContext orderAbstractContext) : base()
        {
            _orderAbstractContext = orderAbstractContext;
        }

        public AddRetModApplyModel ValidateRetApply(AddRetModApplyModel addRetModApplyModel)
        {
            _orderAbstractContext.AddRetModApplyModel = addRetModApplyModel;
            _orderAbstractContext.DbContext = this.Context;
            //退票申请审核验证
            //DomesticOrderAbstractValidate aduitValidate = new CorpRetApplyAuditValidate();//差旅订单审核验证
            DomesticOrderAbstractValidate ticketNoValidate = new RetApplyTicketNoValidate();//票号格式验证
            //DomesticOrderAbstractValidate samePassengerValidate = new RetApplySameApplyValidate();//是否存在相同申请
            DomesticOrderAbstractValidate corpRetApplyCheckSameValidate = new CorpRetApplyCheckSameValidate();//退票申请重复验证
            //aduitValidate.SetNextNode(ticketNoValidate);
            ticketNoValidate.SetNextNode(corpRetApplyCheckSameValidate);

            ticketNoValidate.ActionValidate(_orderAbstractContext);
            return addRetModApplyModel;
        }
    }
}
