using Mzl.BLL.Flight.AddOrderCustomer;
using Mzl.IBLL.Flight;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mzl.BLL.Flight.OrderValidate
{
    /// <summary>
    /// 差旅订单审核验证
    /// </summary>
    public class CorpAuditValidate : DomesticOrderAbstractValidate 
    {
        /// <summary>
        /// 判断当前差旅订单是否需要审核
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        public override bool ActionValidate(AddOrderAbstractContext context)
        {
            AddCorpOrderCustomer addCorpOrderCustomer = null;
            if (context.AddOrderModel.Customer.Corporation?.IsAmplitudeCorp == "T")
            {
                if (context.AddOrderModel.Customer.IsMaster == "T")
                {
                    addCorpOrderCustomer = new AddCorpOrderBookingCustomer();
                }
                else
                {
                    if (context.AddOrderModel.Customer.IsCheck == "T")
                    {
                        addCorpOrderCustomer = new AddCorpOrderNeedCheckCustomer();
                    }
                    else
                    {
                        addCorpOrderCustomer = new AddCorpOrderNotNeedCheckCustomer();
                    }
                }
            }

            if (addCorpOrderCustomer != null)
            {
                IAddCorpOrderCustomerVisitor visitor = new AddCorpOrderCustomerVisitor();
                addCorpOrderCustomer.AddOrder = context.AddOrderModel;
                context.AddOrderModel = addCorpOrderCustomer.AddCorpOrderValidate(visitor);
            }

            this.NextNode?.ActionValidate(context);
            return true;
        }
    }
}
