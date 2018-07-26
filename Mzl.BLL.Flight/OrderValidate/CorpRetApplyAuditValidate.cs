using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mzl.IBLL.Flight;
using Mzl.BLL.Flight.AddOrderCustomer;

namespace Mzl.BLL.Flight.OrderValidate
{
    public class CorpRetApplyAuditValidate : DomesticOrderAbstractValidate
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
                IAddCorpRetApplyCustomerVisitor visitor = new AddCorpRetApplyCustomerVisitor();
                addCorpOrderCustomer.AddModApply = context.AddRetModApplyModel;
                context.AddRetModApplyModel = addCorpOrderCustomer.AddCorpRetApplyValidate(visitor);
            }

            this.NextNode?.ActionValidate(context);
            return true;
        }
    }
}
