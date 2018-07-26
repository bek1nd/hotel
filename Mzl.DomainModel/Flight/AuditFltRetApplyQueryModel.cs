using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mzl.DomainModel.Common.AuditOrder;

namespace Mzl.DomainModel.Flight
{
    public class AuditFltRetApplyQueryModel : AuditTypeQueryModel
    {
        public FltRetModApplyModel FltRetApply { get; set; }
        public AuditFltRetApplyQueryModel ConvertFatherToSon(AuditTypeQueryModel entity)
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
