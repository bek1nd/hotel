using Mzl.Framework.Base;
using Mzl.IBLL.Flight;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mzl.DomainModel.Flight;
using Mzl.BLL.Flight.OrderValidate;

namespace Mzl.BLL.Flight
{
    public class ValidateOrderBll : BaseBll, IValidateOrderBll
    {
        private AddOrderAbstractContext _orderAbstractContext;
        private readonly ICheckPassengerIsInWhiteListBll _checkPassengerIsInWhiteListBll;

        public ValidateOrderBll(AddOrderAbstractContext orderAbstractContext, ICheckPassengerIsInWhiteListBll checkPassengerIsInWhiteListBll) : base()
        {
            _orderAbstractContext = orderAbstractContext;
            _checkPassengerIsInWhiteListBll = checkPassengerIsInWhiteListBll;
        }


        public AddOrderModel Validate(AddOrderModel fltAddOrderModel)
        {
            _orderAbstractContext.AddOrderModel = fltAddOrderModel;
            _orderAbstractContext.DbContext = this.Context;
            DomesticOrderAbstractValidate orderAmountValidate = new OrderAmountValidate();//价格验证
            DomesticOrderAbstractValidate sameFlightValidate = new SameFlightValidate();//是否存在相同行程相同乘客的订单
            DomesticOrderAbstractValidate czValidate = new CorpCzValidate();//CZ航司特殊要求验证
            DomesticOrderAbstractValidate jdValidate = new CorpJdValidate();//JD航司特殊要求验证
            //DomesticOrderAbstractValidate aduitValidate = new CorpAuditValidate();//差旅订单审核验证
            DomesticOrderAbstractValidate corpWhiteListValidate = new CorpWhiteListValidate(_checkPassengerIsInWhiteListBll);//白名单匹配
            DomesticOrderAbstractValidate buyRemarkValidate = new B2GBuyRemarkValidate();//B2G采购备注验证
            DomesticOrderAbstractValidate corpOrderValidate = new CorpOrderValidate();//公司客户订单验证
            DomesticOrderAbstractValidate unUsedTicketValidate = new UnUsedTicketValidate();//是否存在未使用票号

            orderAmountValidate.SetNextNode(sameFlightValidate);
            sameFlightValidate.SetNextNode(czValidate);
            czValidate.SetNextNode(jdValidate);
            jdValidate.SetNextNode(corpWhiteListValidate);
            corpWhiteListValidate.SetNextNode(buyRemarkValidate);
            buyRemarkValidate.SetNextNode(corpOrderValidate);
            corpOrderValidate.SetNextNode(unUsedTicketValidate);

            orderAmountValidate.ActionValidate(_orderAbstractContext);
            return fltAddOrderModel;
        }

    }
}
