using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mzl.DomainModel.Flight
{
    public class QueryFlightRetApplyModel : FltRetModApplyModel
    {
        /// <summary>
        /// 退票订单信息
        /// </summary>
        public FltRefundOrderModel RefundOrder   { get; set; }

        /// <summary>
        /// 总退票金额
        /// </summary>
        public decimal? RefundMoney => RefundOrder!=null&&RefundOrder.RefundCustomer == "T" ? (RefundOrder.RefundMoney)*-1 : null;

        /// <summary>
        /// 退票费用
        /// </summary>
        public decimal? RefundFee => RefundOrder != null && RefundOrder.RefundCustomer == "T" ? RefundOrder.RefundFee : null;

        /// <summary>
        /// 退票时间
        /// </summary>
        public DateTime? RefundDate => RefundOrder?.RefundDate;

        /// <summary>
        /// 退票核价价格
        /// </summary>
        public decimal? RefundAuditPrice
        {
            get { return this.DetailList.Sum(n => n.AuditPrice); }
        }

        /// <summary>
        /// 是否需要审核
        /// </summary>
        public bool IsNeedAudit { get; set; }

        /// <summary>
        /// 退票申请行程信息
        /// </summary>
        public List<FltRetFlightModel> FltRetFlightList { get; set; }


        public QueryFlightRetApplyModel ConvertFatherToSon(FltRetModApplyModel entity)
        {
            var parentType = typeof(FltRetModApplyModel);
            var properties = parentType.GetProperties();
            foreach (var propertie in properties)
            {
                if (propertie.CanRead && propertie.CanWrite)
                {
                    propertie.SetValue(this, propertie.GetValue(entity, null), null);
                }
            }

            return this;
        }
    }
}
