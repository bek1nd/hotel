using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mzl.BLL.Flight.AuditOrder.AuditValidate
{
    public abstract class AuditAbstractValidate
    {
        protected AuditAbstractValidate NextNode { get; private set; }
        /// <summary>
        /// 验证
        /// </summary>
        /// <returns></returns>
        public abstract bool ActionValidate(ValidataAuditContext context);
        /// <summary>
        /// 设置下一节点
        /// </summary>
        /// <param name="nextNode"></param>
        public void SetNextNode(AuditAbstractValidate nextNode)
        {
            this.NextNode = nextNode;
        }
    }
}
