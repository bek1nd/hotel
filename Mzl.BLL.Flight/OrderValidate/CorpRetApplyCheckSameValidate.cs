using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mzl.EntityModel.Flight;
using Mzl.IBLL.Flight;

namespace Mzl.BLL.Flight.OrderValidate
{
    /// <summary>
    /// 退票申请重复验证
    /// </summary>
    public class CorpRetApplyCheckSameValidate: DomesticOrderAbstractValidate
    {
        public override bool ActionValidate(AddOrderAbstractContext context)
        {
            List<int> pidList = context.AddRetModApplyModel.DetailList.Select(n => n.Pid).ToList();
            List<int> sequenceList = context.AddRetModApplyModel.DetailList.Select(n => n.Sequence).ToList();

            List<string> orderStatusList = new List<string>() { "C" };
            int count = (from flight in context.DbContext.Set<FltRetModFlightApplyEntity>()
                join apply in context.DbContext.Set<FltRetModApplyEntity>() on flight.Rmid equals apply.Rmid into c
                from apply in c.DefaultIfEmpty()
                where
                    !orderStatusList.Contains(apply.OrderStatus) && pidList.Contains(flight.Pid) &&
                    sequenceList.Contains(flight.Sequence) &&
                    apply.OrderType.ToUpper() == "R"
                select flight).Count();
            if (count > 0)
            {
                throw new Exception("已经申请退票，不能重复提交！");
            }
            this.NextNode?.ActionValidate(context);
            return true;
        }
    }
}
