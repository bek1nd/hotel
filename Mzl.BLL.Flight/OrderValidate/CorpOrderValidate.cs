using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mzl.IBLL.Flight;

namespace Mzl.BLL.Flight.OrderValidate
{
    /// <summary>
    /// 公司客户订单验证
    /// </summary>
    public class CorpOrderValidate : DomesticOrderAbstractValidate
    {
        public override bool ActionValidate(AddOrderAbstractContext context)
        {
            if (context.AddOrderModel != null)
            {
                context.AddOrderModel.TravelType = 0;
                context.AddOrderModel.BalanceType = 1;
            }
            this.NextNode?.ActionValidate(context);
            return true;
        }
    }
}
