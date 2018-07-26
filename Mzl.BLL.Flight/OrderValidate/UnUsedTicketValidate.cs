using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mzl.EntityModel.Flight;
using Mzl.IBLL.Flight;
using System.Data.Entity;
using Mzl.Common.EnumHelper;
using Mzl.Common.Exceptions;
using Mzl.EntityModel.Customer.BaseInfo;

namespace Mzl.BLL.Flight.OrderValidate
{
    internal class UnUsedTicketValidate : DomesticOrderAbstractValidate
    {
        public override bool ActionValidate(AddOrderAbstractContext context)
        {
            if (!context.AddOrderModel.IsCheckUnUsedTicketNo)
            {
                this.NextNode?.ActionValidate(context);
                return true;
            }
            List<string> passengerNameList = context.AddOrderModel.PassengerList.Select(n => n.Name).Distinct().ToList();

            string message = string.Empty;
            foreach (var fltFlightModel in context.AddOrderModel.FlightList)
            {
                string temp = GetUnTicketNo(fltFlightModel.Dport, fltFlightModel.Aport,
                    context.AddOrderModel.Customer?.CorpID,
                    passengerNameList, context.DbContext, fltFlightModel.FlightNo.Substring(0, 2));
                if (!string.IsNullOrEmpty(temp))
                    message += string.Format(",第{0}程,{1}存在未使用的机票", fltFlightModel.Sequence, temp);
            }

            if (!string.IsNullOrEmpty(message))
                throw new MojoryException(MojoryApiResponseCode.HasUnUsedTicketNo, message.Substring(1));

            this.NextNode?.ActionValidate(context);
            return true;
        }

        private string GetUnTicketNo(string dport,string aport,string corpId,List<string> passengerNameList, DbContext context,string airlineNo)
        {
            List<string> orderStatusList = new List<string>() {"N", "C", "W"};
            DateTime beginTime = DateTime.Now.AddYears(-1);

            var select = from ticketNo in context.Set<FltTicketNoEntity>()
                join flight in context.Set<FltFlightEntity>() on new {ticketNo.OrderId, ticketNo.Sequence} equals
                    new {flight.OrderId, flight.Sequence}
                join order in context.Set<FltOrderEntity>() on ticketNo.OrderId equals order.OrderId
                join customer in context.Set<CustomerInfoEntity>() on order.Cid equals customer.Cid
                where
                    customer.CorpID == corpId
                    && flight.Dport == dport
                    && flight.Aport == aport
                    && flight.FlightNo.Substring(0, 2).ToUpper() == airlineNo.ToUpper()
                    && !string.IsNullOrEmpty(ticketNo.PassengerName)
                    && passengerNameList.Contains(ticketNo.PassengerName)
                    && ticketNo.TicketNoStatus == "F"
                    && !orderStatusList.Contains(order.Orderstatus.ToUpper())
                    && order.OrderDate > beginTime
                    && (order.ProcessStatus & 8) == 8 && !string.IsNullOrEmpty(ticketNo.TicketNo)
                select ticketNo;

            var list = select.ToList();
            if (list.Any())
            {
                List<string> nameList = new List<string>();
                foreach (var l in list)
                {
                    nameList.Add(l.PassengerName);
                }

                string pname = string.Empty;
                foreach (var l in nameList.Distinct().ToList())
                {
                    pname += "," + l;
                }

                return pname.Substring(1);
            }

            return string.Empty;
        }
    }
}
