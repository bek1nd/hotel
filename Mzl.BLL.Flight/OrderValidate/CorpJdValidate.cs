using Mzl.IBLL.Flight;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mzl.BLL.Flight.OrderValidate
{
    /// <summary>
    /// 差旅订单国航验证
    /// </summary>
    public class CorpJdValidate: DomesticOrderAbstractValidate
    {
        public override bool ActionValidate(AddOrderAbstractContext context)
        {
            int passengerCount = context.AddOrderModel.PassengerList.Select(n => n.Name).Count();
            List<string> flightList = context.AddOrderModel.FlightList.Select(n => n.FlightNo.ToUpper()).Distinct().ToList();

            if (flightList.Contains("JD") && passengerCount > 1)
            {
                throw new Exception("首航最多支持一张订单1人");
            }
            this.NextNode?.ActionValidate(context);
            return true;
        }
    }
}
