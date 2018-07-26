using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mzl.DomainModel.Common.AuditOrder;

namespace Mzl.DomainModel.Flight
{
    /// <summary>
    /// 机票正单
    /// </summary>
    public class AuditFltOrderQueryModel : AuditTypeQueryModel
    {
        public FltOrderModel FltOrder { get; set; }

        public AuditFltOrderQueryModel ConvertFatherToSon(AuditTypeQueryModel entity)
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
