using Mzl.IBLL.Flight;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mzl.BLL.Flight.OrderValidate
{
    /// <summary>
    /// 差旅订单南航验证
    /// </summary>
    public class CorpCzValidate : DomesticOrderAbstractValidate
    {
        /// <summary>
        /// 判断当前订单：南航最多支持一张订单3人
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        public override bool ActionValidate(AddOrderAbstractContext context)
        {
            int passengerCount = context.AddOrderModel.PassengerList.Select(n => n.Name).Count();
            List<string> flightList = context.AddOrderModel.FlightList.Select(n => n.FlightNo.ToUpper()).Distinct().ToList();

            if (flightList.Contains("CZ") && passengerCount > 3)
            {
                throw new Exception("南航最多支持一张订单3人");
            }
            this.NextNode?.ActionValidate(context);
            return true;
        }
    }
}
