using Mzl.DomainModel.Flight;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mzl.BLL.Flight.AddOrderCustomer
{
    /// <summary>
    /// 添加差旅订单客户
    /// </summary>
    public abstract class AddCorpOrderCustomer
    {
        public AddOrderModel AddOrder { get; set; }
        public AddRetModApplyModel AddModApply { get; set; }
        public abstract AddOrderModel AddCorpOrderValidate(IAddCorpOrderCustomerVisitor customerVisitor);
        public abstract AddRetModApplyModel AddCorpModApplyValidate(IAddCorpModApplyCustomerVisitor customerVisitor);
        public abstract AddRetModApplyModel AddCorpRetApplyValidate(IAddCorpRetApplyCustomerVisitor customerVisitor);
    }
}
