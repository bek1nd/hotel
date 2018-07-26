using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mzl.DomainModel.Train.Order
{
    public class TraOrderStatusModel
    {
        public int Sid { get; set; }
        /// <summary>
        /// 订单号
        /// </summary>
        public int OrderId { get; set; }
        /// <summary>
        /// 处理状态,1已付票款，2已付手续费，4已归账，8已预订，16也出保，32已退差价，64已处理
        /// </summary>
        public int ProccessStatus { get; set; }
        /// <summary>
        /// 是否取消
        /// </summary>
        public int IsCancle { get; set; }
        /// <summary>
        /// 是否购票 0否 1是
        /// </summary>
        public int IsBuy { get; set; }
        /// <summary>
        /// 付款操作人
        /// </summary>
        public string RealPayOid { get; set; }
        /// <summary>
        /// 付款操作时间
        /// </summary>
        public DateTime? RealPayDatetime { get; set; }
        /// <summary>
        /// 0未退票，1已退票
        /// </summary>
        public int Status4 { get; set; }
        /// <summary>
        /// 收款状态 正单：0 未收款，1已收款  退票：0未付客户款 1已付客户款
        /// </summary>
        public int Status5 { get; set; }
        /// <summary>
        /// 收款操作人
        /// </summary>
        public string CollectionOid { get; set; }
        /// <summary>
        /// 收款操作时间
        /// </summary>
        public DateTime? Collectiontime { get; set; }
        /// <summary>
        /// 记账日期
        /// </summary>
        public DateTime? KeepAccountDate { get; set; }
        /// <summary>
        /// 记账操作人
        /// </summary>
        public string KeepAccountOid { get; set; }
        /// <summary>
        /// 待申请打印 1：已申请
        /// </summary>
        public int? WaitHandle { get; set; }
    }
}
