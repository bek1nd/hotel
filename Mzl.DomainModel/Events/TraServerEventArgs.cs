using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mzl.DomainModel.Events
{
    /// <summary>
    /// 火车第三方接口的事件数据
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class TraServerEventArgs<T> : EventArgs
    {
        public T Obj { get; set; }
        public int RefundOrderId { get; set; }
        public TraServerEventArgs(T t)
        {
            this.Obj = t;
        }
        public TraServerEventArgs(T t,int refundOrderId)
        {
            this.Obj = t;
            this.RefundOrderId = refundOrderId;
        }
    }
}
