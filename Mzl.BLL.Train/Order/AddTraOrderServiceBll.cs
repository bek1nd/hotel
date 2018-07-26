using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mzl.DomainModel.Train.Order;
using Mzl.Framework.Base;
using Mzl.IBLL.Train.Order;

namespace Mzl.BLL.Train.Order
{
    internal class AddTraOrderServiceBll : BaseServiceBll, IAddTraOrderServiceBll
    {
        private readonly IAddTraOrderBll _addTraOrderBll;

        public AddTraOrderServiceBll(IAddTraOrderBll addTraOrderBll)
        {
            _addTraOrderBll = addTraOrderBll;
        }

        public TraAddOrderResultModel AddTraOrder(TraAddOrderModel traAddOrder)
        {
            //金额校验
            decimal totalPassengerAmount = 0;
            foreach (var detail in traAddOrder.OrderDetailList)
            {
                totalPassengerAmount+= detail.PassengerList.Sum(n => (n.FacePrice ?? 0)) +
                                    detail.PassengerList.Sum(n => (n.ServiceFee ?? 0));
            }
            if(traAddOrder.Order.TotalMoney!= totalPassengerAmount)
                throw new Exception("金额不正确");



            int orderid = _addTraOrderBll.AddTraOrder(traAddOrder);
            traAddOrder.Order.OrderId = orderid;

            return new TraAddOrderResultModel() {OrderId = orderid, AddOrderModel = traAddOrder};
        }
    }
}
