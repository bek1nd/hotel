using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mzl.IBLL.Flight;

namespace Mzl.BLL.Flight.OrderValidate
{
    /// <summary>
    /// 退票申请票号格式验证
    /// </summary>
    public class RetApplyTicketNoValidate : DomesticOrderAbstractValidate
    {
        public override bool ActionValidate(AddOrderAbstractContext context)
        {
            List< string> ticketNoList =context.AddRetModApplyModel.DetailList.Select(n=>n.TicketNo).ToList();
            if (ticketNoList == null || ticketNoList.Count == 0)
                throw new Exception("退票申请请传入票号信息");

            foreach (var ticketNo in ticketNoList)
            {
                if(!ticketNo.Contains("-"))
                    throw new Exception("票号:" + ticketNo + "格式不正确");
                if (ticketNo.Length!=14)
                    throw new Exception("票号:"+ticketNo + "格式不正确");
            }

            this.NextNode?.ActionValidate(context);
            return true;
        }
    }
}
