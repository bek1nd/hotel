using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mzl.DomainModel.Customer.Base;

namespace Mzl.DomainModel.Flight
{
    public class QueryFlightModApplyDataModel : FltRetModApplyModel
    {
        /// <summary>
        /// 改签面价
        /// </summary>
        public decimal? ModPrice { get; set; }
        /// <summary>
        /// 核价价格
        /// </summary>
        public decimal? AuditPrice
        {
            get { return this.DetailList.Sum(n => n.AuditPrice); }
        }
        /// <summary>
        /// 改签订单信息
        /// </summary>
        public FltModOrderModel FltModOrder { get; set; }
        /// <summary>
        /// 是否需要审核
        /// </summary>
        public bool IsNeedAudit { get; set; }

        


        public QueryFlightModApplyDataModel ConvertFatherToSon(FltRetModApplyModel entity)
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
