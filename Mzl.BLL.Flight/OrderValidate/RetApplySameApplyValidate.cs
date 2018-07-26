using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;
using Mzl.EntityModel.Flight;
using Mzl.IBLL.Flight;

namespace Mzl.BLL.Flight.OrderValidate
{
    /// <summary>
    /// 验证是否存在相同退票申请
    /// </summary>
    public class RetApplySameApplyValidate: DomesticOrderAbstractValidate
    {
        public override bool ActionValidate(AddOrderAbstractContext context)
        {
            List<int> pidList = context.AddRetModApplyModel.DetailList.Select(n => n.Pid).ToList();
            List<int> sequenceList= context.AddRetModApplyModel.DetailList.Select(n => n.Sequence).ToList();
            List<string> orderStatusList = new List<string>() { "C" };
            var select = from flight in context.DbContext.Set<FltRetModFlightApplyEntity>()
                         join apply in context.DbContext.Set<FltRetModApplyEntity>() on flight.Rmid equals apply.Rmid into c
                         from apply in c.DefaultIfEmpty()
                         where
                             !orderStatusList.Contains(apply.OrderStatus) && pidList.Contains(flight.Pid) &&
                             sequenceList.Contains(flight.Sequence)&&
                             apply.OrderType.ToUpper() == "R"
                         select flight;
            var list = select.ToList();

            if(list.Any())
                throw new Exception("该退票申请已经提交！");

            this.NextNode?.ActionValidate(context);
            return true;
        }
    }
}
