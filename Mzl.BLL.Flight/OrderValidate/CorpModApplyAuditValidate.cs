using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mzl.BLL.Flight.AddOrderCustomer;
using Mzl.IBLL.Flight;

namespace Mzl.BLL.Flight.OrderValidate
{
    public class CorpModApplyAuditValidate : DomesticOrderAbstractValidate
    {
        public override bool ActionValidate(AddOrderAbstractContext context)
        {
            AddCorpOrderCustomer addCorpOrderCustomer = null;

            if (context.AddRetModApplyModel.Customer.Corporation?.IsAmplitudeCorp == "T")
            {
                if (context.AddRetModApplyModel.Customer.IsMaster == "T")
                {
                    addCorpOrderCustomer = new AddCorpOrderBookingCustomer();
                }
                else
                {
                    if (context.AddRetModApplyModel.Customer.IsCheck == "T")
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
                IAddCorpModApplyCustomerVisitor visitor = new AddCorpModApplyCustomerVisitor();
                addCorpOrderCustomer.AddModApply = context.AddRetModApplyModel;
                context.AddRetModApplyModel = addCorpOrderCustomer.AddCorpModApplyValidate(visitor);
            }
         
            this.NextNode?.ActionValidate(context);
            return true;
        }
    }
}
