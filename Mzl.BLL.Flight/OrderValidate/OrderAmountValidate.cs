using Mzl.IBLL.Flight;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mzl.BLL.Flight.OrderValidate
{
    /// <summary>
    /// 订单价格验证
    /// </summary>
    public class OrderAmountValidate : DomesticOrderAbstractValidate
    {
        public override bool ActionValidate(AddOrderAbstractContext context)
        {
            //1.航段合计
            if (context.AddOrderModel.FlightList.Count == 0)
                throw new Exception("订单航程信息异常");
            decimal flightAmount =
                context.AddOrderModel.FlightList.Sum(
                    n => (n.SalePrice ?? 0) + n.TaxFee + (n.OilFee ?? 0) + (n.ServiceFee ?? 0));
            //2.保险合计
            decimal insuranceAmount=context.AddOrderModel.PassengerList.Sum(n =>( n.Insurance ?? 0)*(n.InsuranceCount ?? 0));
            //3.人数
            int passengerCount = context.AddOrderModel.PassengerList.Count;
            if (passengerCount == 0)
                throw new Exception("订单人数异常");
            //订单合计
            decimal totalAmount = flightAmount*passengerCount + insuranceAmount
                                  + context.AddOrderModel.CreditcardfeeAmount 
                                  + context.AddOrderModel.SendTicketAmount
                                  + context.AddOrderModel.OtherAmount
                                  - context.AddOrderModel.Voucheramount;

            if (context.AddOrderModel.Payamount!= totalAmount)
            {
                throw new Exception("订单价格异常");
            }

            context.AddOrderModel.FlightList.ForEach(n =>
            {
                n.StandardPrice = n.FacePrice;
                n.StandardRate = n.FRate;
            });

            this.NextNode?.ActionValidate(context);
            return true;
        }
    }
}
