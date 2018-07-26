using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mzl.DomainModel.Flight;

namespace Mzl.BLL.Flight.AddOrderCustomer
{
    /// <summary>
    /// 添加差旅订单需要审核客户
    /// </summary>
    public class AddCorpOrderNeedCheckCustomer: AddCorpOrderCustomer
    {
        public override AddOrderModel AddCorpOrderValidate(IAddCorpOrderCustomerVisitor customerVisitor)
        {
            return customerVisitor.AddCorpOrderValidate(this);
        }

        public override AddRetModApplyModel AddCorpModApplyValidate(IAddCorpModApplyCustomerVisitor customerVisitor)
        {
            return customerVisitor.AddCorpModApplyValidate(this);
        }

        public override AddRetModApplyModel AddCorpRetApplyValidate(IAddCorpRetApplyCustomerVisitor customerVisitor)
        {
            return customerVisitor.AddCorpRetApplyValidate(this);
        }
    }
}
