using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mzl.BLL.Flight.AuditOrder.AuditValidate
{
    /// <summary>
    /// 判断当前订单是否已经审核了
    /// </summary>
    public class AlreadyAuditedValidate : AuditAbstractValidate
    {
        public override bool ActionValidate(ValidataAuditContext context)
        {
            List<string> checkStatusList = new List<string>() {"T","S","J"};
            if(context.FltOrder.CheckType!="E")
                throw new Exception("当前订单不支持系统审批");

            if (!checkStatusList.Contains(context.AuditStep))
            {
                throw new Exception("当前审批状态不正确");
            }
            string checkStatus = context.FltOrder.CheckStatus; //当前订单的审核状态
            if (context.AuditStep != checkStatus)
            {
                throw new Exception("当前订单已审批");
            }
            if (checkStatus=="J")
            {
                throw new Exception("当前订单被审批否决，不能继续审批");
            }
            if (context.FltOrder.Orderstatus=="C")
            {
                throw new Exception("当前订单已取消，不能审批");
            }

            if ((context.FltOrder.ProcessStatus&4)!=4)
            {
                throw new Exception("当前订单无法被审批");
            }

            this.NextNode?.ActionValidate(context);
            return true;
        }
    }
}
