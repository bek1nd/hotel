using System;
using Mzl.IBLL.Flight;
using Mzl.IDAL.Flight;
using Mzl.EntityModel.Flight;
using System.Linq;
using System.Collections.Generic;
using Mzl.Common.Exceptions;
using Mzl.Common.EnumHelper;

namespace Mzl.BLL.Flight.OrderValidate
{
    /// <summary>
    /// 同行程同人验证
    /// </summary>
    public class SameFlightValidate : DomesticOrderAbstractValidate
    {
        /// <summary>
        /// 判断是否存在同人同行程的订单
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        public override bool ActionValidate(AddOrderAbstractContext context)
        {
            if (!context.AddOrderModel.IsCheckSameFlight)
            {
                this.NextNode?.ActionValidate(context);
                return true;
            }
            List<string> passengerNameList = context.AddOrderModel.PassengerList.Select(n => n.Name).Distinct().ToList();
            List<string> flightList = context.AddOrderModel.FlightList.Select(n => n.Dport + n.Aport).Distinct().ToList();
            //List<string> flightNoList= context.AddOrderModel.FlightList.Select(n => n.FlightNo).Distinct().ToList();
            List<DateTime> tackoffTimeList = context.AddOrderModel.FlightList.Select(n => n.TackoffTime).Distinct().ToList();

            List<string> orderStatusList = new List<string>() { "N","C"};
            DateTime beginTime = DateTime.Now.AddYears(-1);
            var select = from order in context.DbContext.Set<FltOrderEntity>()
                join flight in context.DbContext.Set<FltFlightEntity>() on order.OrderId equals flight.OrderId
                join passenger in context.DbContext.Set<FltPassengerEntity>() on order.OrderId equals passenger.OrderId
                where
                    !orderStatusList.Contains(order.Orderstatus.ToUpper()) && passengerNameList.Contains(passenger.Name) &&
                    flightList.Contains(flight.Dport + flight.Aport) && order.OrderDate > beginTime 
                    && tackoffTimeList.Contains(flight.TackoffTime)
                select order;

            var list=select.ToList();
            if (list.Any())
            {
                string message = string.Concat(list.Select(n => "," + n.OrderId).Distinct().ToList()).Substring(1);
                throw new MojoryException(MojoryApiResponseCode.SameFlight, "存在相同乘机人与航程的订单，订单号：" + message);
            }

            this.NextNode?.ActionValidate(context);
            return true;
        }
    }
}
