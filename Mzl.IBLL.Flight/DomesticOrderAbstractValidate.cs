using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mzl.IBLL.Flight
{
    /// <summary>
    /// 订单验证
    /// </summary>
    public abstract class DomesticOrderAbstractValidate
    {
        protected DomesticOrderAbstractValidate NextNode { get; private set; }
        /// <summary>
        /// 验证订单
        /// </summary>
        /// <returns></returns>
        public abstract bool ActionValidate(AddOrderAbstractContext context);
        /// <summary>
        /// 设置下一节点
        /// </summary>
        /// <param name="nextNode"></param>
        public void SetNextNode(DomesticOrderAbstractValidate nextNode)
        {
            this.NextNode = nextNode;
        }
    }
}
