using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mzl.DomainModel.Common.AuditOrder;

namespace Mzl.DomainModel.Flight
{
    public class AuditFltModApplyQueryModel : AuditTypeQueryModel
    {
        /// <summary>
        /// 改签申请
        /// </summary>
        public FltRetModApplyModel FltModApply { get; set; }

        public AuditFltModApplyQueryModel ConvertFatherToSon(AuditTypeQueryModel entity)
        {
            var parentType = typeof(AuditTypeQueryModel);
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
